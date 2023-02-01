namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatGrid =
    inherit IFabCompatLayoutOfView
    inherit IGridLayout

module CompatGridUpdaters =
    let updateGridColumnDefinitions _ (newValueOpt: Dimension[] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.ColumnDefinitions.Clear()
        | ValueSome coll ->
            grid.ColumnDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.ColumnDefinitions.Add(ColumnDefinition(Width = gridLength))

    let updateGridRowDefinitions _ (newValueOpt: Dimension[] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.RowDefinitions.Clear()
        | ValueSome coll ->
            grid.RowDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

module CompatGrid =
    let WidgetKey = CompatWidgets.register<Grid>()

    let ColumnDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array> "Grid_ColumnDefinitions" CompatGridUpdaters.updateGridColumnDefinitions

    let RowDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array> "Grid_RowDefinitions" CompatGridUpdaters.updateGridRowDefinitions

    let Column = Attributes.defineBindableInt Grid.ColumnProperty

    let Row = Attributes.defineBindableInt Grid.RowProperty

    let ColumnSpacing = Attributes.defineBindableFloat Grid.ColumnSpacingProperty

    let RowSpacing = Attributes.defineBindableFloat Grid.RowSpacingProperty

    let ColumnSpan = Attributes.defineBindableInt Grid.ColumnSpanProperty

    let RowSpan = Attributes.defineBindableInt Grid.RowSpanProperty

[<AutoOpen>]
module CompatGridBuilders =
    type Fabulous.Maui.View with

        static member inline CompatGrid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
            CollectionBuilder<'msg, IFabCompatGrid, IView>(
                CompatGrid.WidgetKey,
                CompatLayoutOfView.Children,
                CompatGrid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
                CompatGrid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
            )

        static member inline CompatGrid<'msg>() =
            CollectionBuilder<'msg, IFabCompatGrid, IView>(CompatGrid.WidgetKey, CompatLayoutOfView.Children)

[<Extension>]
type GridModifiers =
    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<'msg, #IFabCompatGrid>, value: float) =
        this.AddScalar(CompatGrid.ColumnSpacing.WithValue(value))

    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<'msg, #IFabCompatGrid>, value: float) =
        this.AddScalar(CompatGrid.RowSpacing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Grid control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatGrid>, value: ViewRef<Grid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type CompatGridAttachedModifiers =
    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<'msg, #IFabCompatView>, value: int) =
        this.AddScalar(CompatGrid.Column.WithValue(value))

    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<'msg, #IFabCompatView>, value: int) =
        this.AddScalar(CompatGrid.Row.WithValue(value))

    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<'msg, #IFabCompatView>, value: int) =
        this.AddScalar(CompatGrid.ColumnSpan.WithValue(value))

    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<'msg, #IFabCompatView>, value: int) =
        this.AddScalar(CompatGrid.RowSpan.WithValue(value))
