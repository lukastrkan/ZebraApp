using CommunityToolkit.Mvvm.ComponentModel;
using Slugify;

namespace ZebraApp.ViewModel;

public partial class Filter(string name) : ObservableObject
{
    [NotifyPropertyChangedFor(nameof(FilterValue))] [ObservableProperty]
    private string _name = name;

    public string FilterValue => new SlugHelper().GenerateSlug(Name);
}