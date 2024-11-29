using CommunityToolkit.Mvvm.ComponentModel;

using XTomStudio.Contracts.Services;
using XTomStudio.Controls.DataModels;

namespace XTomStudio.ViewModels;

public class ShellViewModel : NavigationViewModelBase
{
    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService) : base(navigationService, navigationViewService)
    {
        
    }
}
