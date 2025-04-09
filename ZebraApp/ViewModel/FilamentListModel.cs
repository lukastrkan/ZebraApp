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
    private List<FilamentModel> _filaments = new List<FilamentModel>(); //TODO: Change list and then prop NotifyPropertyChangedFor with dynamic filtering

    [ObservableProperty] private bool _isRefreshing = false;

    [ObservableProperty] private Command _refreshCommand;
    [ObservableProperty] private ObservableCollection<string> _locations = [];
    
    [NotifyPropertyChangedFor(nameof(Filaments))]
    [ObservableProperty] private string? _location;
    
    public ObservableCollection<FilamentModel> Filaments
    {
        get
        {
            if (string.IsNullOrEmpty(Location))
            {
                return new ObservableCollection<FilamentModel>(_filaments);
            }
            var slugify = new SlugHelper();
            return new ObservableCollection<FilamentModel>(_filaments.FindAll(f => slugify.GenerateSlug(f.Location) == slugify.GenerateSlug(Location)));
        }
    }

    private readonly ApiService _apiService;

    public FilamentListModel(ApiService apiService)
    {
        _apiService = apiService;
        RefreshCommand = new Command(async void () => await RefreshData());

        WeakReferenceMessenger.Default.Register<Message<bool>>(this, (recipient, message) =>
            Task.Run((() => RefreshCommand.Execute(null))).GetAwaiter().GetResult());

        RefreshCommand.Execute(null);
    }

    public async Task RefreshData()
    {
        Snackbar.Make("Aktualizuji data").Show();
        IsRefreshing = true;

        // await Task.WhenAll(
        //     LoadFilaments(),
        //     LoadLocations()
        // );
        
        await LoadFilaments();
        await LoadLocations();

        IsRefreshing = false;

        //Refresh view
        OnPropertyChanged(nameof(Filaments));
    }

    private async Task LoadLocations()
    {
        //Placeholder values
        Locations = new ObservableCollection<string>()
        {
            "Police", "Tiskárna"
        };

        // TODO: Uncomment when API is ready
        // Locations.Clear();
        // try
        // {
        //     var locations = await _apiService.OtherApi.FindLocationsLocationGetAsync();
        //     foreach (var location in locations)
        //     {
        //         Locations.Add(location);
        //     }
        // }
        // catch (Exception e)
        // {
        //     SentrySdk.CaptureException(e);
        // }
    }

    private async Task LoadFilaments()
    {
        try
        {
            foreach (var spool in await _apiService.SpoolApi.FindSpoolSpoolGetAsync())
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
                    Price = spool.Price,
                    Location = spool.Location,
                };
                
                _filaments.Add(filament);
            }
        }
        catch (Exception e)
        {
            var bar = Snackbar.Make("Něco se nepovedlo");
            await bar.Show();

            SentrySdk.CaptureException(e);
        }
        OnPropertyChanged(nameof(Filaments));
    }
}