namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module ImageSourcePart =
    let Source = Attributes.defineMauiProperty "Source" ImageSourcePartDefaults.Source (fun (target: IFabImageSourcePart) -> target.SetSource)

