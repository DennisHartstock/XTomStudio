﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Models;
public class RemoteDetectorConfiguration
{
    public string Name
    {
        get;
    }

    public string Description
    {
        get;
    }

    public RemoteDetectorConfiguration(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
