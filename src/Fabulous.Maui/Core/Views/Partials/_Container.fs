namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Fabulous
open Fabulous.Maui.Controls

module Container =
    let Children = Attributes.defineListWidgetCollection "Children" (fun target -> (target :?> IList<IView>))
    
[<Extension>]
 type ContainerCollectionExtensions =
     [<Extension>]
     static member inline Yield<'msg, 'parentType, 'itemType when 'parentType :> IFabContainer and 'itemType :> IView>
         (
             _: CollectionBuilder<'msg, 'parentType, IView>,
             x: WidgetBuilder<'msg, 'itemType>
         ) =
         { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>

     [<Extension>]
     static member inline Yield<'msg, 'parentType, 'itemType when 'parentType :> IFabContainer and 'itemType :> IView>
         (
             _: CollectionBuilder<'msg, 'parentType, IView>,
             x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
         ) =
         { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>