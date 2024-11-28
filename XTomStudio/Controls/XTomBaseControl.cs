using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Models;

namespace XTomStudio.Controls;

public class XTomBaseControl : Control
{
    protected IRemoteClient RemoteClient { get; }

    public XTomBaseControl()
    {
        RemoteClient = App.GetService<IRemoteClient>();
        RemoteClient.ConfigurationChanged += RemoteClient_ConfigurationChanged;
        OnConfigurationChanged(RemoteClient.RemoteCtConfiguration);
    }

    private void RemoteClient_ConfigurationChanged(object? sender, Core.Primitives.ConfigurationChangedEventArgs e) => OnConfigurationChanged(e.RemoteCtConfiguration);

    protected virtual void OnConfigurationChanged(RemoteCtConfiguration? configuration)
    {
        
    }
}
