using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Contracts.Communication;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XTomStudio.Core.Backbone;

/// <summary>
/// Command class for handling asynchrounus device actions.
/// </summary>
public class DeviceActionAsync : BasicDeviceAction, IDeviceActionAsync
{
    private readonly ILogger _logger;
    private readonly Func<IDeviceActionContext, CancellationToken, Task> _executeAsync;
    private readonly Func<IDeviceActionContext, bool> _canExecute;

    public DeviceActionAsync(IDeviceActionContext deviceContext, ILogger logger, Func<IDeviceActionContext, CancellationToken, Task> executeAsync, Func<IDeviceActionContext, bool> canExecute) : base(deviceContext)
    {
        _logger = logger;
        _executeAsync = executeAsync;
        _canExecute = canExecute;
    }

    public async Task Execute(CancellationToken cancelToken)
    {
        _logger.LogInformation(ExecutionInfo);

        if (CanExecute(cancelToken))
        {
            try
            {
                await _executeAsync(DeviceContext, cancelToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ExecutionError);
                throw;
            }
        }
        else
        {
            _logger.LogError(ExecutionBlockedError);
            throw new Exception(ExecutionBlockedError);
        }
    }

    public bool CanExecute(CancellationToken cancelToken)
    {
        try
        {
            return !Locked && _canExecute(DeviceContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}

/// <summary>
/// Command class for handling asynchrounus device actions with 1 parameter.
/// </summary>
public class DeviceActionAsync<T1> : BasicDeviceAction, IDeviceActionAsync<T1>
{
    private readonly ILogger _logger;
    private readonly Func<IDeviceActionContext, T1, CancellationToken, Task> _executeAsync;
    private readonly Func<IDeviceActionContext, bool> _canExecute;

    public DeviceActionAsync(IDeviceActionContext deviceContext, ILogger logger, Func<IDeviceActionContext, T1, CancellationToken, Task> executeAsync, Func<IDeviceActionContext, bool> canExecute) : base(deviceContext)
    {
        _logger = logger;
        _executeAsync = executeAsync;
        _canExecute = canExecute;
    }

    public async Task Execute(T1 param1, CancellationToken cancelToken)
    {
        var additionalLogText = $" With Parameter {param1}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1, cancelToken))
        {
            try
            {
                await _executeAsync(DeviceContext, param1, cancelToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ExecutionError + additionalLogText);
                throw;
            }
        }
        else
        {
            _logger.LogError(ExecutionBlockedError + additionalLogText);
            throw new Exception(ExecutionBlockedError + additionalLogText);
        }
    }

    public bool CanExecute(T1 param1, CancellationToken cancelToken)
    {
        try
        {
            return !Locked && _canExecute(DeviceContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}

/// <summary>
/// Command class for handling asynchrounus device actions with 2 parameter.
/// </summary>
public class DeviceActionAsync<T1, T2> : BasicDeviceAction, IDeviceActionAsync<T1, T2>
{
    private readonly ILogger _logger;
    private readonly Func<IDeviceActionContext, T1, T2, CancellationToken, Task> _executeAsync;
    private readonly Func<IDeviceActionContext, bool> _canExecute;

    public DeviceActionAsync(IDeviceActionContext deviceContext, ILogger logger, Func<IDeviceActionContext, T1, T2, CancellationToken, Task> executeAsync, Func<IDeviceActionContext, bool> canExecute) : base(deviceContext)
    {
        _logger = logger;
        _executeAsync = executeAsync;
        _canExecute = canExecute;
    }

    public async Task Execute(T1 param1, T2 param2, CancellationToken cancelToken)
    {
        var additionalLogText = $" With Parameters {param1}, {param2}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1, param2, cancelToken))
        {
            try
            {
                await _executeAsync(DeviceContext, param1, param2, cancelToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ExecutionError + additionalLogText);
                throw;
            }
        }
        else
        {
            _logger.LogError(ExecutionBlockedError + additionalLogText);
            throw new Exception(ExecutionBlockedError + additionalLogText);
        }
    }

    public bool CanExecute(T1 param1, T2 param2, CancellationToken cancelToken)
    {
        try
        {
            return !Locked && _canExecute(DeviceContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}