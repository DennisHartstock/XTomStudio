using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.CtConfiguration;
public class RemoteCtDevice
{
    public string DeviceId { get; }

    public MonitorValue<bool> IsInitializedMonitor { get; }

    public IDeviceActionAsync InitDeviceAsyncCommand { get; }

    public RemoteCtDevice(string deviceId, IMonitorValueFactory monitorValueFactory, IDeviceActionFactory deviceActionFactory)
    {
        DeviceId = deviceId;

        IsInitializedMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "IsInitializedMonitor", false);
        
        InitDeviceAsyncCommand = deviceActionFactory.CreateDeviceActionAsync(DeviceId, "InitDeviceAsyncCommand");
    }
}
