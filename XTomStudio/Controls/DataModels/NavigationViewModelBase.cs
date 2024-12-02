using System;
using Microsoft.Maui.Controls;
using XTomStudio.Contracts.Services;

namespace XTomStudio.Controls.DataModels;

public class NavigationViewModelBase : BindableObject
{
    private readonly INavigationService _navigationService;
    private readonly INavigationViewService _navigationViewService;
    private bool _isBackEnabled;
    private object _selected;

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
        set
        {
            _isBackEnabled = value;
            OnPropertyChanged();
        }
    }

    public object Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            OnPropertyChanged();
        }
    }

    public NavigationViewModelBase(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        _navigationService = navigationService;
        //_navigationService.Navigated += OnNavigated;
        _navigationViewService = navigationViewService;
    }

    //protected virtual void OnNavigated(object sender, NavigationEventArgs e)
    //{
    //    IsBackEnabled = _navigationService.CanGoBack;

    //    if (e.SourcePageType == typeof(SettingsPage))
    //    {
    //        Selected = _navigationViewService.SettingsItem;
    //        return;
    //    }

    //    var selectedItem = _navigationViewService.GetSelectedItem(e.SourcePageType);
    //    if (selectedItem != null)
    //    {
    //        Selected = selectedItem;
    //    }
    //}
}
