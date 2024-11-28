namespace XTomStudio.Contracts.Models;

public interface IXTomProject
{
    string Name { get; }
    string Description { get; }
    XTomProjectType ProjectType { get; }
    List<ProjectStepDescription> ProjectSteps { get; }

    Task SaveProject();
}

public enum XTomProjectType
{
    Stepper,
    Tabs
}