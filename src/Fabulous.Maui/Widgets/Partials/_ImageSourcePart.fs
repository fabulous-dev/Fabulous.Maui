namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module ImageSourcePart =
    let Source = Attributes.defineMauiSimpleScalarWithEquality' "ImageSourcePart" "Source" ImageSourcePartDefaults.Source FabImageSourcePartSetters.SetSource

