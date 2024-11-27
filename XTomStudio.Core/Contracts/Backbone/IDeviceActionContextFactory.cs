using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Contracts.Backbone;
public interface IDeviceActionContextFactory
{
    /// <summary>
    /// Creates device action context.
    /// </summary>
    /// <param name="deviceId">Unique device identifier.</param>
    /// <param name="deviceActionName">Name of device action.</param>
    /// <returns></returns>
    IDeviceActionContext CreateContext(string deviceId, string deviceActionName);
}
