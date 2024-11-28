namespace XTomStudio.Models
{
    public class XTomCtScanProject : IXTomProject
    {
        public string Name => "CT Scan";

        public string Description => "Start a new CT Scan";

        public XTomProjectType ProjectType => XTomProjectType.Stepper;

        public List<ProjectStepDescription> ProjectSteps
        {
            get;
        }

        public XTomCtScanProject()
        {
            ProjectSteps = new List<ProjectStepDescription>()
            {
                new ProjectStepDescription("XTomStudio.Controls.ViewModels.ProjectStepSetupSampleModel", "1", "Setup"),
                new ProjectStepDescription("XTomStudio.Controls.ViewModels.ProjectStepSetupSampleModel", "2", "Contrast"),
                new ProjectStepDescription("XTomStudio.Controls.ViewModels.ProjectStepSetupSampleModel", "3", "Quality") { Symbol = "\uE7C1"},
            };
        }

        public Task SaveProject() => throw new NotImplementedException();
    }
}
