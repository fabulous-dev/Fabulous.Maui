namespace Fabulous.Maui.Compatibility

open System.Collections.Generic
open Microsoft.Maui.Controls

open Fabulous

type IFabCompatGradientBrush =
    inherit IFabCompatBrush

module GradientBrush =

    let Children =
        Attributes.defineListWidgetCollection "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops :> IList<_>)
