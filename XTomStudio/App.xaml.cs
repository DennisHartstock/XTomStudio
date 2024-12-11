
namespace XTomStudio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        internal static T GetService<T>()
        {
            throw new NotImplementedException();
            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}