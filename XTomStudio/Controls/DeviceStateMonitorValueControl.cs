using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Controls;

public sealed class DeviceStateMonitorValueControl : MonitorValueDisplayControl<RemoteDeviceState>
{
    public Brush LedColor
    {
        get => (Brush)GetValue(LedColorProperty);
        set => SetValue(LedColorProperty, value);
    }

    public static readonly BindableProperty LedColorProperty =
        BindableProperty.Create(nameof(LedColor), typeof(Brush), typeof(DeviceStateMonitorValueControl), new SolidColorBrush(Colors.LightGray));


    //public DeviceStateMonitorValueControl()
    //{
    //    this.DefaultStyleKey = typeof(DeviceStateMonitorValueControl);
    //}

    protected override void ConvertToValue(RemoteDeviceState newValue)
    {
        switch (newValue)
        {
            case RemoteDeviceState.NotSet:
                LedColor = new SolidColorBrush(Colors.LightGray);
                break;
            case RemoteDeviceState.NotInitialized:
                LedColor = new SolidColorBrush(Colors.LightGray);
                break;
            case RemoteDeviceState.Ready:
                LedColor = new SolidColorBrush(Colors.Green);
                break;
            case RemoteDeviceState.Busy:
                LedColor = new SolidColorBrush(Colors.DarkOrange);
                break;
            case RemoteDeviceState.Error:
                LedColor = new SolidColorBrush(Colors.Red);
                break;
            default:
                LedColor = new SolidColorBrush(Colors.LightGray);
                break;
        }
    }
}
