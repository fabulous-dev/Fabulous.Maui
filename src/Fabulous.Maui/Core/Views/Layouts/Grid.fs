namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui.Controls
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults

module Grid =
    let WidgetKey = Widgets.register<FabGridLayout>()

    let ColumnDefinitions =
        Attributes.defineMauiProperty<IFabGridLayout, Dimension[]> "ColumnDefinitions" Array.empty (fun target value ->
            let definitions = List<IGridColumnDefinition>()

            for d in value do
                let gridLength =
                    match d with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                definitions.Add(
                    { new IGridColumnDefinition with
                        member _.Width = gridLength }
                )

            target.SetColumnDefinitions(definitions))

    let RowDefinitions =
        Attributes.defineMauiProperty<IFabGridLayout, Dimension[]> "RowDefinitions" Array.empty (fun target value ->
            let definitions = List<IGridRowDefinition>()

            for d in value do
                let gridLength =
                    match d with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Absolute x -> GridLength(x, GridUnitType.Absolute)

                definitions.Add(
                    { new IGridRowDefinition with
                        member _.Height = gridLength }
                )

            target.SetRowDefinitions(definitions))

    let ColumnSpacing =
        Attributes.defineMauiProperty "ColumnSpacing" GridLayoutDefaults.ColumnSpacing (fun (target: IFabGridLayout) -> target.SetColumnSpacing)

    let RowSpacing =
        Attributes.defineMauiProperty "RowSpacing" GridLayoutDefaults.RowSpacing (fun (target: IFabGridLayout) -> target.SetRowSpacing)

module GridAttachedData =
    let Column =
        SharedAttributes.defineAttachedData FabGridLayoutAttachedDataKeys.Column

    let ColumnSpan =
        SharedAttributes.defineAttachedData FabGridLayoutAttachedDataKeys.ColumnSpan

    let Row =
        SharedAttributes.defineAttachedData FabGridLayoutAttachedDataKeys.Row

    let RowSpan =
        SharedAttributes.defineAttachedData FabGridLayoutAttachedDataKeys.RowSpan

[<AutoOpen>]
module GridBuilders =
    type Fabulous.Maui.View with

        static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
            CollectionBuilder<'msg, IFabGridLayout, IView>(
                Grid.WidgetKey,
                Container.Children,
                Grid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
                Grid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
            )

        static member inline Grid<'msg>() =
            CollectionBuilder<'msg, IFabGridLayout, IView>(Grid.WidgetKey, Container.Children)

[<Extension>]
type GridModifiers =
    [<Extension>]
    static member columnSpacing(this: WidgetBuilder<'msg, #IFabGridLayout>, value: float) =
        this.AddScalar(Grid.ColumnSpacing.WithValue(value))

    [<Extension>]
    static member rowSpacing(this: WidgetBuilder<'msg, #IFabGridLayout>, value: float) =
        this.AddScalar(Grid.RowSpacing.WithValue(value))

[<Extension>]
type GridAttachedDataModifiers =
    [<Extension>]
    static member gridColumn(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridAttachedData.Column.WithValue(value))

    [<Extension>]
    static member gridColumnSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridAttachedData.ColumnSpan.WithValue(value))

    [<Extension>]
    static member gridRow(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridAttachedData.Row.WithValue(value))

    [<Extension>]
    static member gridRowSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(GridAttachedData.RowSpan.WithValue(value))
