using CommunityToolkit.Mvvm.Input;
using XTomStudio.Models;

namespace XTomStudio.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}