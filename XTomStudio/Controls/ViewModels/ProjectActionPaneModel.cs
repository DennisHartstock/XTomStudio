using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using XTomStudio.Controls.DataModels;
using XTomStudio.Models;
using XTomStudio.Contracts.Services;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using XTomStudio.Services;

namespace XTomStudio.Controls.ViewModels;

public class ProjectActionPaneModel : ObservableRecipient
{
    private ObservableCollection<ProjectItemStepData> _ProjectSteps;
    private ProjectItemStepData _SelectedItem;
    private int _SelectedIndex;
    private bool _IsPreviousStepVisible;

    public IProjectPaneNavigationService NavigationService
    {
        get;
    }

    public ObservableCollection<ProjectItemStepData> ProjectSteps
    {
        get => _ProjectSteps;
        private set => SetProperty(ref _ProjectSteps, value);
    }

    public ProjectItemStepData SelectedItem
    {
        get => _SelectedItem;
        private set => SetProperty(ref _SelectedItem, value);
    }

    public bool IsPreviousStepVisible
    {
        get => _IsPreviousStepVisible;
        private set => SetProperty(ref _IsPreviousStepVisible, value);
    }

    public ICommand NextStepCommand
    {
        get;
    }

    public ICommand PreviousStepCommand
    {
        get;
    }

    public ICommand StepClickedCommand
    {
        get;
    }

    public ProjectActionPaneModel(IProjectPaneNavigationService navigationService)
    {
        NavigationService = navigationService;

        var ctProject = new XTomCtScanProject(); // at next it will be loaded from DI

        if (ctProject.ProjectSteps.Count == 0)
            throw new ArgumentOutOfRangeException(nameof(ctProject.ProjectSteps));

        var steps = new ObservableCollection<ProjectItemStepData>(ctProject.ProjectSteps.ConvertAll(ConvertStepDescritpion));
        steps[0].IsEnabled = true;
        steps[0].IsSelected = true;
        steps[steps.Count - 1].HasLine = false;
        steps[steps.Count - 1].IsIcon = true;

        _ProjectSteps = steps;
        _SelectedIndex = 0;
        _SelectedItem = _ProjectSteps[_SelectedIndex];

        NextStepCommand = new RelayCommand(NextStep);
        PreviousStepCommand = new RelayCommand(PreviousStep);
        StepClickedCommand = new RelayCommand<string>(StepClicked);
    }

    public void InitializeNavigationService()
    {
        NavigationService.NavigateTo(_ProjectSteps[_SelectedIndex].NavigateTo);
    }

    private void NextStep()
    {
        if (_SelectedIndex < _ProjectSteps.Count - 1)
        {
            var stepPrev = ProjectSteps[_SelectedIndex];
            stepPrev.IsSelected = false;
            stepPrev.IsIcon = true;
            stepPrev.Symbol = "\uE73E";
            stepPrev.IsLineEnabled = true;
            ProjectSteps[_SelectedIndex] = stepPrev;

            _SelectedIndex++;
            
            var step = ProjectSteps[_SelectedIndex];
            step.IsEnabled = true;
            step.IsSelected = true;
            ProjectSteps[_SelectedIndex] = step;

            SelectedItem = _ProjectSteps[_SelectedIndex];
            IsPreviousStepVisible = true;
        }
    }

    private void PreviousStep()
    {
        if (_SelectedIndex > 0)
        {
            var stepPrev = ProjectSteps[_SelectedIndex];
            stepPrev.IsSelected = false;
            ProjectSteps[_SelectedIndex] = stepPrev;

            _SelectedIndex--;

            var step = ProjectSteps[_SelectedIndex];
            step.IsSelected = true;
            step.IsLineEnabled = true;
            ProjectSteps[_SelectedIndex] = step;

            SelectedItem = _ProjectSteps[_SelectedIndex];
            IsPreviousStepVisible = true;
        }

        if (_SelectedIndex < 1)
        {
            IsPreviousStepVisible = false;
        }
    }

    private void StepClicked(string? tag)
    {
        ProjectItemStepData? stepItem = ProjectSteps.FirstOrDefault(item => item.Tag == tag);
        if (stepItem != null)
        {
            var stepPrev = ProjectSteps[_SelectedIndex];
            stepPrev.IsSelected = false;
            ProjectSteps[_SelectedIndex] = stepPrev;

            _SelectedIndex = ProjectSteps.IndexOf(stepItem);
            stepItem.IsSelected = true;
            ProjectSteps[_SelectedIndex] = stepItem;

            SelectedItem = _ProjectSteps[_SelectedIndex];

            if (_SelectedIndex < 1)
                IsPreviousStepVisible = false;
            else
                IsPreviousStepVisible = true;
        }
    }

    private ProjectItemStepData ConvertStepDescritpion(ProjectStepDescription stepDescription)
    {
        ArgumentNullException.ThrowIfNull(stepDescription, nameof(stepDescription));

        var stepData = new ProjectItemStepData(this, stepDescription.Tag, stepDescription.Title, stepDescription.NavigateTo) { Symbol = stepDescription.Symbol };
        stepData.IsIcon = stepDescription.Symbol != null;

        return stepData;
    }
}