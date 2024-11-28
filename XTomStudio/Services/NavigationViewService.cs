using System.Diagnostics.CodeAnalysis;

using Microsoft.UI.Xaml.Controls;

using XTom_Studio.Contracts.Services;
using XTom_Studio.Helpers;
using XTom_Studio.ViewModels;

namespace XTom_Studio.Services;

public class NavigationViewService : INavigationViewService
{
    private readonly INavigationService _NavigationService;

    private readonly IPageService _PageService;

    private NavigationView? _NavigationView;

    public IList<object>? MenuItems => _NavigationView?.MenuItems;

    public object? SettingsItem => _NavigationView?.SettingsItem;

    public NavigationViewService(INavigationService navigationService, IPageService pageService)
    {
        _NavigationService = navigationService;
        _PageService = pageService;
    }

    [MemberNotNull(nameof(_NavigationView))]
    public void Initialize(NavigationView navigationView)
    {
        _NavigationView = navigationView;
        _NavigationView.BackRequested += OnBackRequested;
        _NavigationView.ItemInvoked += OnItemInvoked;
    }

    public void UnregisterEvents()
    {
        if (_NavigationView != null)
        {
            _NavigationView.BackRequested -= OnBackRequested;
            _NavigationView.ItemInvoked -= OnItemInvoked;
        }
    }

    public NavigationViewItem? GetSelectedItem(Type pageType)
    {
        if (_NavigationView != null)
        {
            return GetSelectedItem(_NavigationView.MenuItems, pageType) ?? GetSelectedItem(_NavigationView.FooterMenuItems, pageType);
        }

        return null;
    }

    private void OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args) => _NavigationService.GoBack();

    private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            _NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);
        }
        else
        {
            var selectedItem = args.InvokedItemContainer as NavigationViewItem;

            if (selectedItem?.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
            {
                _NavigationService.NavigateTo(pageKey);
            }
        }
    }

    private NavigationViewItem? GetSelectedItem(IEnumerable<object> menuItems, Type pageType)
    {
        foreach (var item in menuItems.OfType<NavigationViewItem>())
        {
            if (IsMenuItemForPageType(item, pageType))
            {
                return item;
            }

            var selectedChild = GetSelectedItem(item.MenuItems, pageType);
            if (selectedChild != null)
            {
                return selectedChild;
            }
        }

        return null;
    }

    private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
    {
        if (menuItem.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
        {
            return _PageService.GetPageType(pageKey) == sourcePageType;
        }

        return false;
    }
}
