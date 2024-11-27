using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.CtConfiguration;
public class RemoteCtSource : RemoteCtDevice
{
    public MonitorValue<RemoteDeviceState> DeviceStateMonitor { get; }

    public MonitorValue<double> VoltageMonitor { get; }

    public MonitorValue<double> CurrentMonitor { get; }

    public MonitorValue<bool> InterlockClosedMonitor { get; }

    public MonitorValue<RemoteWarmupState> WarmUpMonitor { get; }

    public RemoteCtSource(string deviceId, IMonitorValueFactory monitorValueFactory, IDeviceActionFactory deviceActionFactory) : base(deviceId, monitorValueFactory, deviceActionFactory)
    {
        DeviceStateMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "DeviceStateMonitor", RemoteDeviceState.NotInitialized);
        VoltageMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "VoltageMonitor", 0.0d);
        CurrentMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "CurrentMonitor", 0.0d);
        InterlockClosedMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "InterlockClosedMonitor", false);
        WarmUpMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "WarmUpMonitor", RemoteWarmupState.None);
    }
}
