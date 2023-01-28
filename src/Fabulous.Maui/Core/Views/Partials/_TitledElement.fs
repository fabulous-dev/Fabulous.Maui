namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module TitledElement =
    let Title =
        Attributes.defineMauiProperty "Title" TitledElementDefaults.Title (fun (target: IFabTitledElement) -> target.SetTitle)
