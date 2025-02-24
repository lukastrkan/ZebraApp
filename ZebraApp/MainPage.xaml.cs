//using CommunityToolkit.Maui

using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;
using CommunityToolkit.Maui.Core.Platform;
using ZebraApp.Api.Api;
using ZebraApp.Api.Client;
using ZebraApp.Api.Model;
using ZebraApp.Services;

namespace ZebraApp;

public partial class MainPage : ContentPage
{
    int count = 0;
    private ApiService _apiService;
    public bool IsRefreshing { get; set; }
    public Command RefreshCommand { get; set; }
    public ObservableCollection<FilamentModel> Filaments { get; set; }

    public MainPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;

        WeakReferenceMessenger.Default.Register<Message<string>>(this, (recipient, message) =>
        {
            if (Shell.Current.CurrentPage != this) return;
            if (message.Type != MessageType.BARCODE) return;

            var barcode = message.Data.ToString();
            Console.WriteLine(message);
            if (barcode.Length > 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    string filamentId = "";
                    if (barcode.Contains('/'))
                    {
                        filamentId = barcode.Split('/').Last();
                    }
                    else if (barcode.Contains("web+spoolman:s-"))
                    {
                        filamentId = barcode.Replace("web+spoolman:s-", "");
                    }

                    if (Filaments != null && !string.IsNullOrEmpty(filamentId))
                    {
                        var filament = Filaments.FirstOrDefault(f => f.Id.ToString() == filamentId);
                        if (filament != null)
                        {
                            Navigation.PushAsync(new FilamentDetailPage(filament));
                        }
                        else
                        {
                            DisplayAlert("Chyba", "Nepodařilo se najít filament", "OK");
                        }
                    }
                });
            }
        });

        WeakReferenceMessenger.Default.Register<Message<bool>>(this, (recipient, message) => _ = RefreshData());

        Filaments = new ObservableCollection<FilamentModel>();

        _ = RefreshData();

        RefreshCommand = new Command(async void () => await RefreshData());

        BindingContext = this;
    }

    private async Task RefreshData()
    {
        IsRefreshing = true;

        await LoadFilaments();

        IsRefreshing = false;
        OnPropertyChanged(nameof(IsRefreshing));
    }

    private async Task LoadFilaments()
    {
        Filaments.Clear();
        try
        {
            foreach (var spool in await _apiService.SpoolApi.FindSpoolSpoolGetAsync())
            {
                Filaments.Add(
                    new FilamentModel
                    {
                        Id = spool.Id,
                        Icon = "dotnet_bot.png",
                        Name = spool.Filament.Name,
                        Manufacturer = spool.Filament.Vendor.Name,
                        Material = spool.Filament.Material
                    }
                );
            }
        }
        catch (ApiException e)
        {
            await DisplayAlert("Chyba", "Nepodařilo se načíst data", "OK");
        }
    }

    public async void OnFilamentSelected(object sender, SelectionChangedEventArgs e)
    {
        ((CollectionView)sender).SelectedItem = null; // Clear selection
        if (e.CurrentSelection.FirstOrDefault() is FilamentModel filament)
        {
            //await DisplayAlert($"Detail: {filament.Id}", filament.Name, "OK");
            await Navigation.PushAsync(new FilamentDetailPage(filament));
        }
    }
}