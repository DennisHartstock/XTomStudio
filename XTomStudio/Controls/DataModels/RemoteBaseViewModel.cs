using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Models;

namespace XTomStudio.Controls.DataModels;
public abstract class RemoteBaseViewModel : ObservableRecipient
{
    protected IRemoteClient RemoteClient { get; }

    protected RemoteBaseViewModel(IRemoteClient remoteClient)
    {
        RemoteClient = remoteClient;
        RemoteClient.ConfigurationChanged += RemoteClient_ConfigurationChanged;
        OnConfigurationChanged(RemoteClient.RemoteCtConfiguration);
    }

    private void RemoteClient_ConfigurationChanged(object? sender, Core.Primitives.ConfigurationChangedEventArgs e) => OnConfigurationChanged(e.RemoteCtConfiguration);

    protected abstract void OnConfigurationChanged(RemoteCtConfiguration? configuration);
}
