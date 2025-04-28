using ZebraApp.ViewModel;

namespace ZebraApp.View;

public partial class FilamentDetailPage : ContentPage
{
    private Spool Spool { get; set; }

    public FilamentDetailPage(Spool spool)
    {
        InitializeComponent();
        Spool = spool;
        BindingContext = Spool;
    }

    private void MenuItem_OnClicked(object? sender, EventArgs e)
    {
        var view = new MoveFilamentView(Spool);
        Navigation.PushAsync(view);
    }
}