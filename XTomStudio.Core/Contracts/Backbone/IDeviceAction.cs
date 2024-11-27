using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Contracts.Backbone;

/// <summary>
/// Interface for handling device actions.
/// </summary>
public interface IDeviceAction : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller.
    /// </summary>
    void Execute();

    /// <summary>
    /// Checks if the function can be executed
    /// </summary>
    /// <returns></returns>
    bool CanExecute();
}

/// <summary>
/// Interface for handling device actions with 1 input parameter.
/// </summary>
public interface IDeviceAction<T1> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller.
    /// </summary>
    void Execute(T1 param1);

    /// <summary>
    /// Checks if the function can be executed
    /// </summary>
    /// <returns></returns>
    bool CanExecute(T1 param1);
}

/// <summary>
/// Interface for handling device actions with 2 input parameter.
/// </summary>
public interface IDeviceAction<T1, T2> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller.
    /// </summary>
    void Execute(T1 param1, T2 param2);

    /// <summary>
    /// Checks if the function can be executed
    /// </summary>
    /// <returns></returns>
    bool CanExecute(T1 param1, T2 param2);
}

/// <summary>
/// Interface for handling device actions with 3 input parameter.
/// </summary>
public interface IDeviceAction<T1, T2, T3> : IBasicDeviceAction
{
    /// <summary>
    /// Executes the function with check of CanExecute(). All exceptions where thrown direct to the caller.
    /// </summary>
    void Execute(T1 param1, T2 param2, T3 param3);

    /// <summary>
    /// Checks if the function can be executed
    /// </summary>
    /// <returns></returns>
    bool CanExecute(T1 param1, T2 param2, T3 param3);
}