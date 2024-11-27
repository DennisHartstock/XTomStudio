using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Backbone;

namespace XTomStudio.Core.Contracts.Communication;


public interface IRemoteExecution
{
    Task ExecuteAsync(IDeviceActionContext deviceContext, CancellationToken cancelToken);

    Task<Tout> ExecuteAsync<Tout>(IDeviceActionContext deviceContext, CancellationToken cancelToken);

    Task ExecuteAsync<T1>(IDeviceActionContext deviceContext, T1 param1, CancellationToken cancelToken);

    Task<Tout> ExecuteAsync<T1, Tout>(IDeviceActionContext deviceContext, T1 param1, CancellationToken cancelToken);

    Task ExecuteAsync<T1, T2>(IDeviceActionContext deviceContext, T1 param1, T2 param2, CancellationToken cancelToken);

    Task<Tout> ExecuteAsync<T1, T2, Tout>(IDeviceActionContext deviceContext, T1 param1, T2 param2, CancellationToken cancelToken);

    bool CanExecute(IDeviceActionContext deviceContext);
}
