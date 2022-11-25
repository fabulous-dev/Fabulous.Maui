namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection.Extensions
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Microsoft.Maui.Hosting
open Fabulous
open Fabulous.Maui.Controls

module FabulousHandlers =
    let register (collection: IMauiHandlersCollection) =
        collection
            .AddHandler<FabApplication, ApplicationHandler>()
            .AddHandler<FabWindow, WindowHandler>()
            .AddHandler<FabLabel, LabelHandler>()
        |> ignore

[<Extension>]
type AppHostBuilderExtensions =
    /// Start a Fabulous app taking args
    [<Extension>]
    static member UseFabulousApp<'args, 'model, 'msg, 'marker when 'marker :> IApplication>(this: MauiAppBuilder, program: Program<'args, 'model, 'msg, 'marker>, args: 'args) =
        this.Services.TryAddSingleton<IApplication>(fun _ ->
            Program.startApplicationWithArgs args program
        )
        this.ConfigureMauiHandlers(FabulousHandlers.register)
        
    /// Start a Fabulous app taking no args
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'marker when 'marker :> IApplication>(this: MauiAppBuilder, program: Program<unit, 'model, 'msg, 'marker>) =
        this.UseFabulousApp(program, ())