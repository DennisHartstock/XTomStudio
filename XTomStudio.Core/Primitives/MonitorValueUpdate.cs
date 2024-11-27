using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Primitives;
public class MonitorValueUpdate<T>
{
    public T Value
    {
        get;
    }

    public T ValueSetpoint
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

    public MonitorValueUpdate(T value, T valueSetPoint, T minValue, T maxValue, T physicalMinValue, T physicalMaxValue)
    {
        Value = value;
        ValueSetpoint = valueSetPoint;
        MinValue = minValue;
        MaxValue = maxValue;
        PhysicalMinValue = physicalMinValue;
        PhysicalMaxValue = physicalMaxValue;
    }
}
