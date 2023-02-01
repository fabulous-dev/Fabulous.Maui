namespace Fabulous.Maui.Compatibility

open Fabulous

type IFabCompatLayoutOfView =
    inherit IFabCompatLayout

module CompatLayoutOfView =
    let Children =
        Attributes.defineListWidgetCollection "LayoutOfWidget_Children" (fun target -> (target :?> Microsoft.Maui.Controls.Layout).Children)
