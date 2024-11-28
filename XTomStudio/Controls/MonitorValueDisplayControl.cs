using XTomStudio.Core.Backbone;

namespace XTomStudio.Controls
{
    public class MonitorValueDisplayControl<T> : ContentView
    {
        private MonitorValue<T>? _monitorValue;
        private readonly IDispatcher _dispatcher;

        #region Bindable Properties

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MonitorValueDisplayControl<T>), null);

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(string), typeof(MonitorValueDisplayControl<T>), null);

        public string MonitorValue
        {
            get => (string)GetValue(MonitorValueProperty);
            set => SetValue(MonitorValueProperty, value);
        }

        public static readonly BindableProperty MonitorValueProperty =
            BindableProperty.Create(nameof(MonitorValue), typeof(string), typeof(MonitorValueDisplayControl<T>), null, propertyChanged: (bindable, oldValue, newValue) =>
            {
                var ctrl = (MonitorValueDisplayControl<T>)bindable;
                //ctrl.OnConfigurationChanged(ctrl.RemoteClient.RemoteCtConfiguration);
            });

        public double TextWidth
        {
            get => (double)GetValue(TextWidthProperty);
            set => SetValue(TextWidthProperty, value);
        }

        public static readonly BindableProperty TextWidthProperty =
            BindableProperty.Create(nameof(TextWidth), typeof(double), typeof(MonitorValueDisplayControl<T>), 70.0);

        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

        public static readonly BindableProperty UnitProperty =
            BindableProperty.Create(nameof(Unit), typeof(string), typeof(MonitorValueDisplayControl<T>), null);

        public T RawValue
        {
            get => (T)GetValue(RawValueProperty);
            set => SetValue(RawValueProperty, value);
        }

        public static readonly BindableProperty RawValueProperty =
            BindableProperty.Create(nameof(RawValue), typeof(T), typeof(MonitorValueDisplayControl<T>), default(T));

        #endregion

        //public MonitorValueDisplayControl()
        //{
        //    _dispatcher = Dispatcher.GetForCurrentThread();
        //}

        private void OnConfigurationChanged(object configuration)
        {
            _dispatcher.Dispatch(() =>
            {
                // Hier kannst du den Code hinzufügen, der bei einer Konfigurationsänderung ausgeführt werden soll
            });
        }
    }
}


//protected override void OnConfigurationChanged(RemoteCtConfiguration? configuration)
//{
//    base.OnConfigurationChanged(configuration);

//    if (configuration == null)
//        return;

//    if (_monitorValue != null)
//        _monitorValue.MonitorValueChanged -= MonitorValue_MonitorValueChanged;

//    _monitorValue = configuration.GetMonitorValue<T>(MonitorValue);

//    if (_monitorValue != null)
//    {
//        MonitorValueChanged(_monitorValue.RecentValue);
//        _monitorValue.MonitorValueChanged += MonitorValue_MonitorValueChanged;
//    }
//}

//private void MonitorValue_MonitorValueChanged(object? sender, Core.Primitives.MonitorValueChangedEventArgs<T> e)
//{
//    _dispatcherQueue.TryEnqueue(() =>
//    {
//        MonitorValueChanged(e.NewValue);
//    });
//}

//private void MonitorValueChanged(T newValue)
//{
//    RawValue = newValue;
//    ConvertToValue(newValue);
//}

//protected virtual void ConvertToValue(T newValue)
//{
//    Value = Convert.ToString(newValue) ?? "";
//}