using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace XTomStudio.Dialogs
{
    public class Connect2XTomServerDialogViewModel : BindableObject
    {
        public ICommand ConnectToServerCommand { get; }
        public ICommand CancelCommand { get; }
        public string PrimaryButtonText { get; set; } = "Connect";
        public string ActionText { get; set; } = "Connecting...";
        public string ExplanationText { get; set; }
        public bool HasError { get; set; }
        public bool IsLoading { get; set; }

        public Connect2XTomServerDialogViewModel()
        {
            ConnectToServerCommand = new Command(async () => await ConnectToServer());
            CancelCommand = new Command(() => Cancel());
        }

        private async Task ConnectToServer()
        {
            // Implement your connection logic here
        }

        private void Cancel()
        {
            // Implement your cancel logic here
        }
    }
}
