using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public class FabContentView: FabView, IContentView, IPaddingSetter
{
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    
    public virtual Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
    {
        return this.MeasureContent(widthConstraint, heightConstraint);
    }

    public virtual Size CrossPlatformArrange(Rect bounds)
    {
        this.ArrangeContent(bounds);
        return bounds.Size;
    }

    public object? Content { get; set; }

    private IView? _presentedContent;
    public IView? PresentedContent
    {
        get => _presentedContent ?? Content as IView;
        set => _presentedContent = value;
    }

    public void SetPadding(Thickness value) => Padding = value;
}