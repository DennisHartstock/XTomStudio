using XTomStudio.Models;
using XTomStudio.PageModels;

namespace XTomStudio.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}