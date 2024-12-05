using Microsoft.Maui.Controls;

namespace XTomStudio.Contracts.Services;

public interface IThemeSelectorService
{
    //ElementTheme Theme
    //{
    //    get;
    //}

    Task InitializeAsync();

    //Task SetThemeAsync(ElementTheme theme);

    Task SetRequestedThemeAsync();
}
