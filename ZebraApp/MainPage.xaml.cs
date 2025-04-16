using CommunityToolkit.Mvvm.Messaging;
using Slugify;
using ZebraApp.Entity;
using ZebraApp.Services;
using ZebraApp.ViewModel;

namespace ZebraApp;

public partial class MainPage : ContentPage
{
    private FilamentListModel? FilamentListModel { get; set; }
    private Spool? SelectedSpool { get; set; }

    public MainPage(FilamentListModel model)
    {
        InitializeComponent();
        
        BindingContext = model;
        FilamentListModel = model;

        WeakReferenceMessenger.Default.Register<Message<string>>(this, (recipient, message) =>
        {
            if (message.Type == MessageType.LOCATION)
            {
                if (Shell.Current.CurrentPage is FilamentDetailPage)
                {
                    MainThread.InvokeOnMainThreadAsync(async () => { await Navigation.PopToRootAsync(false); });
                }

                FilamentListModel.Filter = FilamentListModel.Filters.FirstOrDefault(f => f.Name == message.Data || f.FilterValue == message.Data);
                return;
            }

            if (message.Type == MessageType.FILAMENT)
            {
                SelectedSpool = FilamentListModel.FindSpool(message.Data);
                if (SelectedSpool is null) return;

                MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (Shell.Current.CurrentPage is FilamentDetailPage)
                    {
                        await Navigation.PopToRootAsync(false);
                    }

                    await Navigation.PushAsync(new FilamentDetailPage(SelectedSpool));
                });
            }
        });
    }

    private async void OnFilamentSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Spool spool)
        {
            await Navigation.PushAsync(new FilamentDetailPage(spool));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}