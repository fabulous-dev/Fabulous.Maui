using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui.Controls;

public interface IFabButtonStroke: IButtonStroke
{
    new Color StrokeColor { get; set; }
    new double StrokeThickness { get; set; }
    new int CornerRadius { get; set; }
}

public static class FabButtonStroke
{
    public static void SetStrokeColor(IFabButtonStroke target, Color value) => target.StrokeColor = value;
    public static void SetStrokeThickness(IFabButtonStroke target, double value) => target.StrokeThickness = value;
    public static void SetCornerRadius(IFabButtonStroke target, int value) => target.CornerRadius = value;
}