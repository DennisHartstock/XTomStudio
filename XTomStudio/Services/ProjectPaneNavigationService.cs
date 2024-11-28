using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using XTom_Studio.Contracts.Services;
using XTom_Studio.Contracts.ViewModels;
using XTom_Studio.Helpers;

namespace XTom_Studio.Services;

public class ProjectPaneNavigationService : IProjectPaneNavigationService
{
    private readonly IPageService _PageService;
    private object? _LastParameterUsed;

    public event NavigatedEventHandler? Navigated;

    public Frame? Frame
    {
        get;
        set;
    }

    public ProjectPaneNavigationService(IPageService pageService)
    {
        _PageService = pageService;
    }

    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false)
    {
        var pageType = _PageService.GetPageType(pageKey);

        if (Frame != null && (Frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_LastParameterUsed))))
        {
            Frame.Tag = clearNavigation;
            var vmBeforeNavigation = Frame.GetPageViewModel();
            var navigated = Frame.Navigate(pageType, parameter);
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
}
