namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers.Defaults

module BorderStroke =
    let Shape =
        Attributes.defineMauiProperty "Shape" BorderStrokeDefaults.Shape (fun (target: IFabBorderStroke) -> target.SetShape)

[<Extension>]
type BorderStrokeModifiers =
    [<Extension>]
    static member shape(this: WidgetBuilder<'msg, #IFabBorderStroke>, shape: IShape) =
        this.AddScalar(BorderStroke.Shape.WithValue(shape))
