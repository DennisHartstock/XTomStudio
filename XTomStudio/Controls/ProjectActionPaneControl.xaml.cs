// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using XTomStudio.Dialogs;
using XTomStudio.Controls.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Controls;

public sealed partial class ProjectActionPaneControl : UserControl
{
    public ProjectActionPaneModel ViewModel
    {
        get;
    }

    public ProjectActionPaneControl()
    {
        ViewModel = App.GetService<ProjectActionPaneModel>();
        this.InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.InitializeNavigationService();
        //ViewModel.NavigationViewService.Initialize(NavigationViewControl);
    }
}
