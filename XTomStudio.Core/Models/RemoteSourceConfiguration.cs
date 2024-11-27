using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Models;
public class RemoteSourceConfiguration
{
    public string Name
    {
        get;
    }

    public string Description
    {
        get;
    }

    public RemoteSourceConfiguration(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
