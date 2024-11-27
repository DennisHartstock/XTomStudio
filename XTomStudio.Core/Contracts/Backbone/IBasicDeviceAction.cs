using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Contracts.Backbone;
public interface IBasicDeviceAction
{
    /// <summary>
    /// Name of device action.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Determines if the action can be executed. False if the action is ready for execution. True if the execution is denied.
    /// </summary>
    bool Locked { get; }

    /// <summary>
    /// Event fires when CanExecute changed.
    /// </summary>
    event EventHandler<CanExecuteChangedEventArgs> CanExecuteChanged;
}
