using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Slugify;
using ZebraApp.Entity;
using ZebraApp.Services;
using ZebraApp.Utils;

namespace ZebraApp.ViewModel;

public partial class FilamentListModel : ObservableObject
{
    private List<Spool> AllSpools { get; set; } = new();

    [ObservableProperty] private bool _isRefreshing = true;

    [ObservableProperty] private Command _refreshCommand;
    [ObservableProperty] private ObservableCollection<Filter> _filters = [];

    [NotifyPropertyChangedFor(nameof(Filaments))] [ObservableProperty]
    private Filter? _filter = null;

    public ObservableCollection<Spool> Filaments
    {
        get
        {
            if (Filter?.FilterValue == "vse")
            {
                return new ObservableCollection<Spool>(AllSpools);
            }

            var slugify = new SlugHelper();
            return new ObservableCollection<Spool>(AllSpools.FindAll(f =>
                slugify.GenerateSlug(f.Location) == Filter?.FilterValue));
        }
    }

    private readonly ApiService _apiService;

    public FilamentListModel(ApiService apiService)
    {
        _apiService = apiService;
        RefreshCommand = new Command(async void () => await RefreshData());

        WeakReferenceMessenger.Default.Register<Message<bool>>(this, async (recipient, message) => await RefreshData());
        WeakReferenceMessenger.Default.Register<Message<Spool>>(this, async (recipient, message) => await RefreshData());

        RefreshCommand.Execute(null);
    }

    public async Task RefreshData()
    {
        //await Snackbar.Make("Aktualizuji data").Show();
        IsRefreshing = true;

        await Task.WhenAll(
            LoadFilaments(),
            LoadLocations()
        );

        IsRefreshing = false;

        OnPropertyChanged(nameof(Filaments));
    }

    private async Task LoadLocations()
    {
        Filters.Clear();
        foreach (var location in await _apiService.GetSpoolLocationsAsync())
        {
            Filters.Add(new Filter(location));
        }

        if (Filters.Count > 0)
        {
            if (Filter is null)
            {
                Filter = Filters[0];
            }
            else
            {
                var filter = Filters.FirstOrDefault(f => f.Name == Filter?.Name);
                if (filter is not null)
                {
                    Filter = filter;
                }
            }
        }
    }

    private async Task LoadFilaments()
    {
        AllSpools.Clear();
        try
        {
            AllSpools = await _apiService.GetSpoolsAsync();
        }
        catch (System.Exception e)
        {
            var bar = Snackbar.Make("Něco se nepovedlo");
            await bar.Show();

            SentrySdk.CaptureException(e);
        }

        OnPropertyChanged(nameof(Filaments));
    }

    public Spool? FindSpool(string code)
    {
        return AllSpools.FirstOrDefault(f => f.Id.ToString() == code);
    }
}