using Android.App;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ZebraApp.Services;
using ZebraApp.Utils;
using ZebraApp.ViewModel;

namespace ZebraApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var task = FileSystem.OpenAppPackageFileAsync("config.env");
        task.Wait();

        DotNetEnv.Env.Load(task.Result);
        var sentryDsn = Environment.GetEnvironmentVariable("SENTRY_DSN");
        if (sentryDsn is not null)
        {
            builder.UseSentry(options =>
            {
                options.Dsn = sentryDsn;
                options.Debug = true;
                options.TracesSampleRate = 1.0;
            });

            Console.WriteLine($"Sentry enabled with DSN: {sentryDsn}");
        }

        builder.Services.AddTransient<ApiService>()
            .AddTransient<FilamentListModel>()
            .AddTransient<MainPage>()
            .AddTransient<MoveFilamentView>()
            .AddTransient<BarcodeScannerUtil>();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoKeyboardEntry", ((handler, entry) =>
        {
#if ANDROID
            handler.PlatformView.ShowSoftInputOnFocus = false;
#endif
        }));


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}