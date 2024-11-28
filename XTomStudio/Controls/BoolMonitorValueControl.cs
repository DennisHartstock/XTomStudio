using Microsoft.UI.Xaml;
using Windows.UI.Xaml;

namespace XTomStudio.Controls;
public sealed class BoolMonitorValueControl : MonitorValueDisplayControl<bool>
{
    //public Brush TrueColor
    //{
    //    get => (Brush)GetValue(TrueColorProperty);
    //    set => SetValue(TrueColorProperty, value);
    //}

    public static readonly DependencyProperty TrueColorProperty =
        DependencyProperty.Register("TrueColor", typeof(Brush), typeof(BoolMonitorValueControl), new PropertyMetadata(new SolidColorBrush(Colors.Green)));

    //public Brush FalseColor
    //{
    //    get => (Brush)GetValue(FalseColorProperty);
    //    set => SetValue(FalseColorProperty, value);
    //}

    public static readonly DependencyProperty FalseColorProperty =
            DependencyProperty.Register("FalseColor", typeof(Brush), typeof(BoolMonitorValueControl), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

    //public Brush LedColor
    //{
    //    get => (Brush)GetValue(LedColorProperty);
    //    set => SetValue(LedColorProperty, value);
    //}

    public static readonly DependencyProperty LedColorProperty =
        DependencyProperty.Register("LedColor", typeof(Brush), typeof(BoolMonitorValueControl), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));


    //public BoolMonitorValueControl()
    //{
    //    this.DefaultStyleKey = typeof(BoolMonitorValueControl);        
    //}

    //protected override void ConvertToValue(bool newValue)
    //{
    //    if (newValue)
    //        LedColor = TrueColor;
    //    else
    //        LedColor = FalseColor;
    //}
}
