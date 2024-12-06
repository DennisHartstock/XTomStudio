using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;

namespace XTomStudio.Controls;

public sealed class BoolMonitorValueControl : MonitorValueDisplayControl<bool>
{
	public Brush TrueColor
	{
		get => (Brush)GetValue(TrueColorProperty);
		set => SetValue(TrueColorProperty, value);
	}

	public static readonly BindableProperty TrueColorProperty =
			BindableProperty.Create(
				nameof(TrueColor),
				typeof(Brush),
				typeof(BoolMonitorValueControl),
				new SolidColorBrush(Colors.Green));

	public Brush FalseColor
    {
        get => (Brush)GetValue(FalseColorProperty);
        set => SetValue(FalseColorProperty, value);
    }

	public static readonly BindableProperty FalseColorProperty =
			BindableProperty.Create(
				nameof(TrueColor),
				typeof(Brush),
				typeof(BoolMonitorValueControl),
				new SolidColorBrush(Colors.Red));

	public Brush LedColor
    {
        get => (Brush)GetValue(LedColorProperty);
        set => SetValue(LedColorProperty, value);
    }

	public static readonly BindableProperty LedColorProperty =
			BindableProperty.Create(
				nameof(TrueColor),
				typeof(Brush),
				typeof(BoolMonitorValueControl),
				new SolidColorBrush(Colors.LightGray));


	public BoolMonitorValueControl()
	{
        InitializeControl();
	}

    private void InitializeControl()
    {
        this.BackgroundColor = Colors.LightGray;
        this.WidthRequest = 160;
        this.HeightRequest = 160;
    }

    protected override void ConvertToValue(bool newValue)
    {
        if (newValue)
            LedColor = TrueColor;
        else
            LedColor = FalseColor;
    }
}
