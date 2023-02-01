using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers.Defaults;

namespace Fabulous.Maui
{
    public interface IFabBorderView : IBorderView, IFabContentView, IFabBorderStroke
    {
        
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabBorderView: FabContentView, IFabBorderView
    {
        public Paint? Stroke { get; private set; } = StrokeDefaults.Stroke;
        public double StrokeThickness { get; private set; } = StrokeDefaults.StrokeThickness;
        public LineCap StrokeLineCap { get; private set; } = StrokeDefaults.StrokeLineCap;
        public LineJoin StrokeLineJoin { get; private set; } = StrokeDefaults.StrokeLineJoin;
        public float[]? StrokeDashPattern { get; private set; } = StrokeDefaults.StrokeDashPattern;
        public float StrokeDashOffset { get; private set; } = StrokeDefaults.StrokeDashOffset;
        public float StrokeMiterLimit { get; private set; } = StrokeDefaults.StrokeMiterLimit;
        public IShape? Shape { get; private set; } = BorderStrokeDefaults.Shape;
        
        public void SetStroke(Paint? value) => Stroke = value;
        public void SetStrokeThickness(double value) => StrokeThickness = value;
        public void SetStrokeLineCap(LineCap value) => StrokeLineCap = value;
        public void SetStrokeLineJoin(LineJoin value) => StrokeLineJoin = value;
        public void SetStrokeDashPattern(float[] value) => StrokeDashPattern = value;
        public void SetStrokeDashOffset(float value) => StrokeDashOffset = value;
        public void SetStrokeMiterLimit(float value) => StrokeMiterLimit = value;
        public void SetShape(IShape? value) => Shape = value;
    }
}