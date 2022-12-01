namespace Fabulous.Maui

open Fabulous.Maui.Controls

module ContentView =
    let PresentedContent = Attributes.defineMauiPropertyWidget "ContentView_Content" "Content" (fun target -> (target :?> FabContentView).PresentedContent)  (fun target value -> (target :?> FabContentView).PresentedContent <- value)
