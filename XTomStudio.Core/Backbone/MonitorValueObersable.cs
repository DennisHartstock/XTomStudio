using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Backbone;
public class MonitorValueObersable<T> : IRemoteObservable<T>
{
    private readonly Dictionary<string, Dictionary<string, IObserver<MonitorValueUpdate<T>>>> _monitorObserver;

    public MonitorValueObersable()
    {
        _monitorObserver = new Dictionary<string, Dictionary<string, IObserver<MonitorValueUpdate<T>>>>();
    }

    public IDisposable Subscribe(string deviceId, string monitorName, IObserver<MonitorValueUpdate<T>> observer, MonitorValueUpdate<T> startValues)
    {
        if (!_monitorObserver.ContainsKey(deviceId))
            _monitorObserver.Add(deviceId, new Dictionary<string, IObserver<MonitorValueUpdate<T>>> { { monitorName, observer } });
        else if (!_monitorObserver[deviceId].ContainsKey(monitorName))
            _monitorObserver[deviceId].Add(monitorName, observer);

        observer.OnNext(startValues);

        return new MonitorValueUnsubscriber<T>(deviceId, monitorName, _monitorObserver);
    }

    public void Update(string deviceId, string monitorName, MonitorValueUpdate<T> monitorValueUpdate)
    {
        if (_monitorObserver.TryGetValue(deviceId, out var dictObserver))
            if (dictObserver.TryGetValue(monitorName, out var observer))
                observer.OnNext(monitorValueUpdate);
    }
}
