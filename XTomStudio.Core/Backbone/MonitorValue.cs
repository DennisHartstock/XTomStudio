using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Core.Backbone;

/// <summary>
/// Class for monitoring values from remote system.
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonitorValue<T> : IObserver<MonitorValueUpdate<T>>
{
    private readonly IDisposable _unregister;

    public event EventHandler<MonitorValueChangedEventArgs<T>>? MonitorValueChanged;

    public T RecentValue { get;  private set; }

    public T PreviousValue { get; private set; }

    public T RecentSetpoint { get; private set; }

    public T PreviousSetpoint { get; private set; }

    public T MinValue { get; private set; }

    public T MaxValue { get; private set; }

    public T PhysicalMinValue { get; private set; }

    public T PhysicalMaxValue { get; private set; }


    public MonitorValue(string deviceId, string monitorName, IMonitorValueProvider valueProvider, T startValue)
    {
        RecentValue = startValue;
        PreviousValue = startValue;
        RecentSetpoint = startValue;
        PreviousSetpoint = startValue;
        MinValue = startValue;
        MaxValue = startValue;
        PhysicalMinValue = startValue;
        PhysicalMaxValue = startValue;

        _unregister = valueProvider.Register(deviceId, monitorName, this);
    }

    public MonitorValue(string deviceId, string monitorName, IMonitorValueProvider valueProvider, T startValue, T startValueSetpoint) : this(deviceId, monitorName, valueProvider, startValue)
    {
        PreviousSetpoint = RecentSetpoint;
        RecentSetpoint = startValueSetpoint;
    }

    public MonitorValue(string deviceId, string monitorName, IMonitorValueProvider valueProvider, T startValue, T startValueSetpoint, T minValue, T maxValue) : this(deviceId, monitorName, valueProvider, startValue, startValueSetpoint)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public MonitorValue(string deviceId, string monitorName, IMonitorValueProvider valueProvider, T startValue, T startValueSetpoint, T minValue, T maxValue, T physicalMinValue, T physicalMaxValue) : this(deviceId, monitorName, valueProvider, startValue, startValueSetpoint, minValue, maxValue)
    {
        PhysicalMinValue = physicalMinValue;
        PhysicalMaxValue = physicalMaxValue;
    }

    private void OnValueChanged()
    {
        MonitorValueChanged?.Invoke(this, new MonitorValueChangedEventArgs<T>(RecentValue, RecentSetpoint, PreviousValue, PreviousSetpoint, MinValue, MaxValue, PhysicalMinValue, PhysicalMaxValue));
    }

    /// <summary>
    /// Refires ValueChanged, MinValueChanged, MaxValueChanged and ValueSetpointChanged events
    /// </summary>
    public void Refresh()
    {
        OnValueChanged();
    }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();

    public void OnNext(MonitorValueUpdate<T> value)
    {
        PreviousValue = RecentValue;
        PreviousSetpoint = RecentSetpoint;
        RecentValue = value.Value;
        RecentSetpoint = value.ValueSetpoint;
        MinValue = value.MinValue;
        MaxValue = value.MaxValue;
        PhysicalMinValue = value.PhysicalMinValue;
        PhysicalMaxValue = value.PhysicalMaxValue;
        OnValueChanged();
    }
}
