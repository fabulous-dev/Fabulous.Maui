using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public static class ScrollViewDefaults
{
    public const Action? OnScrollFinished = null;
    public const ScrollBarVisibility HorizontalScrollBarVisibility = ScrollBarVisibility.Default;
    public const ScrollBarVisibility VerticalScrollBarVisibility = ScrollBarVisibility.Default;
    public const ScrollOrientation Orientation = ScrollOrientation.Vertical;
    public const double HorizontalOffset = 0.0;
    public const double VerticalOffset = 0.0;
    public static Size CreateContentSize() => Size.Zero;
}

public class FabScrollView: FabContentView, IScrollView
{
    public Action? OnScrollFinsihed { get; set; } = ScrollViewDefaults.OnScrollFinished;
    public void ScrollFinished() => OnScrollFinsihed?.Invoke();
    
    public void RequestScrollTo(double horizontalOffset, double verticalOffset, bool instant)
    {
        var request = new ScrollToRequest(horizontalOffset, verticalOffset, instant);
        Handler?.Invoke(nameof(IScrollView.RequestScrollTo), request);
    }

    public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; } = ScrollViewDefaults.HorizontalScrollBarVisibility;
    public ScrollBarVisibility VerticalScrollBarVisibility { get; set; } = ScrollViewDefaults.VerticalScrollBarVisibility;
    public ScrollOrientation Orientation { get; set; } = ScrollViewDefaults.Orientation;
    public Size ContentSize { get; set; } = ScrollViewDefaults.CreateContentSize();
    public double HorizontalOffset { get; set; } = ScrollViewDefaults.HorizontalOffset;
    public double VerticalOffset { get; set; } = ScrollViewDefaults.VerticalOffset;

    public override Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
    {
        if ((this as IContentView).PresentedContent is not { } content)
        {
            ContentSize = Size.Zero;
            return ContentSize;
        }

        switch (Orientation)
        {
            case ScrollOrientation.Horizontal:
                widthConstraint = double.PositiveInfinity;
                break;
            case ScrollOrientation.Neither:
            case ScrollOrientation.Both:
                heightConstraint = double.PositiveInfinity;
                widthConstraint = double.PositiveInfinity;
                break;
            case ScrollOrientation.Vertical:
            default:
                heightConstraint = double.PositiveInfinity;
                break;
        }

        content.Measure(widthConstraint, heightConstraint);
        return content.DesiredSize;
    }

    public override Size CrossPlatformArrange(Rect bounds)
    {
        if ((this as IContentView).PresentedContent is { } presentedContent)
        {
            var padding = Padding;

            // Normally we'd just want the content to be arranged within the ContentView's Frame,
            // but ScrollView content might be larger than the ScrollView itself (for obvious reasons)
            // So in each dimension, we assume the larger of the two values.
            bounds.Width = Math.Max(bounds.Width, presentedContent.DesiredSize.Width + padding.HorizontalThickness);
            bounds.Height = Math.Max(bounds.Height, presentedContent.DesiredSize.Height + padding.VerticalThickness);

            this.ArrangeContent(bounds);
        }

        return bounds.Size;
    }
}