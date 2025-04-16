using CommunityToolkit.Mvvm.ComponentModel;

namespace ZebraApp.ViewModel;

public partial class Filament : ObservableObject
{
    [ObservableProperty] private int _id;
    [ObservableProperty] private DateTime _registered;
    [ObservableProperty] private string _name = "";
    [ObservableProperty] private Vendor _vendor = new();
    [ObservableProperty] private string _material = "";
    [ObservableProperty] private double _density;
    [ObservableProperty] private double _diameter;
    [ObservableProperty] private double _weight;
    [ObservableProperty] private double _spoolWeight;
    [ObservableProperty] private string _colorHex = "";
    [ObservableProperty] private int? _settingsExtruderTemp;
    [ObservableProperty] private int? _settingsBedTemp;
    [ObservableProperty] private string _externalId = "";
    [ObservableProperty] private Dictionary<string, object> _extra = new();
}