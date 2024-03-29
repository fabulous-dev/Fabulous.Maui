using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui
{
    public interface IFabButtonStroke : IButtonStroke
    {
        void SetStrokeColor(Color value);
        void SetStrokeThickness(double value);
        void SetCornerRadius(int value);
    }
}