using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraApp.UI;

public partial class FilamentItem : ContentView
{
    public static readonly BindableProperty IconSourceProperty =
        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(FilamentItem), string.Empty,
            propertyChanged: OnIconChanged);

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(FilamentItem), string.Empty,
            propertyChanged: OnNameChanged);

    public static readonly BindableProperty ManufacturerProperty =
        BindableProperty.Create(nameof(Manufacturer), typeof(string), typeof(FilamentItem), string.Empty,
            propertyChanged: OnManufacturerChanged);

    public static readonly BindableProperty MaterialProperty =
        BindableProperty.Create(nameof(Material), typeof(string), typeof(FilamentItem), string.Empty,
            propertyChanged: OnMaterialChanged);

    public string IconSource
    {
        get => (string)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Manufacturer
    {
        get => (string)GetValue(ManufacturerProperty);
        set => SetValue(ManufacturerProperty, value);
    }

    public string Material
    {
        get => (string)GetValue(MaterialProperty);
        set => SetValue(MaterialProperty, value);
    }

    public FilamentItem()
    {
        InitializeComponent();
    }

    private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FilamentItem control)
        {
            control.FilamentIcon.Source = (string)newValue;
        }
    }

    private static void OnNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FilamentItem control)
        {
            control.FilamentName.Text = (string)newValue;
        }
    }

    private static void OnManufacturerChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FilamentItem control)
        {
            control.FilamentManufacturer.Text = (string)newValue;
        }
    }

    private static void OnMaterialChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FilamentItem control)
        {
            control.FilamentMaterial.Text = (string)newValue;
        }
    }
}