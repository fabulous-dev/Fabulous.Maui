namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module TitledElement =
    let Title =
        Attributes.defineMauiSimpleScalarWithEquality' "TitledElement" "Title" TitledElementDefaults.Title FabTitledElementSetters.SetTitle
        