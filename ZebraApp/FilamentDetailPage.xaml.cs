using ZebraApp.ViewModel;

namespace ZebraApp;

public partial class FilamentDetailPage : ContentPage
{
    public FilamentModel FilamentModel { get; set; }
    public FilamentDetailPage(FilamentModel filamentModel)
    {
        InitializeComponent();
        FilamentModel = filamentModel;
        BindingContext = FilamentModel;
    }
}