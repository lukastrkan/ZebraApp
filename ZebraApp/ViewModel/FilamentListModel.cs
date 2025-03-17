using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Slugify;
using ZebraApp.Entity;
using ZebraApp.Services;

namespace ZebraApp.ViewModel;

public partial class FilamentListModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<FilamentModel> _filaments;

    [ObservableProperty] private bool _isRefreshing = false;

    [ObservableProperty] private Command _refreshCommand;

    [ObservableProperty] private string? _location;

    private readonly ApiService _apiService;

    public FilamentListModel(ApiService apiService)
    {
        _apiService = apiService;
        _filaments = new ObservableCollection<FilamentModel>();
        RefreshCommand = new Command(async void () => await RefreshData());

        WeakReferenceMessenger.Default.Register<Message<bool>>(this, (recipient, message) =>
            Task.Run((() => RefreshCommand.Execute(null))));

        RefreshCommand.Execute(null);
    }

    public async Task RefreshData()
    {
        Snackbar.Make("Aktualizuji data").Show();
        IsRefreshing = true;
        await LoadFilaments();
        IsRefreshing = false;

        //Refresh view
        OnPropertyChanged(nameof(Filaments));
    }

    private async Task LoadFilaments()
    {
        var slugify = new SlugHelper();
        Filaments.Clear();
        try
        {
            await Parallel.ForEachAsync(await _apiService.SpoolApi.FindSpoolSpoolGetAsync(),
                new ParallelOptions { MaxDegreeOfParallelism = 20 }, (spool, token) =>
                {
                    var filament = new FilamentModel
                    {
                        Id = spool.Id,
                        Icon = "dotnet_bot.png",
                        Name = spool.Filament.Name,
                        Manufacturer = spool.Filament.Vendor.Name,
                        Material = spool.Filament.Material,
                        RemainingWeight = spool.RemainingWeight,
                        UsedWeight = spool.UsedWeight,
                        Price = spool.Price
                    };

                    if (Location is null || Location == slugify.GenerateSlug(spool.Location))
                    {
                        Filaments.Add(filament);
                    }

                    return ValueTask.CompletedTask;
                });

            OnPropertyChanged(nameof(Filaments));
        }
        catch (Exception e)
        {
            var bar = Snackbar.Make("Něco se nepovedlo");
            bar.Show();

            SentrySdk.CaptureException(e);
        }
    }
}