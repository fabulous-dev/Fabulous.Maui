using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Microsoft.Maui.FabCompat.Handlers;

public partial class FabLabelHandler : LabelHandler
{
    protected override MauiLabel CreatePlatformView()
    {
        var label =  base.CreatePlatformView();
        label.Lines = 0;
        return label;
    }
}