namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatContentView =
    inherit IFabCompatTemplatedView

module ContentView =
    let WidgetKey = CompatWidgets.register<ContentView>()

    let Content = Attributes.defineBindableWidget ContentView.ContentProperty

[<AutoOpen>]
module ContentViewBuilders =
    type Fabulous.Maui.View with

        static member inline ContentView(content: WidgetBuilder<'msg, #IView>) =
            WidgetHelpers.buildWidgets<'msg, IFabCompatContentView> ContentView.WidgetKey [| ContentView.Content.WithValue(content.Compile()) |]

[<Extension>]
type ContentViewModifiers =
    /// <summary>Link a ViewRef to access the direct ContentView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatContentView>, value: ViewRef<ContentView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
