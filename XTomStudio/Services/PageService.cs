using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using XTom_Studio.Contracts.Services;
using XTom_Studio.Controls;
using XTom_Studio.Controls.ViewModels;
using XTom_Studio.ViewModels;
using XTom_Studio.Views;

namespace XTom_Studio.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _Pages = new();

    public PageService()
    {
        Configure<MainViewModel, MainPage>();
        Configure<WebViewViewModel, WebViewPage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<XTomViewModel, XTomPage>();
        Configure<ProjectStepSetupSampleModel, ProjectStepSetupSamplePage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_Pages)
        {
            if (!_Pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>() where VM : ObservableObject where V : Page
    {
        lock (_Pages)
        {
            var key = typeof(VM).FullName!;
            if (_Pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_Pages.Any(p => p.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_Pages.First(p => p.Value == type).Key}");
            }

            _Pages.Add(key, type);
        }
    }
}
