using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui.Controls;

public static class ButtonDefaults
{
    public const Action? OnPressed = null;
    public const Action? OnReleased = null;
    public const Action? OnClicked = null;
}

public abstract class FabButton : FabView, IButton, IButtonStrokeSetter
{
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    public Color StrokeColor { get; set; } = ButtonStrokeDefaults.StrokeColor;
    public double StrokeThickness { get; set; } = ButtonStrokeDefaults.StrokeThickness;
    public int CornerRadius { get; set; } = ButtonStrokeDefaults.CornerRadius;

    public Action? OnPressed { get; set; } = ButtonDefaults.OnPressed;
    public void Pressed() => OnPressed?.Invoke();

    public Action? OnReleased { get; set; } = ButtonDefaults.OnReleased;
    public void Released() => OnReleased?.Invoke();

    public Action? OnClicked { get; set; } = ButtonDefaults.OnClicked;
    public void Clicked() => OnClicked?.Invoke();

    public void SetStrokeColor(Color value) => StrokeColor = value;
    public void SetStrokeThickness(double value) => StrokeThickness = value;
    public void SetCornerRadius(int value) => CornerRadius = value;
}