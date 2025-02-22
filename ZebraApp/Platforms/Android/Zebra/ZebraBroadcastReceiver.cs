using Android.Content;
using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Entity;

namespace ZebraApp.Zebra;

[BroadcastReceiver(Enabled = true, Exported = true)]
public class ZebraBroadcastReceiver : BroadcastReceiver
{
    public override void OnReceive(Context? context, Intent? intent)
    {
        // Nemám data - rychle pryč
        if (intent?.Extras == null) return;
        if (!intent.HasExtra("com.symbol.datawedge.data_string")) return;
        
        var barcode = intent.GetStringExtra("com.symbol.datawedge.data_string");
        Console.WriteLine("Barcode: " + barcode);

        if (barcode != null)
        {
            WeakReferenceMessenger.Default.Send(new Message<string>(MessageType.BARCODE, barcode));
        }
    }
}