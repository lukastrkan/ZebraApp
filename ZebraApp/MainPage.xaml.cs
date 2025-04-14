using CommunityToolkit.Mvvm.Messaging;
using Slugify;
using ZebraApp.Entity;
using ZebraApp.Services;
using ZebraApp.ViewModel;

namespace ZebraApp;

public partial class MainPage : ContentPage
{
    private FilamentListModel FilamentListModel { get; set; }
    private FilamentModel? SelectedFilament { get; set; }

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
                    MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Navigation.PopToRootAsync(false);
                    });
                }
                
                FilamentListModel.Location = message.Data;
                return;
            }

            if (message.Type == MessageType.FILAMENT)
            {
                SelectedFilament = FilamentListModel.FindFilament(message.Data);
                if (SelectedFilament is null) return;
                
                MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (Shell.Current.CurrentPage is FilamentDetailPage)
                    {
                        await Navigation.PopToRootAsync(false);
                    }
                    
                    await Navigation.PushAsync(new FilamentDetailPage(SelectedFilament), false);
                });
            }
        });
    }

    private async void OnFilamentSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is FilamentModel filament)
        {
            await Navigation.PushAsync(new FilamentDetailPage(filament));
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    private async void OnToolbarItemClicked(object sender, EventArgs e)
    {
        string action =
            await DisplayActionSheet("Vyberte možnost", "Zrušit", null, FilamentListModel.Locations.ToArray());
        if (action != "Zrušit")
        {
            var slugHelper = new SlugHelper();
            FilamentListModel.Location = slugHelper.GenerateSlug(action);
        }
    }
}