using CommunityToolkit.Mvvm.ComponentModel;
using XTomStudio.Contracts.Services;
using INavigationService = XTomStudio.Contracts.Services.INavigationService;

namespace XTomStudio.Controls.DataModels;

public abstract class NavigationViewModelBase : ObservableRecipient
{
    private bool _isBackEnabled;
    private object? _selected;

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    public bool IsBackEnabled
    {
        get => _isBackEnabled;
        set => SetProperty(ref _isBackEnabled, value);
    }

    public object? Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public NavigationViewModelBase(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        //NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
    }

    //protected virtual void OnNavigated(object sender, NavigationEventArgs e)
    //{
    //    IsBackEnabled = NavigationService.CanGoBack;

    //    if (e.SourcePageType == typeof(SettingsPage))
    //    {
    //        Selected = NavigationViewService.SettingsItem;
    //        return;
    //    }

    //    var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
    //    if (selectedItem != null)
    //    {
    //        Selected = selectedItem;
    //    }
    //}
}
