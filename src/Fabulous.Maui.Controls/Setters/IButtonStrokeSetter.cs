using Microsoft.Maui.Graphics;

namespace Fabulous.Maui.Controls;

public static class ButtonStrokeDefaults
{
    public const Color? StrokeColor = null;
    public const double StrokeThickness = -1.0;
    public const int CornerRadius = -1;
}

public interface IButtonStrokeSetter
{
    void SetStrokeColor(Color value);
    void SetStrokeThickness(double value);
    void SetCornerRadius(int value);
}