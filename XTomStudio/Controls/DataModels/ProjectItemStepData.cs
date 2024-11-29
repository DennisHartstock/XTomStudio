using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using XTomStudio.Contracts.Models;
using XTomStudio.Models;
using XTomStudio.Controls.ViewModels;

namespace XTomStudio.Controls.DataModels;

public class ProjectItemStepData
{
    public string? Symbol
    {
        get;
        set;
    }

    public ProjectActionPaneModel ViewModel
    {
        get;
    }

    public string Tag
    {
        get;
    }

    public string Tooltip
    {
        get;
    }

    public string NavigateTo
    {
        get;
    }

    public XTomProjectType ProjectType
    {
        get;
    } = XTomProjectType.Stepper;

    public bool HasLine
    {
        get;
        set;
    } = true;

    public bool IsLineEnabled
    {
        get;
        set;
    }

    public bool IsEnabled
    {
        get;
        set;
    }

    public bool IsSelected
    {
        get;
        set;
    }

    public bool IsIcon
    {
        get;
        set;
    }

    public ProjectItemStepData(ProjectActionPaneModel viewModel, string tag, string tooltip, string navigateTo)
    {
        this.ViewModel = viewModel;
        this.Tag = tag;
        this.Tooltip = tooltip;
        this.NavigateTo = navigateTo;
    }
}