namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui

type IFabCompatLayoutOfView =
    inherit IFabCompatLayout

module CompatLayoutOfView =
    let Children =
        Attributes.defineListWidgetCollection "LayoutOfWidget_Children" (fun target -> (target :?> Microsoft.Maui.Controls.Layout).Children)

[<Extension>]
type CompatLayoutOfViewCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabCompatLayoutOfView, IView>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
        
    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabCompatLayoutOfView, IView>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IView>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }