using Microsoft.UI.Xaml;
using Windows.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;
public sealed class IntMonitorValueControl : MonitorValueDisplayControl<int>
{
    //public int PadLeft
    //{
    //    get => (int)GetValue(PadLeftProperty);
    //    set => SetValue(PadLeftProperty, value);
    //}

    public static readonly DependencyProperty PadLeftProperty =
        DependencyProperty.Register("PadLeft", typeof(int), typeof(IntMonitorValueControl), new PropertyMetadata(0));

    //public IntMonitorValueControl()
    //{
    //    this.DefaultStyleKey = typeof(IntMonitorValueControl);
    //}

    //protected override void ConvertToValue(int newValue)
    //{
    //    Value = Convert.ToString(newValue).PadLeft(PadLeft);
    //}
}
