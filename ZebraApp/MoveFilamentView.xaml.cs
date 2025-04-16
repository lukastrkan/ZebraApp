using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;
using ZebraApp.Services;
using ZebraApp.Utils;
using ZebraApp.ViewModel;

namespace ZebraApp;

public partial class MoveFilamentView : ContentPage
{
    private readonly ApiService _apiService;

    public Spool Spool { get; set; }

    public MoveFilamentView(Spool spool)
    {
        InitializeComponent();
        _apiService = MauiApplication.Current.Services.GetService<ApiService>();
        Spool = spool;

        BindingContext = spool;

        WeakReferenceMessenger.Default.Register<Message<string>>(this, async (recipient, message) =>
        {
            if (message.Type == MessageType.LOCATION && Shell.Current.CurrentPage == this)
            {
                var result = await _apiService.ChangeSpoolLocationAsync(Spool.Id, message.Data);
                if (!result)
                {
                    await Toast.Make("Něco se nepovedlo").Show();
                    return;
                }
                
                Spool.Location = message.Data;
                WeakReferenceMessenger.Default.Send(new Message<Spool>(MessageType.FILAMENT_UPDATE, Spool));
                await Navigation.PopAsync();
            }
        });
    }
}