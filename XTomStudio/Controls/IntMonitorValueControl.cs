using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;

public sealed class IntMonitorValueControl : MonitorValueDisplayControl<int>
{
    public int PadLeft
    {
        get => (int)GetValue(PadLeftProperty);
        set => SetValue(PadLeftProperty, value);
    }

    public static readonly BindableProperty PadLeftProperty =
        BindableProperty.Create(nameof(PadLeft), typeof(int), typeof(IntMonitorValueControl), 0);

    public IntMonitorValueControl()
    {
        InitializeControl();
    }

    private void InitializeControl()
    {
        this.BackgroundColor = Colors.LightGray;
        this.WidthRequest = 160;
        this.HeightRequest = 160;
    }

    protected override void ConvertToValue(int newValue)
    {
        Value = Convert.ToString(newValue).PadLeft(PadLeft);
    }
}
