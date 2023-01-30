using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabSlider : ISlider, IFabRange
    {
        void SetOnDragStarted(Action? value);
        void SetOnDragCompleted(Action? value);
        void SetMinimumTrackColor(Color value);
        void SetMaximumTrackColor(Color value);
        void SetThumbColor(Color value);
        void SetThumbImageSource(IImageSource value);
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabSlider : FabRange, IFabSlider
    {
        private Action? OnDragStarted { get; set; } = SliderDefaults.OnDragStarted;
        public void DragStarted() => OnDragStarted?.Invoke();

        private Action? OnDragCompleted { get; set; } = SliderDefaults.OnDragCompleted;
        public void DragCompleted() => OnDragCompleted?.Invoke();

        public Color MinimumTrackColor { get; private set; } = SliderDefaults.MinimumTrackColor;
        public Color MaximumTrackColor { get; private set; } = SliderDefaults.MaximumTrackColor;
        public Color ThumbColor { get; private set; } = SliderDefaults.ThumbColor;
        public IImageSource ThumbImageSource { get; private set; } = SliderDefaults.ThumbImageSource;


        public void SetOnDragStarted(Action? value) => OnDragStarted = value;
        public void SetOnDragCompleted(Action? value) => OnDragCompleted = value;
        public void SetMinimumTrackColor(Color value) => MinimumTrackColor = value;
        public void SetMaximumTrackColor(Color value) => MaximumTrackColor = value;
        public void SetThumbColor(Color value) => ThumbColor = value;
        public void SetThumbImageSource(IImageSource value) => ThumbImageSource = value;
    }
}