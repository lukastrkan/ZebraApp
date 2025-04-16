using CommunityToolkit.Mvvm.ComponentModel;

namespace ZebraApp.ViewModel;

public partial class Spool : ObservableObject
{
    [ObservableProperty] private int _id;
    [ObservableProperty] private DateTime _registered;
    [ObservableProperty] private Filament _filament = new();
    [ObservableProperty] private double _remainingWeight;
    [ObservableProperty] private double _initialWeight;
    [ObservableProperty] private double _spoolWeight;
    [ObservableProperty] private double _usedWeight;
    [ObservableProperty] private double _remainingLength;
    [ObservableProperty] private double _usedLength;
    [ObservableProperty] private string _location = "";
    [ObservableProperty] private bool _archived;
    [ObservableProperty] private Dictionary<string, object> _extra = new();
}