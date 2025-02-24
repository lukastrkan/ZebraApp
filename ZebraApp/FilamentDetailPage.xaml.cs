using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraApp.Entity;

namespace ZebraApp;

public partial class FilamentDetailPage : ContentPage
{
    public FilamentDetailPage(FilamentModel filamentModel)
    {
        InitializeComponent();

        FilamentId.Text = filamentModel.Id.ToString();
        FilamentIcon.Source = filamentModel.Icon;
        FilamentName.Text = filamentModel.Name;
        FilamentManufacturer.Text = "Manufacturer: " + filamentModel.Manufacturer;
        FilamentMaterial.Text = "Material: " + filamentModel.Material;
    }
}