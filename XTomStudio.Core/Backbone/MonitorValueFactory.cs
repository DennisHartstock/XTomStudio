using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Contracts.Communication;

namespace XTomStudio.Core.Backbone;
public class MonitorValueFactory : IMonitorValueFactory
{
    private readonly IMonitorValueProvider _monitorValueProvider;

    public MonitorValueFactory(IMonitorValueProvider monitorValueProvider)
    {
        _monitorValueProvider = monitorValueProvider;
    }

    public MonitorValue<T> CreateMonitorValue<T>(string deviceId, string monitorName, T startValue) => new(deviceId, monitorName, _monitorValueProvider, startValue);
}