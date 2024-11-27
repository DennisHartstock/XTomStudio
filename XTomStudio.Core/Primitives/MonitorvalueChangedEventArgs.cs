using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Primitives;

public class MonitorValueChangedEventArgs<T> : EventArgs
{
    public T NewValue 
    { 
        get; 
    }

    public T NewValueSetpoint 
    { 
        get; 
    }

    public T OldValue 
    { 
        get; 
    }

    public T OldValueSetpoint 
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

    public MonitorValueChangedEventArgs(T newValue, T newValueSetpoint, T oldValue, T oldValueSetpoint, T minValue, T maxValue, T physicalMinValue, T physicalMaxValue)
    {
        this.NewValue = newValue;
        this.NewValueSetpoint = newValueSetpoint;
        this.OldValue = oldValue;
        this.OldValueSetpoint = oldValueSetpoint;
        this.MinValue = minValue;
        this.MaxValue = maxValue;
        this.PhysicalMinValue = physicalMinValue;
        this.PhysicalMaxValue = physicalMaxValue;
    }
}
