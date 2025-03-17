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
using ZebraApp.ViewModel;

namespace ZebraApp;

public partial class MainPage : ContentPage
{
    private FilamentListModel FilamentListModel { get; set; }

    private FilamentModel? SelectedFilament { get; set; }
    private string? SelectedLocation;

    private readonly BarcodeScannerUtil _barcodeScannerUtil;

    private readonly IServiceProvider _serviceProvider;

    public MainPage(IServiceProvider serviceProvider, ApiService apiService, FilamentListModel model,
        BarcodeScannerUtil barcodeScannerUtil)
    {
        InitializeComponent();
        _barcodeScannerUtil = barcodeScannerUtil;
        _serviceProvider = serviceProvider;

        BindingContext = model;

        FilamentListModel = new FilamentListModel(apiService);

        WeakReferenceMessenger.Default.Register<Message<string>>(this, (recipient, message) =>
        {
            if (Shell.Current.CurrentPage != this) return;
            if (message.Type != MessageType.BARCODE) return;

            var barcode = message.Data.ToString();
            if (barcode.Length <= 0) return;

            var processed = _barcodeScannerUtil.ProcessBarcode(barcode);
            if (processed is null) return;


            if (processed.Type == BarcodeType.FILAMENT)
            {
                SelectedFilament = FilamentListModel.Filaments.FirstOrDefault(f => f.Id.ToString() == processed.Code);
                if (SelectedFilament is null) return;

                MainThread.BeginInvokeOnMainThread(() =>
                    Navigation.PushAsync(new FilamentDetailPage(SelectedFilament)));

                return;
            }

            if (processed.Type == BarcodeType.LOCATION)
            {
                FilamentListModel.Location = processed.Code;
                FilamentListModel.RefreshCommand.Execute(null);
                return;
            }
        });
    }

    public async void OnFilamentSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is FilamentModel filament)
        {
            await Navigation.PushAsync(new FilamentDetailPage(filament));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}