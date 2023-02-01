namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults

module BorderStroke =
    let Shape =
        Attributes.defineMauiProperty "Shape" BorderStrokeDefaults.Shape (fun (target: IFabBorderStroke) -> target.SetShape)

