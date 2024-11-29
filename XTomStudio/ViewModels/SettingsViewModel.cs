using System.Reflection;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;

using Windows.ApplicationModel;

using XTomStudio.Contracts.Services;
using XTomStudio.Helpers;
using XTomStudio.Models;

namespace XTomStudio.ViewModels;

public class SettingsViewModel : ObservableRecipient
{
    private readonly IThemeSelectorService _ThemeSelectorService;
    private ElementTheme _ElementTheme;
    private string _VersionDescription;
    private string _XTomServerConnectionString = "https://localhost:7199";

    public ElementTheme ElementTheme
    {
        get => _ElementTheme;
        set => SetProperty(ref _ElementTheme, value);
    }

    public string VersionDescription
    {
        get => _VersionDescription;
        set => SetProperty(ref _VersionDescription, value);
    }

    public string XTomServerConnectionString
    {
        get => _XTomServerConnectionString;
        set => SetProperty(ref _XTomServerConnectionString, value);

        //set
        //{
        //    if (_xTomServerConnectionString != value)
        //    {
        //        _xTomServerConnectionString = value;
        //        OnPropertyChanged(nameof(XTomServerConnectionString));
        //    }
        //}
    }

    public ICommand SwitchThemeCommand
    {
        get;
    }

    public SettingsViewModel(IThemeSelectorService themeSelectorService, ILocalSettingsService settingsService)
    {
        _ThemeSelectorService = themeSelectorService;
        _ElementTheme = _ThemeSelectorService.Theme;
        _VersionDescription = GetVersionDescription();

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) =>
            {
                if (ElementTheme != param)
                {
                    ElementTheme = param;
                    await _ThemeSelectorService.SetThemeAsync(param);
                }
            });
    }

    private static string GetVersionDescription()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;

            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}
