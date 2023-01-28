namespace Fabulous.Maui.Compatibility

open System.Collections.Generic
open Microsoft.Maui.Controls.Shapes
open Fabulous

type IFabCompatGeometryGroup =
    inherit IFabCompatGeometry

module GeometryGroup =

    let WidgetKey = CompatWidgets.register<GeometryGroup>()

    let Children =
        Attributes.defineListWidgetCollection "GeometryGroup_Children" (fun target -> (target :?> GeometryGroup).Children :> IList<_>)

    let FillRule =
        Attributes.defineBindableEnum<FillRule> GeometryGroup.FillRuleProperty

[<AutoOpen>]
module GeometryGroupBuilders =
    type Fabulous.Maui.View with

        static member inline GeometryGroup<'msg>(?fillRule: FillRule) =
            match fillRule with
            | None -> CollectionBuilder<'msg, IFabCompatGeometryGroup, IFabCompatGeometry>(GeometryGroup.WidgetKey, GeometryGroup.Children)
            | Some fillRule ->
                CollectionBuilder<'msg, IFabCompatGeometryGroup, IFabCompatGeometry>(
                    GeometryGroup.WidgetKey,
                    GeometryGroup.Children,
                    GeometryGroup.FillRule.WithValue(fillRule)
                )
