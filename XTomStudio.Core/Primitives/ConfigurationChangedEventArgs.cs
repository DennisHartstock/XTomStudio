using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Models;

namespace XTomStudio.Core.Primitives;
public class ConfigurationChangedEventArgs : EventArgs
{
    /// <summary>
    /// Accessor to the configuration of the remote CT system with all neccessary devices like axes, source and detector. Returns null when not connected or connection is lost.
    /// </summary>
    public RemoteCtConfiguration? RemoteCtConfiguration { get; }

    /// <summary>
    /// Constructor ConfigurationChanged event in IRemoteClient
    /// </summary>
    /// <param name="remoteCtConfiguration">Accessor to the configuration of the remote CT system with all neccessary devices like axes, source and detector. Use null when not connected or connection is lost.</param>
    public ConfigurationChangedEventArgs(RemoteCtConfiguration? remoteCtConfiguration)
    {
        RemoteCtConfiguration = remoteCtConfiguration;
    }
}
