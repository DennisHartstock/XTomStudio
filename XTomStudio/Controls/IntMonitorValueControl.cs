using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
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

    //public IntMonitorValueControl()
    //{
    //    this.DefaultStyleKey = typeof(IntMonitorValueControl);
    //}

    protected override void ConvertToValue(int newValue)
    {
        Value = Convert.ToString(newValue).PadLeft(PadLeft);
    }
}
