namespace XTomStudio.Contracts.Services;

public interface IProjectPaneNavigationService
{
    Border? Frame
    {
        get; set;
    }

    bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false);
}
