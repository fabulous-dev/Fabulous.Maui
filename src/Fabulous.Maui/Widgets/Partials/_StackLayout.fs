namespace Fabulous.Maui

open Fabulous.Maui.Controls

module StackLayout =
    let Spacing = Attributes.defineMauiSimpleScalarWithEquality "StackLayout_Spacing" "Spacing" (fun _ currOpt target ->
        let target = target :?> FabStackLayout
        match currOpt with
        | ValueNone -> target.Spacing <- StackLayoutDefaults.Spacing
        | ValueSome spacing -> target.Spacing <- spacing
    )

