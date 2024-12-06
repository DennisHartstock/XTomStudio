using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Graphics;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Controls;
public sealed class WarmupStateMonitorValueControl : MonitorValueDisplayControl<RemoteWarmupState>
{
    public Brush LedColor
    {
        get => (Brush)GetValue(LedColorProperty);
        set => SetValue(LedColorProperty, value);
    }

    public static readonly BindableProperty LedColorProperty =
        BindableProperty.Create(nameof(LedColor), typeof(Brush), typeof(WarmupStateMonitorValueControl), Colors.LightGray);


    public WarmupStateMonitorValueControl()
    {
        InitializeControl();
    }

    private void InitializeControl()
    {
        this.BackgroundColor = Colors.LightGray;
        this.WidthRequest = 160;
        this.HeightRequest = 160;
    }

    protected override void ConvertToValue(RemoteWarmupState newValue)
    {
        switch (newValue)
        {
            case RemoteWarmupState.None:
                LedColor = new SolidColorBrush(Colors.LightGray);
                break;
            case RemoteWarmupState.Ready:
                LedColor = new SolidColorBrush(Colors.Green);
                break;
            case RemoteWarmupState.WarmUp:
                LedColor = new SolidColorBrush(Colors.DarkOrange);
                break;
            case RemoteWarmupState.WarmUpRequired:
                LedColor = new SolidColorBrush(Colors.Red);
                break;
            default:
                LedColor = new SolidColorBrush(Colors.LightGray);
                break;
        }
    }
}
