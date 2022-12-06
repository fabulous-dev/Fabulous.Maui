using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabSwitch : ISwitch, IFabTransform
{
    Action<bool>? OnIsOnChanged { get; set; }
    new Color TrackColor { get; set; }
    new Color ThumbColor { get; set; }
}

public partial class FabSwitch: FabView, IFabSwitch
{
    private bool _isOn = SwitchDefaults.IsOn;
    
    public Action<bool>? OnIsOnChanged { get; set; } = SwitchDefaults.OnIsOnChanged;

    public bool IsOn
    {
        get => _isOn;
        set
        {
            if (_isOn == value)
                return;

            _isOn = value;
            OnIsOnChanged?.Invoke(value);
        }
    }
    
    public Color ThumbColor { get; set; } = SwitchDefaults.ThumbColor;
    public Color TrackColor { get; set; } = SwitchDefaults.TrackColor;
}

public partial class FabSwitch
{
    public static void SetIsOn(IFabSwitch target, bool value, Action<bool>? evt)
    {
        target.OnIsOnChanged = null;
        target.IsOn = value;
        target.OnIsOnChanged = evt;
    }
    public static void SetThumbColor(IFabSwitch target, Color? value) => target.ThumbColor = value;
    public static void SetTrackColor(IFabSwitch target, Color? value) => target.TrackColor = value;
}