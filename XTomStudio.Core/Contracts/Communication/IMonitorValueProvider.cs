using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Contracts.Communication;
public interface IMonitorValueProvider
{
    IDisposable Register<T>(string deviceId, string monitorName, IObserver<MonitorValueUpdate<T>> monitorValue);
}
