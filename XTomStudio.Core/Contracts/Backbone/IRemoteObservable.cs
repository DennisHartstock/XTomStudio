using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Contracts.Backbone;
public interface IRemoteObservable<T>
{
    IDisposable Subscribe(string deviceId, string monitorName, IObserver<MonitorValueUpdate<T>> observer, MonitorValueUpdate<T> startValues);
    void Update(string deviceId, string monitorName, MonitorValueUpdate<T> monitorValueUpdate);
}
