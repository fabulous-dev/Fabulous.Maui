namespace Fabulous.Maui.Compatibility

open System.Collections.Generic
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabCompatTransformGroup =
    inherit IFabCompatTransform

module TransformGroup =

    let WidgetKey = CompatWidgets.register<TransformGroup>()

    let Children =
        Attributes.defineListWidgetCollection "TransformGroup_Children" (fun target -> (target :?> TransformGroup).Children :> IList<_>)

[<AutoOpen>]
module TransformGroupBuilders =
    type Fabulous.Maui.View with

        static member inline TransformGroup<'msg>() =
            CollectionBuilder<'msg, IFabCompatTransformGroup, IFabCompatTransform>(TransformGroup.WidgetKey, TransformGroup.Children)
