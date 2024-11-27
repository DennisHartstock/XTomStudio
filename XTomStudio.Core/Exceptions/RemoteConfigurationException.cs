using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Exceptions;

[Serializable]
public class RemoteConfigurationException : Exception
{
    public RemoteConfigurationException()
    {

    }
    public RemoteConfigurationException(string message) : base(message) 
    {
        
    }

    public RemoteConfigurationException(string message, Exception inner) : base(message, inner) 
    {

    }

    protected RemoteConfigurationException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) 
    {

    }
}
