//using CommunityToolkit.Maui

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;

namespace ZebraApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        
        WeakReferenceMessenger.Default.Register<Message<string>>(this, (recipient, message) =>
        {
            if (message.Type != MessageType.BARCODE) return;
            
            var barcode = message.Data.ToString();
            Console.WriteLine(message);
            if (barcode.Length > 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    //var toast = Toast.Make(message);
                    //toast.Show();
                    OutputLabel.Text = barcode;
                });
            }
        });
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}