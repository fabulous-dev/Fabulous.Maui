using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

/*
    Initially the idea was to store directly inside the Maui control the AttributesBundle generated during the creation of the widget,
    except this bundle is a struct and assigning it to a class (reference type) will force it to move the heap
    using a lot of memory. This is especially bad since it actually holds the whole hierarchy of child widgets.
    
    To avoid this, each Fabulous implementation of Maui controls needs to define writable properties that will be
    updated during diffing. Even events are to be defined as properties holding a function.
*/

/// BaseNode is the base class inherited by all Fabulous-implemented Maui controls.
/// It holds a reference to the ViewNode required by Fabulous.
public abstract class BaseNode
{
    // Will be set by Fabulous right after calling the constructor
    public IViewNode ViewNode { get; set; } = null!;
    public IElement? Parent { get; set; } = null;
    public IElementHandler? Handler { get; set; } = null;
}