using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabRange: IRange, IFabTransform
{
    new double Minimum { get; set; }
    new double Maximum { get; set; }
    Action<double>? OnValueChanged { get; set; }
}

public abstract partial class FabRange : FabView, IFabRange
{
    private double _value = RangeDefaults.Value;

    public double Minimum { get; set; } = RangeDefaults.Minimum;
    public double Maximum { get; set; } = RangeDefaults.Maximum;

    public Action<double>? OnValueChanged { get; set; } = RangeDefaults.OnValueChanged;
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
}

public partial class FabRange
{
    public static void SetMinimumMaximum(IFabRange target, ValueTuple<double, double> value)
    {
        var min = value.Item1;
        var max = value.Item2;

        if (min > target.Maximum)
        {
            target.Maximum = max;
            target.Minimum = min;
        }
        else
        {
            target.Minimum = min;
            target.Maximum = max;
        }
    }
    
    public static void SetValue(IFabRange target, double value, Action<double>? onValueChanged)
    {
        target.OnValueChanged = null;
        target.Value = value;
        target.OnValueChanged = onValueChanged;
    }
}