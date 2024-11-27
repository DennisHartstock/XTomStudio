using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Primitives;
public enum RemoteDeviceState
{
    NotSet,
    NotInitialized,
    Ready,
    Busy,
    Error,
}