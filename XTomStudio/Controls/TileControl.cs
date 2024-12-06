using Microsoft.Maui.Controls;

namespace XTomStudio.Controls;

public sealed class TileControl : ContentView
{
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(TileControl), null);

    public TileControl()
    {
        InitializeControl();

        var pointerEnteredRecognizer = new PointerGestureRecognizer();
        pointerEnteredRecognizer.PointerEntered += OnPointerEntered;
        this.GestureRecognizers.Add(pointerEnteredRecognizer);

        var pointerExitedRecognizer = new PointerGestureRecognizer();
        pointerExitedRecognizer.PointerExited += OnPointerExited;
        this.GestureRecognizers.Add(pointerExitedRecognizer);

        var pointerPressedRecognizer = new PointerGestureRecognizer();
        pointerPressedRecognizer.PointerPressed += OnPointerPressed;
        this.GestureRecognizers.Add(pointerPressedRecognizer);

        var pointerReleasedRecognizer = new PointerGestureRecognizer();
        pointerReleasedRecognizer.PointerReleased += OnPointerReleased;
        this.GestureRecognizers.Add(pointerReleasedRecognizer);
    }

    private void InitializeControl()
    {
        this.BackgroundColor = Colors.LightGray;
        this.WidthRequest = 160;
        this.HeightRequest = 160;
    }

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
            //this.GestureRecognizers.Add(new PointerGestureRecognizer { PointerEntered = OnPointerEntered });
            //this.GestureRecognizers.Add(new PointerGestureRecognizer { PointerExited = OnPointerExited });
            //this.GestureRecognizers.Add(new PointerGestureRecognizer { PointerPressed = OnPointerPressed });
            //this.GestureRecognizers.Add(new PointerGestureRecognizer { PointerReleased = OnPointerReleased });
        }
        else
        {
            // Detach event handlers for pointer events
            this.GestureRecognizers.Clear();
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
