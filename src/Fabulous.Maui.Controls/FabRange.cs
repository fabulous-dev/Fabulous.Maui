using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabRange : IRange, IFabView
    {
        void SetMinimumMaximum(ValueTuple<double, double> value);
        void SetValue(double value, Action<double>? onValueChanged);
    }
}

namespace Fabulous.Maui.Controls
{
    public abstract class FabRange : FabView, IFabRange
    {
        private double _value = RangeDefaults.Value;

        public double Minimum { get; private set; } = RangeDefaults.Minimum;
        public double Maximum { get; private set; } = RangeDefaults.Maximum;

        private Action<double>? OnValueChanged { get; set; } = RangeDefaults.OnValueChanged;

        public double Value
        {
            get => _value;
            set
            {
                if (Math.Abs(_value - value) <= float.Epsilon)
                    return;

                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }

        public void SetMinimumMaximum(ValueTuple<double, double> value)
        {
            var (min, max) = value;

            if (min > Maximum)
            {
                Maximum = max;
                Minimum = min;
            }
            else
            {
                Minimum = min;
                Maximum = max;
            }
        }

        public void SetValue(double value, Action<double>? onValueChanged)
        {
            OnValueChanged = null;
            Value = value;
            OnValueChanged = onValueChanged;
        }
    }
}