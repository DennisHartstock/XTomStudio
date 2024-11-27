using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XTomStudio.Core.Contracts.Backbone;

namespace XTomStudio.Core.Backbone;

/// <summary>
/// Command class for handling device actions with return value.
/// </summary>
public class DeviceFunction<Tout> : BasicDeviceAction, IDeviceFunction<Tout>
{
    private readonly ILogger _logger;
    private readonly Func<Tout> _execute;
    private readonly Func<bool>? _canExecute;

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<Tout> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<Tout> execute, Func<bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public Tout Execute()
    {
        _logger.LogInformation(ExecutionInfo);

        if (CanExecute())
        {
            try
            {
                return _execute.Invoke();
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
/// Command class for handling device actions with return value and 1 input parameter.
/// </summary>
public class DeviceFunction<T1, Tout> : BasicDeviceAction, IDeviceFunction<T1, Tout>
{
    private readonly ILogger _logger;
    private readonly Func<T1, Tout> _execute;
    private readonly Func<T1, bool>? _canExecute;

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<T1, Tout> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<T1, Tout> execute, Func<T1, bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public Tout Execute(T1 param1)
    {
        var additionalLogText = $" With Parameter {param1}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1))
        {
            try
            {
                return _execute.Invoke(param1);
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
/// Command class for handling device functions with return value and 2 input parameter.
/// </summary>
public class DeviceFunction<T1, T2, Tout> : BasicDeviceAction, IDeviceFunction<T1, T2, Tout>
{
    private readonly ILogger _logger;
    private readonly Func<T1, T2, Tout> _execute;
    private readonly Func<T1, T2, bool>? _canExecute;

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<T1, T2, Tout> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<T1, T2, Tout> execute, Func<T1, T2, bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public Tout Execute(T1 param1, T2 param2)
    {
        var additionalLogText = $" With Parameters {param1}, {param2}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1, param2))
        {
            try
            {
                return _execute.Invoke(param1, param2);
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
/// Command class for handling device functions with return value and 3 input parameter.
/// </summary>
public class DeviceFunction<T1, T2, T3, Tout> : BasicDeviceAction, IDeviceFunction<T1, T2, T3, Tout>
{
    private readonly ILogger _logger;
    private readonly Func<T1, T2, T3, Tout> _execute;
    private readonly Func<T1, T2, T3, bool>? _canExecute;

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<T1, T2, T3, Tout> execute) : base(deviceContext)
    {
        _logger = logger;
        _execute = execute;
    }

    public DeviceFunction(IDeviceActionContext deviceContext, ILogger logger, Func<T1, T2, T3, Tout> execute, Func<T1, T2, T3, bool> canExecute) : this(deviceContext, logger, execute)
    {
        _canExecute = canExecute;
    }

    public Tout Execute(T1 param1, T2 param2, T3 param3)
    {
        var additionalLogText = $" With Parameters {param1}, {param2}, {param3}.";
        _logger.LogInformation(ExecutionInfo + additionalLogText);

        if (CanExecute(param1, param2, param3))
        {
            try
            {
                return _execute.Invoke(param1, param2, param3);
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
