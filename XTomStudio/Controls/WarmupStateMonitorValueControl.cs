using XTomStudio.Core.Primitives;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;
public sealed class WarmupStateMonitorValueControl : MonitorValueDisplayControl<RemoteWarmupState>
{
    //public Brush LedColor
    //{
    //    get => (Brush)GetValue(LedColorProperty);
    //    set => SetValue(LedColorProperty, value);
    //}

    //public static readonly DependencyProperty LedColorProperty =
    //    DependencyProperty.Register("LedColor", typeof(Brush), typeof(WarmupStateMonitorValueControl), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));


    //public WarmupStateMonitorValueControl()
    //{
    //    this.DefaultStyleKey = typeof(WarmupStateMonitorValueControl);
    //}

    //protected override void ConvertToValue(RemoteWarmupState newValue)
    //{
    //    switch (newValue)
    //    {
    //        case RemoteWarmupState.None:
    //            LedColor = new SolidColorBrush(Colors.LightGray);
    //            break;
    //        case RemoteWarmupState.Ready:
    //            LedColor = new SolidColorBrush(Colors.Green);
    //            break;
    //        case RemoteWarmupState.WarmUp:
    //            LedColor = new SolidColorBrush(Colors.DarkOrange);
    //            break;
    //        case RemoteWarmupState.WarmUpRequired:
    //            LedColor = new SolidColorBrush(Colors.Red);
    //            break;
    //        default:
    //            LedColor = new SolidColorBrush(Colors.LightGray);
    //            break;
    //    }
    //}
}
