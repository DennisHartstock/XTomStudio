using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.CtConfiguration;

namespace XTomStudio.Core.Models;
public class RemoteCtConfiguration
{
    public RemoteCtDetector XrayDetector { get; }

	public RemoteCtSource XraySource { get; }

	public Dictionary<string, RemoteCtAxis> AxisConfigurations { get; }

	//public IEnumerable<RemoteTrajectoryConfiguration> TrajectoryConfigurations
 //   {
 //       get;
 //   }

    public RemoteCtConfiguration(RemoteCtDetector xrayDetector, RemoteCtSource xraySource, Dictionary<string, RemoteCtAxis> axisConfigurations)
    {
        XrayDetector = xrayDetector;
        XraySource = xraySource;
        AxisConfigurations = axisConfigurations;
    }

    public MonitorValue<T>? GetMonitorValue<T>(string deviceString)
    {
        var splits = deviceString?.Split('.');
        PropertyInfo? propInfo;

        if (splits != null && splits.Length > 1)
        {
            switch (splits[0])
            {
                case "XrayDetector":
                    propInfo = typeof(RemoteCtDetector).GetProperty(splits[1]);
                    return propInfo?.GetValue(XrayDetector) as MonitorValue<T>;
                case "XraySource":
                    propInfo = typeof(RemoteCtSource).GetProperty(splits[1]);
                    return propInfo?.GetValue(XraySource) as MonitorValue<T>;
                default:
                    if (AxisConfigurations.ContainsKey(splits[0]))
                    {
                        propInfo = typeof(RemoteCtAxis).GetProperty(splits[1]);
                        return propInfo?.GetValue(AxisConfigurations[splits[0]]) as MonitorValue<T>;
                    }
                    break;
            }
        }

        return null;
    }
}
