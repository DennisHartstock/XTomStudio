using Microsoft.UI.Xaml;
using Windows.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;

[TemplatePart(Name = "MainBorder", Type = typeof(Border))]
public sealed class TileControl : ContentView
{

    //public string Title
    //{
    //    get => (string)GetValue(TitleProperty);
    //    set => SetValue(TitleProperty, value);
    //}

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(TileControl), new PropertyMetadata(null));


    //public TileControl()
    //{
    //    this.DefaultStyleKey = typeof(TileControl);

    //}

    //protected override void OnPointerEntered(PointerRoutedEventArgs e) 
    //{
    //    base.OnPointerEntered(e);
    //    Microsoft.Maui.Controls.VisualStateManager.GoToState(this, "PointerOverLayout", true);
    //}

    //protected override void OnPointerExited(PointerRoutedEventArgs e)
    //{
    //    base.OnPointerExited(e);
    //    VisualStateManager.GoToState(this, "DefaultLayout", true);
    //}

    //protected override void OnPointerPressed(PointerRoutedEventArgs e)
    //{
    //    base.OnPointerPressed(e);
    //    VisualStateManager.GoToState(this, "PointerDownLayout", true);
    //}

    //protected override void OnPointerReleased(PointerRoutedEventArgs e)
    //{
    //    base.OnPointerReleased(e);
    //    VisualStateManager.GoToState(this, "PointerUpLayout", true);
    //}

    //protected override void OnApplyTemplate()
    //{
    //    base.OnApplyTemplate();

    //    VisualStateManager.GoToState(this, "DefaultLayout", true);
    //}
}
