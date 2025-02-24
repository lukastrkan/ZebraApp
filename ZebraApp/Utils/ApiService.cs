using CommunityToolkit.Mvvm.Messaging;
using ZebraApp.Api.Api;
using ZebraApp.Api.Client;
using ZebraApp.Entity;

namespace ZebraApp.Services;

public class ApiService
{
    public DefaultApi DefaultApi { get; private set; } = null!;
    public ExportApi ExportApi { get; private set; } = null!;
    public ExternalApi ExternalApi { get; private set; } = null!;
    public FieldApi FieldApi { get; private set; } = null!;
    public FilamentApi FilamentApi { get; private set; } = null!;
    public OtherApi OtherApi { get; private set; } = null!;
    public SettingApi SettingApi { get; private set; } = null!;
    public SpoolApi SpoolApi { get; private set; } = null!;
    public VendorApi VendorApi { get; private set; } = null!;

    public ApiService()
    {
        Configure();
        WeakReferenceMessenger.Default.Register<Message<bool>>(this, (recipient, message) =>
        {
            if (message.Type == MessageType.SETTINGS)
            {
                Configure();
            }
        });
    }

    public void Configure()
    {
        var path = Preferences.Get("Url", "localhost");
        if (string.IsNullOrEmpty(path))
        {
            path = "localhost";
        }

        var config = new Configuration
        {
            BasePath = path
        };
        DefaultApi = new DefaultApi(config);
        ExportApi = new ExportApi(config);
        ExternalApi = new ExternalApi(config);
        FieldApi = new FieldApi(config);
        FilamentApi = new FilamentApi(config);
        OtherApi = new OtherApi(config);
        SettingApi = new SettingApi(config);
        SpoolApi = new SpoolApi(config);
        VendorApi = new VendorApi(config);
    }
}