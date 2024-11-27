using XTomStudio.Dialogs;

namespace XTomStudio.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        private async void OnLoaded(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Title", "Message", "OK", "Cancel");
            if (result)
            {
                var connectDialog = new Connect2XTomServerDialog();
                // Show or handle the dialog as needed
            }
            else
            {
                // Cancel button was pressed
            }
        }




        //ContentDialogResult dialogRes = ContentDialogResult.Primary;

        //while (dialogRes == ContentDialogResult.Primary)
        //{
        //    var connectDialog = new Connect2XTomServerDialog();
        //    // Set the parent window for the dialog
        //    connectDialog.Parent = this;

        //    // Set the requested theme if needed
        //    if (Application.Current.MainPage is Page rootPage)
        //        connectDialog.RequestedTheme = rootPage.RequestedTheme;

        //    dialogRes = await connectDialog.ShowAsync();
        //}
    }
}

