using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class FabNavigationViewHandler
{
    public static void FabRequestNavigation(INavigationViewHandler handler, IStackNavigation stackNavigation, object? args)
    {
        RequestNavigation(handler, stackNavigation, args);
    }
}