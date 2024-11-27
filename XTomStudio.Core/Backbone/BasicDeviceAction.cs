using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XTomStudio.Core.Contracts.Backbone;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Backbone;
public class BasicDeviceAction : IBasicDeviceAction
{
    private bool _locked;

    protected string ExecutionInfo => $"Executing {Name} of device {DeviceContext.DeviceId}.";
    protected string ExecutionError => $"Error during execution {Name} of device {DeviceContext.DeviceId}.";
    protected string ExecutionBlockedError => $"Cannot execute action {Name} of device {DeviceContext.DeviceId}. The execution was blocked.";
    protected string CanExecuteError => $"Error during {Name}.CanExecution() of device {DeviceContext.DeviceId}.";

    protected IDeviceActionContext DeviceContext { get; }

    public string Name { get; }

    public event EventHandler<CanExecuteChangedEventArgs>? CanExecuteChanged;

    public bool Locked
    {
        get => _locked;
        protected set
        {
            if (value != _locked)
            {
                _locked = value;
                CanExecuteChanged?.Invoke(this, new CanExecuteChangedEventArgs(_locked));
            }
        }
    }

    public BasicDeviceAction(IDeviceActionContext deviceContext)
    {
        DeviceContext = deviceContext;
        Name = deviceContext.DeviceActionName;
    }

    protected void LogExecutionError(ILogger logger, Exception ex)
    {
        logger.LogError(ex, $"Error during execution {Name} of device {DeviceContext.DeviceId}.");
    }
}
