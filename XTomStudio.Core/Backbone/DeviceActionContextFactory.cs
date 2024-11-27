using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Backbone;

namespace XTomStudio.Core.Backbone;
public class DeviceActionContextFactory : IDeviceActionContextFactory
{
    public DeviceActionContextFactory()
    {
    }

    /// <summary>
    /// Creates device action context.
    /// </summary>
    /// <param name="deviceId">Unique device identifier.</param>
    /// <param name="deviceActionName">Name of device action.</param>
    /// <returns></returns>
    public IDeviceActionContext CreateContext(string deviceId, string name)
    {
        return new DeviceActionContext(deviceId, name);
    }
}
