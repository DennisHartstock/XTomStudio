using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Contracts.Backbone;

/// <summary>
/// Interface for handling asynchrounus device actions with return value.
/// </summary>
public interface IDeviceFunctionAsync<Tout> : IDeviceFunction<CancellationToken, Task<Tout>>, IBasicDeviceAction
{
}


/// <summary>
/// Interface for handling asynchrounus device actions with return value and 1 parameter.
/// </summary>
public interface IDeviceFunctionAsync<T1, Tout> : IDeviceFunction<T1, CancellationToken, Task<Tout>>, IBasicDeviceAction
{

}

/// <summary>
/// Interface for handling asynchrounus device actions with return value and 2 parameter.
/// </summary>
public interface IDeviceFunctionAsync<T1, T2, Tout> : IDeviceFunction<T1, T2, CancellationToken, Task<Tout>>, IBasicDeviceAction
{

}
