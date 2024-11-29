using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Models;

public class ProjectStepDescription
{
    public string NavigateTo
    {
        get;
    }

    public string Tag
    {
        get;
    }

    public string Title
    {
        get;
    }

    public string? Symbol
    {
        get;
        set;
    }



    public ProjectStepDescription(string navigateTo, string tag, string title)
    {
        this.NavigateTo = navigateTo;
        this.Tag = tag;
        this.Title = title;
    }
}
