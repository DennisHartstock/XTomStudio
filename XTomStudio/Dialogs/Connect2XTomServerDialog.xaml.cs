// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using XTomStudio.Core.Models;
using XTomStudio.ViewModels;

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
        ViewModel = App.GetService<Connect2XTomServerViewModel>();
        BindingContext = ViewModel;
        ViewModel.ConnectionEstablished += ViewModel_ConnectionEstablished;
    }

    private void ViewModel_ConnectionEstablished(object? sender, Contracts.Dialogs.ConnectionEstablishedEventargs e)
    {
        //this.Hide();

        Application.Current.MainPage.Navigation.PopModalAsync();

    }
}
