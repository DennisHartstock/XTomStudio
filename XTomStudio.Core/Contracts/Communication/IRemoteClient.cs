using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Models;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Contracts.Communication;
public interface IRemoteClient
{
    /// <summary>
    /// Accessor to the configuration of the remote CT system with all neccessary devices like axes, source and detector. Returns null when not connected or connection is lost.
    /// </summary>
    RemoteCtConfiguration? RemoteCtConfiguration
    {
        get;
    }

    /// <summary>
    /// Fires when configuration of CT changes. I.e. when the connection is established or lost.
    /// </summary>
    event EventHandler<ConfigurationChangedEventArgs> ConfigurationChanged;
}
