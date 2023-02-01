using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui
{
    public interface IFabBorderStroke: IBorderStroke, IFabStroke
    {
        void SetShape(IShape? value);
    }
}