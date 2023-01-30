using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabSwitch : ISwitch, IFabView
    {
        void SetIsOn(bool value, Action<bool>? onValueChanged);
        void SetTrackColor(Color value);
        void SetThumbColor(Color value);
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabSwitch : FabView, IFabSwitch
    {
        private bool _isOn = SwitchDefaults.IsOn;

        private Action<bool>? OnIsOnChanged { get; set; } = SwitchDefaults.OnIsOnChanged;

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

        public Color ThumbColor { get; private set; } = SwitchDefaults.ThumbColor;
        public Color TrackColor { get; private set; } = SwitchDefaults.TrackColor;


        public void SetIsOn(bool value, Action<bool>? onValueChanged)
        {
            OnIsOnChanged = null;
            IsOn = value;
            OnIsOnChanged = onValueChanged;
        }

        public void SetTrackColor(Color value) => TrackColor = value;
        public void SetThumbColor(Color value) => ThumbColor = value;
    }
}