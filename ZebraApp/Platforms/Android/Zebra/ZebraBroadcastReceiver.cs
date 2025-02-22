using System.Text;
using Android.Content;
using Android.OS;
using CommunityToolkit.Mvvm.Messaging;

namespace ZebraApp.Zebra;

[BroadcastReceiver(Enabled = true, Exported = true)]
public class DWIntentReceiver : BroadcastReceiver
{
    public override void OnReceive(Context? context, Intent? intent)
    {
        // Nemám data - rychle pryč
        if (intent.Extras == null) return;
        if (!intent.HasExtra("com.symbol.datawedge.data_string")) return;
        
        var barcode = intent.GetStringExtra("com.symbol.datawedge.data_string");
        Console.WriteLine("Barcode: " + barcode);

        if (barcode != null)
        {
            WeakReferenceMessenger.Default.Send(barcode);
        }
    }
}