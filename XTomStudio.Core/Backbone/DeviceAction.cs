using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XTomStudio.Core.Contracts.Backbone;

namespace XTomStudio.Core.Backbone;

/// <summary>
/// Command class for handling device actions.
/// </summary>
public class DeviceAction : BasicDeviceAction, IDeviceAction
{
    private readonly ILogger _logger;
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action execute, Func<bool> canExecute) : this(deviceContext, logger, execute)
    {        
        _canExecute = canExecute;
    }

    public void Execute()
    {
        _logger.LogInformation(ExecutionInfo);

        if (CanExecute())
        {
            try
            {
                _execute.Invoke();
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

    public bool CanExecute()
    {
        try
        {
            return !Locked && (_canExecute?.Invoke() ?? true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}

/// <summary>
/// Command class for handling device actions with 1 input parameter.
/// </summary>
public class DeviceAction<T1> : BasicDeviceAction, IDeviceAction<T1>
{
    private readonly ILogger _logger;
    private readonly Action<T1> _execute;
    private readonly Func<T1, bool>? _canExecute;

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action<T1> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action<T1> execute, Func<T1, bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public void Execute(T1 param1)
    {
        var additionalLogText = $" With Parameter {param1}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1))
        {
            try
            {
                _execute.Invoke(param1);
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

    public bool CanExecute(T1 param1)
    {
        try
        {
            return !Locked && (_canExecute?.Invoke(param1) ?? true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}


/// <summary>
/// Command class for handling device actions with 2 input parameter.
/// </summary>
public class DeviceAction<T1, T2> : BasicDeviceAction, IDeviceAction<T1, T2>
{
    private readonly ILogger _logger;
    private readonly Action<T1, T2> _execute;
    private readonly Func<T1, T2, bool>? _canExecute;

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action<T1, T2> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action<T1, T2> execute, Func<T1, T2, bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public void Execute(T1 param1, T2 param2)
    {
        var additionalLogText = $" With Parameters {param1}, {param2}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1, param2))
        {
            try
            {
                _execute.Invoke(param1, param2);
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

    public bool CanExecute(T1 param1, T2 param2)
    {
        try
        {
            return !Locked && (_canExecute?.Invoke(param1, param2) ?? true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}


/// <summary>
/// Command class for handling device actions with 3 input parameter.
/// </summary>
public class DeviceAction<T1, T2, T3> : BasicDeviceAction, IDeviceAction<T1, T2, T3>
{
    private readonly ILogger _logger;
    private readonly Action<T1, T2, T3> _execute;
    private readonly Func<T1, T2, T3, bool>? _canExecute;

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action<T1, T2, T3> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceAction(IDeviceActionContext deviceContext, ILogger logger, Action<T1, T2, T3> execute, Func<T1, T2, T3, bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public void Execute(T1 param1, T2 param2, T3 param3)
    {
        var additionalLogText = $" With Parameters {param1}, {param2}, {param3}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1, param2, param3))
        {
            try
            {
                _execute.Invoke(param1, param2, param3);
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

    public bool CanExecute(T1 param1, T2 param2, T3 param3)
    {
        try
        {
            return !Locked && (_canExecute?.Invoke(param1, param2, param3) ?? true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, CanExecuteError);
            throw;
        }
    }
}