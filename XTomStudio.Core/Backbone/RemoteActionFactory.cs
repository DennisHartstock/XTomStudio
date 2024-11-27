using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Contracts.Communication;

namespace XTomStudio.Core.Backbone;

public class RemoteActionFactory : IDeviceActionFactory
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IRemoteExecution _remoteExecution;
    private readonly IDeviceActionContextFactory _contextFactory;

    public RemoteActionFactory(ILoggerFactory loggerFactory, IDeviceActionContextFactory contextFactory, IRemoteExecution remoteExecution)
    {
        _loggerFactory = loggerFactory;
        _remoteExecution = remoteExecution;
        _contextFactory = contextFactory;
    }

    public IDeviceActionAsync CreateDeviceActionAsync(string deviceId, string deviceActionName)
        => new DeviceActionAsync(_contextFactory.CreateContext(deviceId, deviceActionName), _loggerFactory.CreateLogger<DeviceActionAsync>(), _remoteExecution.ExecuteAsync, _remoteExecution.CanExecute);

    public IDeviceActionAsync<T1> CreateDeviceActionAsync<T1>(string deviceId, string deviceActionName) 
        => new DeviceActionAsync<T1>(_contextFactory.CreateContext(deviceId, deviceActionName), _loggerFactory.CreateLogger<DeviceActionAsync<T1>>(), _remoteExecution.ExecuteAsync<T1>, _remoteExecution.CanExecute);

    public IDeviceActionAsync<T1, T2> CreateDeviceActionAsync<T1, T2>(string deviceId, string deviceActionName) 
        => new DeviceActionAsync<T1, T2>(_contextFactory.CreateContext(deviceId, deviceActionName), _loggerFactory.CreateLogger<DeviceActionAsync<T1, T2>>(), _remoteExecution.ExecuteAsync<T1, T2>, _remoteExecution.CanExecute);


    public IDeviceFunctionAsync<Tout> CreateDeviceFunctionAsync<Tout>(string deviceId, string deviceActionName)
        => new DeviceFunctionAsync<Tout>(_contextFactory.CreateContext(deviceId, deviceActionName), _loggerFactory.CreateLogger<DeviceFunctionAsync<Tout>>(), _remoteExecution.ExecuteAsync<Tout>, _remoteExecution.CanExecute);

    public IDeviceFunctionAsync<T1, Tout> CreateDeviceFunctionAsync<T1, Tout>(string deviceId, string deviceActionName) 
        => new DeviceFunctionAsync<T1, Tout>(_contextFactory.CreateContext(deviceId, deviceActionName), _loggerFactory.CreateLogger<DeviceFunctionAsync<T1, Tout>>(), _remoteExecution.ExecuteAsync<T1, Tout>, _remoteExecution.CanExecute);

    public IDeviceFunctionAsync<T1, T2, Tout> CreateDeviceFunctionAsync<T1, T2, Tout>(string deviceId, string deviceActionName) 
        => new DeviceFunctionAsync<T1, T2, Tout>(_contextFactory.CreateContext(deviceId, deviceActionName), _loggerFactory.CreateLogger<DeviceFunctionAsync<T1, T2, Tout>>(), _remoteExecution.ExecuteAsync<T1, T2, Tout>, _remoteExecution.CanExecute);
}


