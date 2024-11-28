using System.Diagnostics.CodeAnalysis;

using CommunityToolkit.WinUI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using XTom_Studio.Contracts.Services;
using XTom_Studio.Contracts.ViewModels;
using XTom_Studio.Helpers;

namespace XTom_Studio.Services;

// For more information on navigation between pages see
// https://github.com/microsoft/TemplateStudio/blob/main/docs/WinUI/navigation.md
public class NavigationService : INavigationService
{
    private readonly IPageService _PageService;
    private object? _LastParameterUsed;
    private Frame? _Frame;

    public event NavigatedEventHandler? Navigated;

    public Frame? Frame
    {
        get
        {
            if (_Frame == null)
            {
                _Frame = App.MainWindow.Content as Frame;
                RegisterFrameEvents();
            }

            return _Frame;
        }

        set
        {
            UnregisterFrameEvents();
            _Frame = value;
            RegisterFrameEvents();
        }
    }

    [MemberNotNullWhen(true, nameof(Frame), nameof(_Frame))]
    public bool CanGoBack => Frame != null && Frame.CanGoBack;

    public NavigationService(IPageService pageService)
    {
        _PageService = pageService;
    }

    private void RegisterFrameEvents()
    {
        if (_Frame != null)
        {
            _Frame.Navigated += OnNavigated;
        }
    }

    private void UnregisterFrameEvents()
    {
        if (_Frame != null)
        {
            _Frame.Navigated -= OnNavigated;
        }
    }

    public bool GoBack()
    {
        if (CanGoBack)
        {
            var vmBeforeNavigation = _Frame.GetPageViewModel();
            _Frame.GoBack();
            if (vmBeforeNavigation is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedFrom();
            }

            return true;
        }

        return false;
    }

    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false)
    {
        var pageType = _PageService.GetPageType(pageKey);

        if (_Frame != null && (_Frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_LastParameterUsed))))
        {
            _Frame.Tag = clearNavigation;
            var vmBeforeNavigation = _Frame.GetPageViewModel();
            var navigated = _Frame.Navigate(pageType, parameter);
            if (navigated)
            {
                _LastParameterUsed = parameter;
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }
            }

            return navigated;
        }

        return false;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame)
        {
            var clearNavigation = (bool)frame.Tag;
            if (clearNavigation)
            {
                frame.BackStack.Clear();
            }

            if (frame.GetPageViewModel() is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(e.Parameter);
            }

            Navigated?.Invoke(sender, e);
        }
    }

    public void SetListDataItemForNextConnectedAnimation(object item) => Frame.SetListDataItemForNextConnectedAnimation(item);
}
