using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class FabNavigationViewHandler: Microsoft.Maui.Handlers.NavigationViewHandler
{
    public static CommandMapper<IStackNavigationView, INavigationViewHandler> FabCommandMapper = new(ViewCommandMapper)
    {
        [nameof(IStackNavigation.RequestNavigation)] = FabRequestNavigation
    };

    public FabNavigationViewHandler() : base(Mapper, FabCommandMapper)
    {
    }

    public FabNavigationViewHandler(IPropertyMapper? mapper)
        : base(mapper ?? Mapper, FabCommandMapper)
    {
    }

    public FabNavigationViewHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
        : base(mapper ?? Mapper, commandMapper ?? FabCommandMapper)
    {
    }
}