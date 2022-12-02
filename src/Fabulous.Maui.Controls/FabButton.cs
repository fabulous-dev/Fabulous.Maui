using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui.Controls;

public interface IFabButton: IButton, IFabPadding, IFabButtonStroke
{
    Action? OnPressed { get; set; }
    Action? OnReleased { get; set; }
    Action? OnClicked { get; set; }
}

public abstract class FabButton : FabView, IFabButton
{
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    public Color StrokeColor { get; set; } = ButtonStrokeDefaults.StrokeColor;
    public double StrokeThickness { get; set; } = ButtonStrokeDefaults.StrokeThickness;
    public int CornerRadius { get; set; } = ButtonStrokeDefaults.CornerRadius;

    public Action? OnPressed { get; set; } = ButtonDefaults.OnPressed;
    public Action? OnReleased { get; set; } = ButtonDefaults.OnReleased;
    public Action? OnClicked { get; set; } = ButtonDefaults.OnClicked;
    
    public void Pressed() => OnPressed?.Invoke();
    public void Released() => OnReleased?.Invoke();
    public void Clicked() => OnClicked?.Invoke();
}

public static class FabButtonSetters
{
    public static void SetOnPressed(FabElement target, Action? value) => ((IFabButton)target).OnPressed = value;
    public static void SetOnReleased(FabElement target, Action? value) => ((IFabButton)target).OnReleased = value;
    public static void SetOnClicked(FabElement target, Action? value) => ((IFabButton)target).OnClicked = value;
}