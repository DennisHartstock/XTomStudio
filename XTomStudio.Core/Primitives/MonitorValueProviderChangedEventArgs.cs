using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Primitives;
public class MonitorValueProviderChangedEventArgs<T> : EventArgs
{
    public T Value
    {
        get;
    }

    public T Setpoint
    {
        get;
    }

    public T MinValue
    {
        get;
    }

    public T MaxValue
    {
        get;
    }

    public T PhysicalMinValue
    {
        get;
    }

    public T PhysicalMaxValue
    {
        get;
    }

    public MonitorValueProviderChangedEventArgs(T value, T valueSetpoint, T minValue, T maxValue, T physicalMinValue, T physicalMaxValue)
    {
        this.Value = value;
        this.Setpoint = valueSetpoint;
        this.MinValue = minValue;
        this.MaxValue = maxValue;
        this.PhysicalMinValue = physicalMinValue;
        this.PhysicalMaxValue = physicalMaxValue;
    }
}
