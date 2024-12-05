
using Microsoft.Maui.Controls;

namespace XTomStudio.Controls;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public partial class SettingsPage : ContentView
{
    //public SettingsViewModel ViewModel
    //{
    //    get;
    //}

    public SettingsPage()
    {
        //ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    //private async void Click(object sender, RoutedEventArgs e)
    //{
    //    var dialogRes = ContentDialogResult.Primary;

    //    while (dialogRes == ContentDialogResult.Primary)
    //    {
    //        var connectDialog = new Connect2XTomServerDialog();
    //        connectDialog.XamlRoot = this.XamlRoot;

    //        if (App.MainWindow.Content is FrameworkElement rootElement)
    //        {
    //            connectDialog.RequestedTheme = rootElement.RequestedTheme;
    //        }

    //        dialogRes = await connectDialog.ShowAsync();
    //    }
    //    ViewModel.XTomServerConnectionString = XTomServerConnectionString.Text;
    //}
}
