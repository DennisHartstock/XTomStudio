using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Backbone;

namespace XTomStudio.Core.Contracts.Backbone;
public interface IMonitorValueFactory
{
    MonitorValue<T> CreateMonitorValue<T>(string deviceId, string monitorName, T startValue);
}
