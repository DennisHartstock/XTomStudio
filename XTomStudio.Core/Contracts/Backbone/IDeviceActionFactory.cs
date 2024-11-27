using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace XTomStudio.Core.Contracts.Backbone;
public interface IDeviceActionFactory
{
    IDeviceActionAsync CreateDeviceActionAsync(string deviceId, string deviceActionName);
    IDeviceActionAsync<T1> CreateDeviceActionAsync<T1>(string deviceId, string deviceActionName);
    IDeviceActionAsync<T1, T2> CreateDeviceActionAsync<T1, T2>(string deviceId, string deviceActionName);


    IDeviceFunctionAsync<Tout> CreateDeviceFunctionAsync<Tout>(string deviceId, string deviceActionName);
    IDeviceFunctionAsync<T1, Tout> CreateDeviceFunctionAsync<T1, Tout>(string deviceId, string deviceActionName);
    IDeviceFunctionAsync<T1, T2, Tout> CreateDeviceFunctionAsync<T1, T2, Tout>(string deviceId, string deviceActionName);
}
