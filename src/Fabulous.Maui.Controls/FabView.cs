using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Primitives;

namespace Fabulous.Maui.Controls;

public static class ViewDefaults
{
    public const string AutomationId = "";
    public const FlowDirection FlowDirection = Microsoft.Maui.FlowDirection.MatchParent;
    public const LayoutAlignment HorizontalLayoutAlignment = LayoutAlignment.Fill;
    public const LayoutAlignment VerticalLayoutAlignment = LayoutAlignment.Fill;
    public static Semantics CreateDefaultSemantics() => new();
    public const IShape Clip = null!;
    public const IShadow Shadow = null!;
    public const bool IsEnabled = true;
    public const bool IsFocused = false;
    public const Visibility Visibility = Microsoft.Maui.Visibility.Visible;
    public const double Opacity = 1.0;
    public const Paint Background = null!;
    public const double Width = Dimension.Unset;
    public const double MinimumWidth = Dimension.Unset;
    public const double MaximumWidth = Dimension.Maximum;
    public const double Height = Dimension.Unset;
    public const double MinimumHeight = Dimension.Unset;
    public const double MaximumHeight = Dimension.Maximum;
    public static Thickness CreateDefaultMargin() => Thickness.Zero;
    public const int ZIndex = 0;
    public const bool InputTransparent = false;
}

public class FabView: FabElement, IView, ITransformSetter
{
    public Rect Frame { get; set; }
    public Size DesiredSize { get; set; }
    
    public double TranslationX { get; set; } = TransformDefaults.TranslationX;
    public double TranslationY { get; set; } = TransformDefaults.TranslationY;
    public double Scale { get; set; } = TransformDefaults.Scale;
    public double ScaleX { get; set; } = TransformDefaults.ScaleX;
    public double ScaleY { get; set; } = TransformDefaults.ScaleY;
    public double Rotation { get; set; } = TransformDefaults.Rotation;
    public double RotationX { get; set; } = TransformDefaults.RotationX;
    public double RotationY { get; set; } = TransformDefaults.RotationY;
    public double AnchorX { get; set; } = TransformDefaults.AnchorX;
    public double AnchorY { get; set; } = TransformDefaults.AnchorY;
    
    public Size Arrange(Rect bounds)
    {
        Frame = this.ComputeFrame(bounds);
        Handler?.PlatformArrange(Frame);
        return Frame.Size;
    }

    public virtual Size Measure(double widthConstraint, double heightConstraint)
    {
        DesiredSize = this.ComputeDesiredSize(widthConstraint, heightConstraint);
        return DesiredSize;
    }
    
    public virtual void InvalidateMeasure()
    {
        Handler?.Invoke(nameof(InvalidateMeasure));
    }

    public void InvalidateArrange()
    {
        Handler?.Invoke(nameof(InvalidateArrange));
    }

    public bool Focus()
    {
        throw new NotImplementedException();
    }

    public void Unfocus()
    {
        throw new NotImplementedException();
    }

    public string AutomationId { get; set; } = ViewDefaults.AutomationId;
    public FlowDirection FlowDirection { get; set; } = ViewDefaults.FlowDirection;
    public LayoutAlignment HorizontalLayoutAlignment { get; set; } = ViewDefaults.HorizontalLayoutAlignment;
    public LayoutAlignment VerticalLayoutAlignment { get; set; } = ViewDefaults.VerticalLayoutAlignment;
    public Semantics? Semantics { get; set; } = ViewDefaults.CreateDefaultSemantics();
    public IShape? Clip { get; set; } = ViewDefaults.Clip;
    public IShadow? Shadow { get; set; } = ViewDefaults.Shadow;
    public bool IsEnabled { get; set; } = ViewDefaults.IsEnabled;
    public bool IsFocused { get; set; } = ViewDefaults.IsFocused;
    public Visibility Visibility { get; set; } = ViewDefaults.Visibility;
    public double Opacity { get; set; } = ViewDefaults.Opacity;
    public Paint? Background { get; set; } = ViewDefaults.Background;
    public double Width { get; set; } = ViewDefaults.Width;
    public double MinimumWidth { get; set; } = ViewDefaults.MinimumWidth;
    public double MaximumWidth { get; set; } = ViewDefaults.MaximumWidth;
    public double Height { get; set; } = ViewDefaults.Height;
    public double MinimumHeight { get; set; } = ViewDefaults.MinimumHeight;
    public double MaximumHeight { get; set; } = ViewDefaults.MaximumHeight;
    public Thickness Margin { get; set; } = ViewDefaults.CreateDefaultMargin();
    public int ZIndex { get; set; } = ViewDefaults.ZIndex;

    public new IViewHandler? Handler
    {
        get => base.Handler as IViewHandler;
        set => base.Handler = value;
    }
    
    public bool InputTransparent { get; set; } = ViewDefaults.InputTransparent;

    public void SetTranslationX(double value) => TranslationX = value;
    public void SetTranslationY(double value) => TranslationY = value;
    public void SetScale(double value) => Scale = value;
    public void SetScaleX(double value) => ScaleX = value;
    public void SetScaleY(double value) => ScaleY = value;
    public void SetRotation(double value) => Rotation = value;
    public void SetRotationX(double value) => RotationX = value;
    public void SetRotationY(double value) => RotationY = value;
    public void SetAnchorX(double value) => AnchorX = value;
    public void SetAnchorY(double value) => AnchorY = value;
}