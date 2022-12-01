namespace Fabulous.Maui

open Microsoft.Maui
open Fabulous.Maui.Controls

module ImageSourcePart =
    let Source = Attributes.defineMauiSimpleScalarWithEquality "ImageSourcePart_Source" "Source" (fun _ (currOpt: IImageSource voption) target ->
        let target = unbox<IImageSourcePartSetter> target
        match currOpt with
        | ValueNone -> target.SetSource(ImageSourcePartDefaults.Source)
        | ValueSome curr -> target.SetSource(curr)
    )

