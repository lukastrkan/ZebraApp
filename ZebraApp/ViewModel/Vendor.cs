using CommunityToolkit.Mvvm.ComponentModel;

namespace ZebraApp.ViewModel;

public partial class Vendor : ObservableObject
{
    [ObservableProperty] private int _id;
    [ObservableProperty] private DateTime _registered;
    [ObservableProperty] private string _name = "";
    [ObservableProperty] private double _emptySpoolWeight;
    [ObservableProperty] private Dictionary<string, object> _extra = new();
    [ObservableProperty] private string _externalId = "";
}