using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabSlider: ISlider, IFabRange
{
    Action? OnDragStarted { get; set; }
    Action? OnDragCompleted { get; set; }
    new Color MinimumTrackColor { get; set; }
    new Color MaximumTrackColor { get; set; }
    new Color ThumbColor { get; set; }
    new IImageSource ThumbImageSource { get; set; }
}

public partial class FabSlider: FabRange, IFabSlider
{
    public Action? OnDragStarted { get; set; } = SliderDefaults.OnDragStarted;
    public void DragStarted() => OnDragStarted?.Invoke();

    public Action? OnDragCompleted { get; set; } = SliderDefaults.OnDragCompleted;
    public void DragCompleted() => OnDragCompleted?.Invoke();

    public Color MinimumTrackColor { get; set; } = SliderDefaults.MinimumTrackColor;
    public Color MaximumTrackColor { get; set; } = SliderDefaults.MaximumTrackColor;
    public Color ThumbColor { get; set; } = SliderDefaults.ThumbColor;
    public IImageSource ThumbImageSource { get; set; } = SliderDefaults.ThumbImageSource;
}

public partial class FabSlider
{
    public static void SetOnDragStarted(IFabSlider target, Action? value) => target.OnDragStarted = value;
    public static void SetOnDragCompleted(IFabSlider target, Action? value) => target.OnDragCompleted = value;
    public static void SetMinimumTrackColor(IFabSlider target, Color value) => target.MinimumTrackColor = value;
    public static void SetMaximumTrackColor(IFabSlider target, Color value) => target.MaximumTrackColor = value;
    public static void SetThumbColor(IFabSlider target, Color value) => target.ThumbColor = value;
    public static void SetThumbImageSource(IFabSlider target, IImageSource value) => target.ThumbImageSource = value;
}