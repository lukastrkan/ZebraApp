using CommunityToolkit.Mvvm.ComponentModel;

namespace ZebraApp.ViewModel;

public partial class FilamentModel : ObservableObject
{
    [ObservableProperty] private int _id;
    [ObservableProperty] private string _icon;
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _manufacturer;
    [ObservableProperty] private string _material;
    [ObservableProperty] private int _scanned = 0;
    [ObservableProperty] private decimal? _remainingWeight = 0;
    [ObservableProperty] private decimal _weight = 0;
    [ObservableProperty] private decimal _usedWeight = 0;
    [ObservableProperty] private decimal? _price = 0;
}