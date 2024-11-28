using Microsoft.UI.Xaml;
using Windows.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;
public sealed class DoubleMonitorValueControl : MonitorValueDisplayControl<double>
{
    //public string StringFormat
    //{
    //    get => (string)GetValue(StringFormatProperty);
    //    set => SetValue(StringFormatProperty, value);
    //}

    //public static readonly DependencyProperty StringFormatProperty =
    //    DependencyProperty.Register("StringFormat", typeof(string), typeof(DoubleMonitorValueControl), new PropertyMetadata(null, (s, e) =>
    //    {
    //        var ctrl = s as DoubleMonitorValueControl;
    //        ctrl?.OnStringFormatChanged();
    //    }));


    //public int PadLeft
    //{
    //    get => (int)GetValue(PadLeftProperty);
    //    set => SetValue(PadLeftProperty, value);
    //}

    public static readonly DependencyProperty PadLeftProperty =
        DependencyProperty.Register("PadLeft", typeof(int), typeof(DoubleMonitorValueControl), new PropertyMetadata(0));


    //public DoubleMonitorValueControl()
    //{
    //    this.DefaultStyleKey = typeof(DoubleMonitorValueControl);
    //}

    //protected override void ConvertToValue(double newValue)
    //{
    //    Value = newValue.ToString(StringFormat, CultureInfo.InvariantCulture).PadLeft(PadLeft);
    //}

    //private void OnStringFormatChanged()
    //{
    //    ConvertToValue(RawValue);
    //}
}
