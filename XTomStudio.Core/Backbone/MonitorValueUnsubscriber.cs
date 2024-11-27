using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Backbone;
public class MonitorValueUnsubscriber<T> : IDisposable
{
    private readonly Dictionary<string, Dictionary<string, IObserver<MonitorValueUpdate<T>>>> _monitorObserver;
    private readonly string _deviceId;
    private readonly string _monitorName;

    public MonitorValueUnsubscriber(string deviceId, string monitorName, Dictionary<string, Dictionary<string, IObserver<MonitorValueUpdate<T>>>> monitorObserver)
    {
        _deviceId = deviceId;
        _monitorName = monitorName;
        _monitorObserver = monitorObserver;
    }

    public void Dispose()
    {
        if (_monitorObserver.ContainsKey(_deviceId) && _monitorObserver[_deviceId].ContainsKey(_monitorName))
            _monitorObserver[_deviceId].Remove(_monitorName);
    }
}
