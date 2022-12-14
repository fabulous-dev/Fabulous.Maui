using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public interface IFabScrollView : IScrollView
{
    Action? OnScrollFinished { get; set; }
    new ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }
    new ScrollBarVisibility VerticalScrollBarVisibility { get; set; }
    new ScrollOrientation Orientation { get; set; }
    new Size ContentSize { get; set; }
    new double HorizontalOffset { get; set; }
    new double VerticalOffset { get; set; }
}

public partial class FabScrollView: FabContentView, IFabScrollView
{
    public Action? OnScrollFinished { get; set; } = ScrollViewDefaults.OnScrollFinished;
    public void ScrollFinished() => OnScrollFinished?.Invoke();
    
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

public partial class FabScrollView
{
    public static void SetOnScrollFinished(IFabScrollView target, Action? value) => target.OnScrollFinished = value;
    public static void SetHorizontalScrollBarVisibility(IFabScrollView target, ScrollBarVisibility value) => target.HorizontalScrollBarVisibility = value;
    public static void SetVerticalScrollBarVisibility(IFabScrollView target, ScrollBarVisibility value) => target.VerticalScrollBarVisibility = value;
    public static void SetOrientation(IFabScrollView target, ScrollOrientation value) => target.Orientation = value;
    public static void SetHorizontalOffset(IFabScrollView target, double value) => target.HorizontalOffset = value;
    public static void SetVerticalOffset(IFabScrollView target, double value) => target.VerticalOffset = value;
    public static void SetContentSize(IFabScrollView target, Size value) => target.ContentSize = value;
}