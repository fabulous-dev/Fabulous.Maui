using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui
{
    public interface IFabScrollView : IScrollView, IFabContentView
    {
        void SetOnScrollFinished(Action? value);
        void SetHorizontalScrollBarVisibility(ScrollBarVisibility value);
        void SetVerticalScrollBarVisibility(ScrollBarVisibility value);
        void SetOrientation(ScrollOrientation value);
        void SetContentSize(Size value);
        void SetHorizontalOffset(double value);
        void SetVerticalOffset(double value);
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabScrollView : FabContentView, IFabScrollView
    {
        private Action? OnScrollFinished { get; set; } = ScrollViewDefaults.OnScrollFinished;
        public void ScrollFinished() => OnScrollFinished?.Invoke();

        public void RequestScrollTo(double horizontalOffset, double verticalOffset, bool instant)
        {
            var request = new ScrollToRequest(horizontalOffset, verticalOffset, instant);
            Handler?.Invoke(nameof(IScrollView.RequestScrollTo), request);
        }

        public ScrollBarVisibility HorizontalScrollBarVisibility { get; private set; } =
            ScrollViewDefaults.HorizontalScrollBarVisibility;

        public ScrollBarVisibility VerticalScrollBarVisibility { get; private set; } =
            ScrollViewDefaults.VerticalScrollBarVisibility;

        public ScrollOrientation Orientation { get; private set; } = ScrollViewDefaults.Orientation;
        public Size ContentSize { get; private set; } = ScrollViewDefaults.CreateContentSize();
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
                bounds.Height = Math.Max(bounds.Height,
                    presentedContent.DesiredSize.Height + padding.VerticalThickness);

                this.ArrangeContent(bounds);
            }

            return bounds.Size;
        }


        public void SetOnScrollFinished(Action? value) => OnScrollFinished = value;

        public void SetHorizontalScrollBarVisibility(ScrollBarVisibility value) =>
            HorizontalScrollBarVisibility = value;

        public void SetVerticalScrollBarVisibility(ScrollBarVisibility value) => VerticalScrollBarVisibility = value;
        public void SetOrientation(ScrollOrientation value) => Orientation = value;
        public void SetContentSize(Size value) => ContentSize = value;
        public void SetHorizontalOffset(double value) => HorizontalOffset = value;
        public void SetVerticalOffset(double value) => VerticalOffset = value;
    }
}