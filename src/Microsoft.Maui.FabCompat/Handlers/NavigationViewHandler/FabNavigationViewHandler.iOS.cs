using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class FabNavigationViewHandler
{
    StackNavigationManager? _stackNavigationManager;
    internal StackNavigationManager? StackNavigationManager => _stackNavigationManager;

    StackNavigationManager CreateNavigationManager()
    {
        return _stackNavigationManager ??= new StackNavigationManager();
    }

    protected override void ConnectHandler(UIView platformView)
    {
        base.ConnectHandler(platformView);
        
        var stackNavigationManager = CreateNavigationManager();
        stackNavigationManager.Connect(platformView);
    }

    public static void FabRequestNavigation(INavigationViewHandler handler, IStackNavigation stackNavigation, object? args)
    {
        if (handler is FabNavigationViewHandler { StackNavigationManager: { } } navHandler && args is NavigationRequest request)
            navHandler.StackNavigationManager.RequestNavigation(request);
    }
}

public class StackNavigationManager
{
    public void Connect(UIView platformView)
    {
        // TODO
    }

    public void RequestNavigation(NavigationRequest args)
    {
        // TODO
    }
}
