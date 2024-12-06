using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;
public sealed class DoubleMonitorValueControl : MonitorValueDisplayControl<double>
{
    public string StringFormat
    {
        get => (string)GetValue(StringFormatProperty);
        set => SetValue(StringFormatProperty, value);
    }

    public static readonly BindableProperty StringFormatProperty =
        BindableProperty.Create(
            nameof(StringFormat), 
            typeof(string), 
            typeof(DoubleMonitorValueControl),
            null
            /*OnStringFormatChanged*/);


    public int PadLeft
    {
        get => (int)GetValue(PadLeftProperty);
        set => SetValue(PadLeftProperty, value);
    }

    public static readonly BindableProperty PadLeftProperty =
        BindableProperty.Create(nameof(PadLeft), typeof(int), typeof(DoubleMonitorValueControl), 0);


    public DoubleMonitorValueControl()
    {
        InitializeControl();
    }

    private void InitializeControl()
    {
        this.BackgroundColor = Colors.LightGray;
        this.WidthRequest = 160;
        this.HeightRequest = 160;
    }

    protected override void ConvertToValue(double newValue)
    {
        Value = newValue.ToString(StringFormat, CultureInfo.InvariantCulture).PadLeft(PadLeft);
    }

    private static void OnStringFormatChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var ctrl = bindable as DoubleMonitorValueControl;
        ctrl?.OnStringFormatChanged();
    }

    private void OnStringFormatChanged()
    {
    }
}
