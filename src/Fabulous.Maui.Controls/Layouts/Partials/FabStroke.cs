using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Fabulous.Maui
{
    public interface IFabStroke: IStroke
    {
        void SetStroke(Paint? value);
        void SetStrokeThickness(double value);
        void SetStrokeLineCap(LineCap value);
        void SetStrokeLineJoin(LineJoin value);
        void SetStrokeDashPattern(float[] value);
        void SetStrokeDashOffset(float value);
        void SetStrokeMiterLimit(float value);
    }
}