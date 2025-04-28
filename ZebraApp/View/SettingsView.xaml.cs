using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;
using ZebraApp.Utils;

namespace ZebraApp.View;

public partial class SettingsPage : ContentPage
{
    private string Url { get; set; } = "";
    ApiService _apiService;

    public SettingsPage(ApiService apiService)
    {
        InitializeComponent();
        LoadSettings();

        _apiService = apiService;
    }

    private void LoadSettings()
    {
        Url = Preferences.Get("Url", "");
        UrlEntry.Text = Url;
    }

    private void OnSaveSettings(object sender, EventArgs e)
    {
        Preferences.Set("Url", UrlEntry.Text);
        var toast = Toast.Make("Settings saved");
        toast.Show();

        WeakReferenceMessenger.Default.Send<Message<bool>>(new Message<bool>(MessageType.SETTINGS, true));
    }
}