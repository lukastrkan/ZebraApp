using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Api.Model;
using ZebraApp.Entity;
using ZebraApp.Services;

namespace ZebraApp;

public partial class SettingsPage : ContentPage
{
    public string Url { get; set; }
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
        
        //Reload settings
        _apiService.Configure();

        WeakReferenceMessenger.Default.Send<Message<bool>>(new Message<bool>(MessageType.SETTINGS, true));
    }
}