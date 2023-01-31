namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous.Maui.Compatibility
open Microsoft.Extensions.DependencyInjection.Extensions
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.FabCompat.Handlers
open Microsoft.Maui.Handlers
open Microsoft.Maui.Hosting
open Microsoft.Maui.Controls.Hosting
open Fabulous
open Fabulous.Maui.Controls

module FabulousHandlers =
    let getBindablePropertyByKey (key: string) =
        match key with
        | FabGridLayoutAttachedDataKeys.Column -> Microsoft.Maui.Controls.Grid.ColumnProperty
        | FabGridLayoutAttachedDataKeys.ColumnSpan -> Microsoft.Maui.Controls.Grid.ColumnSpanProperty
        | FabGridLayoutAttachedDataKeys.Row -> Microsoft.Maui.Controls.Grid.RowProperty
        | FabGridLayoutAttachedDataKeys.RowSpan -> Microsoft.Maui.Controls.Grid.RowSpanProperty
        | _ -> failwith $"Unknown key {key}"

    let getAttachedData (view: IView) (key: string) (defaultValue: obj) =
        match view with
        | :? IFabView as fabView -> fabView.GetAttachedData(key, defaultValue)
        | :? IFabCompatView as fabCompatView ->
            let bindableProperty = getBindablePropertyByKey key
            (fabCompatView :?> BindableObject).GetValue(bindableProperty)
        | _ -> failwith $"Unknown view type {view.GetType().Name}"

    let setAttachedData (view: IView) (key: string) (value: obj) =
        match view with
        | :? IFabView as fabView -> fabView.SetAttachedData(key, value)
        | :? IFabCompatView as fabCompatView ->
            let bindableProperty = getBindablePropertyByKey key
            (fabCompatView :?> BindableObject).SetValue(bindableProperty, value)
        | _ -> failwith $"Unknown view type {view.GetType().Name}"

    let register (collection: IMauiHandlersCollection) =
        collection
            .AddMauiControlsHandlers()
            .AddHandler<FabApplication, ApplicationHandler>()
            .AddHandler<FabWindow, WindowHandler>()
            .AddHandler<FabLabel, FabLabelHandler>()
            .AddHandler<FabButton, ButtonHandler>()
            .AddHandler<FabHorizontalStackLayout, LayoutHandler>()
            .AddHandler<FabVerticalStackLayout, LayoutHandler>()
            .AddHandler<FabScrollView, ScrollViewHandler>()
            .AddHandler<FabImage, ImageHandler>()
            .AddHandler<FabContentView, ContentViewHandler>()
            .AddHandler<FabSwitch, SwitchHandler>()
            .AddHandler<FabSlider, SliderHandler>()
            .AddHandler<FabTextButton, ButtonHandler>()
            .AddHandler<FabGridLayout, LayoutHandler>()
            .AddHandler<FabNavigationStack, FabNavigationViewHandler>()
        |> ignore

[<Extension>]
type AppHostBuilderExtensions =
    /// Start a Fabulous app taking args
    [<Extension>]
    static member UseFabulousApp<'args, 'model, 'msg, 'marker when 'marker :> IApplication>
        (
            this: MauiAppBuilder,
            program: Program<'args, 'model, 'msg, 'marker>,
            args: 'args
        ) =
        AttachedData.Get <- System.Func<_, _, _, _>(FabulousHandlers.getAttachedData)
        AttachedData.Set <- System.Action<_, _, _>(FabulousHandlers.setAttachedData)

        this.ConfigureMauiHandlers(FabulousHandlers.register) |> ignore

        this.Services.TryAddSingleton<IApplication>(fun _ ->
            let app = Program.startApplicationWithArgs args program
            app)

        this

    /// Start a Fabulous app taking no args
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'marker when 'marker :> IApplication>(this: MauiAppBuilder, program: Program<unit, 'model, 'msg, 'marker>) =
        this.UseFabulousApp(program, ())
