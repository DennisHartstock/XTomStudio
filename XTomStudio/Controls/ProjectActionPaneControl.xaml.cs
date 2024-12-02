using System;
using Microsoft.Maui.Controls;
using XTomStudio.Dialogs;
using XTomStudio.Controls.ViewModels;

namespace XTomStudio.Controls;

public sealed partial class ProjectActionPaneControl : ContentView
{
    public ProjectActionPaneModel ViewModel
    {
        get;
    }

    public ProjectActionPaneControl()
    {
        InitializeComponent();
        ViewModel = App.GetService<ProjectActionPaneModel>();

        //ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.InitializeNavigationService();
        //ViewModel.NavigationViewService.Initialize(NavigationViewControl);
    }
}
