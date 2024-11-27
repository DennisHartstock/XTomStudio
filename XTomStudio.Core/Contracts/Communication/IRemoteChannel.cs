using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Models;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Contracts.Communication;

public interface IRemoteChannel
{
    /// <summary>
    /// Returns connection status to the server
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Establishs a client connection to the remote server
    /// </summary>
    IDeviceActionAsync ConnectAsyncCommand { get; }

    /// <summary>
    /// Disconnect client from remote server.
    /// </summary>
    IDeviceActionAsync DisconnectAsyncCommand { get; }
}
