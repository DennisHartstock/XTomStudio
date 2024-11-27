using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.CtConfiguration;
public class RemoteCtAxis : RemoteCtDevice
{
    public MonitorValue<RemoteDeviceState> StageStateMonitor { get; }

    public MonitorValue<double> PositionMonitor { get; }

    public RemoteCtAxis(string deviceId, IMonitorValueFactory monitorValueFactory, IDeviceActionFactory deviceActionFactory) : base(deviceId, monitorValueFactory, deviceActionFactory)
    {
        StageStateMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "StageStateMonitor", RemoteDeviceState.NotInitialized);
        PositionMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "PositionMonitor", 0.0d);
    }
}
