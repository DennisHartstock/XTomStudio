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

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            bool result = await DisplayAlert("Title", "Message", "OK", "Cancel");
            if (result)
            {
                var connectDialog = new Connect2XTomServerDialog();
            }
            else
            {
                // Cancel button was pressed
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
}

