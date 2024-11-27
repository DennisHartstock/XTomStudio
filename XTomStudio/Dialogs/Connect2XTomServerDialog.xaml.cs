// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

//using Windows.Foundation;
//using Windows.Foundation.Collections;
//using XTomStudio.Core.Models;
//using XTomStudio.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XTomStudio.Dialogs;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Connect2XTomServerDialog : ContentPage
{
    public Connect2XTomServerViewModel ViewModel
    {
        get;
    }

    public Connect2XTomServerDialog()
    {
        InitializeComponent();
        BindingContext = new Connect2XTomServerViewModel();



        //ViewModel = App.GetService<Connect2XTomServerViewModel>();
        //ViewModel.ConnectionEstablished += ViewModel_ConnectionEstablished;

        //this.InitializeComponent();
    }

    //private void ViewModel_ConnectionEstablished(object? sender, Contracts.Dialogs.ConnectionEstablishedEventargs e)
    //{
    //    this.Hide();
    //}
}
