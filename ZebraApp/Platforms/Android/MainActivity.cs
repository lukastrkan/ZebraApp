using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using ZebraApp.Zebra;

namespace ZebraApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        RequestedOrientation = ScreenOrientation.Portrait;
    }

    protected override void OnPostCreate(Bundle? savedInstanceState)
    {
        base.OnPostCreate(savedInstanceState);
        
        var filter = new IntentFilter();
        filter.AddAction("kupshop");

        AndroidX.Core.Content.ContextCompat.RegisterReceiver(this, new ZebraBroadcastReceiver(), filter,
            AndroidX.Core.Content.ContextCompat.ReceiverExported);
        
    }
}
