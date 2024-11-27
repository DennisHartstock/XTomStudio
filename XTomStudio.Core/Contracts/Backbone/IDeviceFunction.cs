using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Contracts.Backbone;

/// <summary>
/// Interface for handling device functions with return value.
/// </summary>
public interface IDeviceFunction<Tout> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller. Returns Tout.
    /// </summary>
    Tout Execute();

    /// <summary>
    /// Checks if the function can be executed.
    /// </summary>
    /// <returns></returns>
    bool CanExecute();
}

/// <summary>
/// Interface for handling device functions with return value and 1 input parameter.
/// </summary>
public interface IDeviceFunction<T1, Tout> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller. Returns Tout.
    /// </summary>
    Tout Execute(T1 param1);

    /// <summary>
    /// Checks if the function can be executed.
    /// </summary>
    /// <returns></returns>
    bool CanExecute(T1 param1);
}

/// <summary>
/// Interface for handling device functions with return value and 2 input parameter.
/// </summary>
public interface IDeviceFunction<T1, T2, Tout> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller. Returns Tout.
    /// </summary>
    Tout Execute(T1 param1, T2 param2);

    /// <summary>
    /// Checks if the function can be executed.
    /// </summary>
    /// <returns></returns>
    bool CanExecute(T1 param1, T2 param2);
}

/// <summary>
/// Interface for handling device functions with return value and 3 input parameter.
/// </summary>
public interface IDeviceFunction<T1, T2, T3, Tout> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller. Returns Tout.
    /// </summary>
    Tout Execute(T1 param1, T2 param2, T3 param3);

    /// <summary>
    /// Checks if the function can be executed.
    /// </summary>
    /// <returns></returns>
    bool CanExecute(T1 param1, T2 param2, T3 param3);
}