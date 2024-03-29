namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Controls

type IFabCompatViewCell =
    inherit IFabCompatCell

module ViewCell =
    let WidgetKey = CompatWidgets.register<ViewCell>()

    let View =
        Attributes.definePropertyWidget "ViewCell_View" (fun target -> (target :?> ViewCell).View :> obj) (fun target value ->
            (target :?> ViewCell).View <- value)

[<AutoOpen>]
module ViewCellBuilders =
    type Fabulous.Maui.View with

        static member inline ViewCell(view: WidgetBuilder<'msg, #IFabCompatView>) =
            WidgetHelpers.buildWidgets<'msg, IFabCompatViewCell> ViewCell.WidgetKey [| ViewCell.View.WithValue(view.Compile()) |]

[<Extension>]
type ViewCellModifiers =
    /// <summary>Link a ViewRef to access the direct ViewCell control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatViewCell>, value: ViewRef<ViewCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
