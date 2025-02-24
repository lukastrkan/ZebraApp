using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;

namespace ZebraApp;

public partial class Test : ContentPage
{
    public Test()
    {
        InitializeComponent();

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
                    //var toast = Toast.Make(message);
                    //toast.Show();
                    lbl.Text = barcode;
                });
            }
        });
    }
}