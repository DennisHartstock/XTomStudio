using Microsoft.Maui.Controls;

namespace XTomStudio.Helpers;

public static class FrameExtensions
{
    public static object? GetPageViewModel(this Border border) => border?.Content?.GetType().GetProperty("ViewModel")?.GetValue(border.Content, null);
}
