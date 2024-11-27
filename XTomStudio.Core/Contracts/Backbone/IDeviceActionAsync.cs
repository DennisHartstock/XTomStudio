using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Contracts.Backbone;

/// <summary>
/// Interface for handling asynchrounus device actions.
/// </summary>
public interface IDeviceActionAsync : IDeviceFunction<CancellationToken, Task>, IBasicDeviceAction
{
    
}

/// <summary>
/// Interface for handling asynchrounus device actions with 1 parameter.
/// </summary>
public interface IDeviceActionAsync<T1> : IDeviceFunction<T1, CancellationToken, Task>, IBasicDeviceAction
{

}

/// <summary>
/// Interface for handling asynchrounus device actions with 2 parameter.
/// </summary>
public interface IDeviceActionAsync<T1, T2> : IDeviceFunction<T1, T2, CancellationToken, Task>, IBasicDeviceAction
{

}
