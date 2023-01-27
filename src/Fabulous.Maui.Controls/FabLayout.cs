using System.Collections;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui.Controls;

public interface IFabLayout : ILayout, IFabView, IFabContainer, IFabSafeAreaView, IFabPadding
{
    new bool ClipsToBounds { get; set; }
}

public abstract partial class FabLayout: FabView, IFabLayout
{
    private readonly List<IView> _children = new();
    private ILayoutManager? _layoutManager;

    protected abstract ILayoutManager CreateLayoutManager();
    private ILayoutManager LayoutManager => _layoutManager ??= CreateLayoutManager();

    public IEnumerator<IView> GetEnumerator() => _children.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _children.GetEnumerator();

    public void Add(IView view)
    {
        var index = _children.Count;
        _children.Add(view);
        Handler?.Invoke(nameof(ILayoutHandler.Add), new LayoutHandlerUpdate(index, view));
    }

    public void Clear()
    {
        _children.Clear();
        Handler?.Invoke(nameof(ILayoutHandler.Clear));
    }

    public bool Contains(IView item) => _children.Contains(item);
    public void CopyTo(IView[] array, int arrayIndex) => _children.CopyTo(array, arrayIndex);

    public bool Remove(IView view)
    {
        var index = _children.IndexOf(view);
        var result = _children.Remove(view);
        Handler?.Invoke(nameof(ILayoutHandler.Remove), new LayoutHandlerUpdate(index, view));
        return result;
    }

    public int Count => _children.Count;
    public bool IsReadOnly => true;
    public int IndexOf(IView item) => _children.IndexOf(item);

    public void Insert(int index, IView view)
    {
        _children.Insert(index, view);
        Handler?.Invoke(nameof(ILayoutHandler.Insert), new LayoutHandlerUpdate(index, view));
    }

    public void RemoveAt(int index)
    {
        var view = _children[index];
        _children.RemoveAt(index);
        Handler?.Invoke(nameof(ILayoutHandler.Remove), new LayoutHandlerUpdate(index, view));
    }

    public IView this[int index]
    {
        get => _children[index];
        set
        {
            _children[index] = value;
            Handler?.Invoke(nameof(ILayoutHandler.Update), new LayoutHandlerUpdate(index, value));
        }
    }

    public bool IgnoreSafeArea { get; set; } = SafeAreaViewDefaults.IgnoreSafeArea;
    public Thickness Padding { get; set; } = PaddingDefaults.CreateDefaultPadding();
    public bool ClipsToBounds { get; set; } = LayoutDefaults.ClipsToBounds;

    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        return base.Measure(widthConstraint - Padding.HorizontalThickness, heightConstraint - Padding.VerticalThickness);
    }

    public override void InvalidateMeasure()
    {
        base.InvalidateMeasure();

        foreach (var child in this)
        {
            child.InvalidateMeasure();
        }
    }

    public Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
    {
        return LayoutManager.Measure(widthConstraint, heightConstraint);
    }

    public Size CrossPlatformArrange(Rect bounds)
    {
        return LayoutManager.ArrangeChildren(bounds);
    }
}

public partial class FabLayout
{
    public static void SetClipsToBounds(IFabLayout target, bool value) => target.ClipsToBounds = value;
}