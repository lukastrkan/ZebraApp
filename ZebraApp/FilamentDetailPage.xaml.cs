using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;
using ZebraApp.ViewModel;

namespace ZebraApp;

public partial class FilamentDetailPage : ContentPage
{
    public FilamentModel FilamentModel { get; set; }

    public FilamentDetailPage(FilamentModel filamentModel)
    {
        InitializeComponent();
        FilamentModel = filamentModel;
        BindingContext = FilamentModel;

        WeakReferenceMessenger.Default.Register<Message<string>>(this, (recipient, message) =>
        {
            if (message.Type == MessageType.LOCATION)
            {
                //MainThread.BeginInvokeOnMainThread(() => Navigation.PopAsync());                
            }
        });
    }

    private void MenuItem_OnClicked(object? sender, EventArgs e)
    {
        this.ShowPopupAsync(new MoveFilamentPopup());
    }
}