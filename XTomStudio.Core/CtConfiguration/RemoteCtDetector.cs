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
public class RemoteCtDetector : RemoteCtDevice
{
    public MonitorValue<RemoteDeviceState> DeviceStateMonitor { get; }

    public MonitorValue<double> ExposureTimeMonitor { get; }

    public MonitorValue<double> PixelSizeMonitor { get; }

    public MonitorValue<int> NAveragesMonitor { get; }

    public IDeviceActionAsync<double> SetExposureTimeCommand { get; }

    public RemoteCtDetector(string deviceId, IMonitorValueFactory monitorValueFactory, IDeviceActionFactory deviceActionFactory) : base(deviceId, monitorValueFactory, deviceActionFactory)
    {
        DeviceStateMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "DeviceStateMonitor", RemoteDeviceState.NotInitialized);
        ExposureTimeMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "ExposureTimeMonitor", 0.0d);
        PixelSizeMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "PixelSizeMonitor", 0.0d);
        NAveragesMonitor = monitorValueFactory.CreateMonitorValue(DeviceId, "NAveragesMonitor", 1);

        SetExposureTimeCommand = deviceActionFactory.CreateDeviceActionAsync<double>(DeviceId, "SetExposureTimeCommand");
    }
}
