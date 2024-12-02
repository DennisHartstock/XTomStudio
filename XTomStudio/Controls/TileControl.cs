using Microsoft.Maui.Controls;

namespace XTomStudio.Controls;

[ContentProperty(nameof(Content))]
public sealed class TileControl : ContentView
{
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(TileControl), null);

    //public TileControl()
    //{
    //    this.DefaultStyleKey = typeof(TileControl);
    //}

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        VisualStateManager.GoToState(this, "DefaultLayout");
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler != null)
        {
            // Attach event handlers for pointer events
            this.AddHandler(PointerEnteredEvent, OnPointerEntered, true);
            this.AddHandler(PointerExitedEvent, OnPointerExited, true);
            this.AddHandler(PointerPressedEvent, OnPointerPressed, true);
            this.AddHandler(PointerReleasedEvent, OnPointerReleased, true);
        }
        else
        {
            // Detach event handlers for pointer events
            this.RemoveHandler(PointerEnteredEvent, OnPointerEntered);
            this.RemoveHandler(PointerExitedEvent, OnPointerExited);
            this.RemoveHandler(PointerPressedEvent, OnPointerPressed);
            this.RemoveHandler(PointerReleasedEvent, OnPointerReleased);
        }
    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        VisualStateManager.GoToState(this, "PointerOverLayout");
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        VisualStateManager.GoToState(this, "DefaultLayout");
    }

    private void OnPointerPressed(object sender, PointerEventArgs e)
    {
        VisualStateManager.GoToState(this, "PointerDownLayout");
    }

    private void OnPointerReleased(object sender, PointerEventArgs e)
    {
        VisualStateManager.GoToState(this, "PointerUpLayout");
    }
}
