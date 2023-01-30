namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module Container =
    let Children =
        Attributes.defineListWidgetCollection "Children" (fun target -> (target :?> IList<IView>))

[<Extension>]
type ContainerCollectionExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabContainer, IView>,
            x: WidgetBuilder<'msg, #IView>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) }: Content<'msg>

    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabContainer, IView>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IView>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) }: Content<'msg>
