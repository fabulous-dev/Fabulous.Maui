using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui.Controls;

public interface IFabButtonStroke: IButtonStroke
{
    new Color StrokeColor { get; set; }
    new double StrokeThickness { get; set; }
    new int CornerRadius { get; set; }
}

public static class FabButtonStrokeSetters
{
    public static void SetStrokeColor(FabElement target, Color value) => ((IFabButtonStroke)target).StrokeColor = value;
    public static void SetStrokeThickness(FabElement target, double value) => ((IFabButtonStroke)target).StrokeThickness = value;
    public static void SetCornerRadius(FabElement target, int value) => ((IFabButtonStroke)target).CornerRadius = value;
}