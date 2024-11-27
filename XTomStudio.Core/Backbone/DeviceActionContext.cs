using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Backbone;

namespace XTomStudio.Core.Backbone;
public class DeviceActionContext : IDeviceActionContext
{
    public string DeviceId { get; }

    public string DeviceActionName { get; }

    public DeviceActionContext(string deviceId, string name)
    {
        DeviceId = deviceId;
        DeviceActionName = name;
    }
}
