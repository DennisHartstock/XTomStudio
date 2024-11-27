using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Contracts.Backbone;
public interface IDeviceActionContext
{
    /// <summary>
    /// Unique device identifier.
    /// </summary>
    string DeviceId { get; }

    /// <summary>
    /// Name of device action.
    /// </summary>
    string DeviceActionName { get; }
}
