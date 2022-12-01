using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

/*
    Initially the idea was to store directly inside the Maui control the AttributesBundle generated during the creation of the widget,
    except this bundle is a struct and assigning it to a class (reference type) will force it to move the heap
    using a lot of memory. This is especially bad since it actually holds the whole hierarchy of child widgets.
    
    To avoid this, each Fabulous implementation of Maui controls needs to define writable properties that will be
    updated during diffing. Even events are to be defined as properties holding a function.
*/

public abstract class FabElement: IElement
{
    private IElementHandler? _handler;
    
    // Will be set by Fabulous right after calling the constructor
    public IViewNode ViewNode { get; set; } = null!;
    public IElement? Parent { get; set; } = null;

    private IElementHandler? _previousHandler;
    public IElementHandler? Handler
    {
        get => _handler;
        set
        {
            if (value == _handler)
                return;

            try
            {
                // If a handler is getting changed before the end of this method
                // Something is wired up incorrectly
                if (_previousHandler != null)
                    throw new InvalidOperationException("Handler is already being set elsewhere");

                _previousHandler = _handler;
                _handler = value;

                // Only call disconnect if the previous handler is still connected to this virtual view.
                // If a handler is being reused for a different VirtualView then the virtual
                // view would have already rolled 
                if (_previousHandler?.VirtualView == this)
                    _previousHandler?.DisconnectHandler();

                if (_handler?.VirtualView != this)
                    _handler?.SetVirtualView(this);
            }
            finally
            {
                _previousHandler = null;
            }
        }
    }
}