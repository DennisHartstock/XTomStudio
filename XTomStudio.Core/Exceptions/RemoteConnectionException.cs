using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Exceptions;

[Serializable]
public class RemoteConnectionException : Exception
{
    public RemoteConnectionException()
    {
    }
    public RemoteConnectionException(string message) : base(message) { }
    public RemoteConnectionException(string message, Exception inner) : base(message, inner) { }
    protected RemoteConnectionException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
