namespace Fabulous.Maui

open System
open System.Diagnostics
open Fabulous.Maui.Controls
open Microsoft.Maui
open Microsoft.Maui.ApplicationModel
open Fabulous
open Microsoft.Maui.Controls

module Cmd =
    let ignore (fn: unit -> unit) = Cmd.ofSub(fun _ -> fn())

module ViewHelpers =
    let canReuseView (prev: Widget) (curr: Widget) = ViewHelpers.canReuseView prev curr

    let defaultLogger () =
        let log (level, message) =
            let traceLevel =
                match level with
                | LogLevel.Debug -> "Debug"
                | LogLevel.Info -> "Information"
                | LogLevel.Warn -> "Warning"
                | LogLevel.Error -> "Error"
                | _ -> "Error"

            Trace.WriteLine(message, traceLevel)

        { Log = log
          MinLogLevel = LogLevel.Error }

    let defaultExceptionHandler exn =
        Trace.WriteLine(String.Format("Unhandled exception: {0}", exn.ToString()), "Debug")
        false

    let getViewNode (target: obj) =
        let x =
            match target with
            | :? IFabElement as element -> Fabulous.Maui.ViewNode.get element
            | :? BindableObject as bindableObject -> Fabulous.Maui.Compatibility.ViewNode.get bindableObject
            | _ -> failwith "Unsupported target"
            
        if x = Unchecked.defaultof<_> then failwith "ViewNode not found"
        x
        
    let setViewNode (viewNode: IViewNode) (target: obj) =
        match target with
        | :? IFabElement as element -> Fabulous.Maui.ViewNode.set viewNode element
        | :? BindableObject as bindableObject -> Fabulous.Maui.Compatibility.ViewNode.set viewNode bindableObject
        | _ -> failwith "Unsupported target"

module Program =
    let inline private define (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          Subscribe = fun _ -> Cmd.none
          View = view
          CanReuseView = ViewHelpers.canReuseView
          SyncAction = MainThread.BeginInvokeOnMainThread
          Logger = ViewHelpers.defaultLogger()
          ExceptionHandler = ViewHelpers.defaultExceptionHandler }

    /// Create a program for a static view
    let stateless (view: unit -> WidgetBuilder<unit, 'marker>) =
        define (fun () -> (), Cmd.none) (fun () () -> (), Cmd.none) view

    /// Create a program using an MVU loop
    let stateful (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) (view: 'model -> WidgetBuilder<'msg, 'marker>) =
        define (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none) view

    /// Create a program using an MVU loop. Add support for Cmd
    let statefulWithCmd (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) (view: 'model -> WidgetBuilder<'msg, #IApplication>) =
        define init update view

    /// Create a program using an MVU loop. Add support for CmdMsg
    let statefulWithCmdMsg
        (init: 'arg -> 'model * 'cmdMsg list)
        (update: 'msg -> 'model -> 'model * 'cmdMsg list)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        (mapCmd: 'cmdMsg -> Cmd<'msg>)
        =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch

        define (fun arg -> let m, c = init arg in m, mapCmds c) (fun msg model -> let m, c = update msg model in m, mapCmds c) view

    /// Start the program
    let startApplicationWithArgs (arg: 'arg) (program: Program<'arg, 'model, 'msg, #IApplication>) : IApplication =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create ViewHelpers.getViewNode ViewHelpers.setViewNode runner
        adapter.CreateView() |> unbox

    /// Start the program
    let startApplication (program: Program<unit, 'model, 'msg, #IApplication>) : IApplication = startApplicationWithArgs () program

    /// Subscribe to external source of events.
    /// The subscription is called once - with the initial model, but can dispatch new messages at any time.
    let withSubscription (subscribe: 'model -> Cmd<'msg>) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let sub model =
            Cmd.batch [ program.Subscribe model; subscribe model ]

        { program with Subscribe = sub }

    /// Configure how the output messages from Fabulous will be handled
    let withLogger (logger: Logger) (program: Program<'arg, 'model, 'msg, 'marker>) = { program with Logger = logger }

    /// Trace all the updates to the debug output
    let withTrace (trace: string * string -> unit) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let traceInit arg =
            try
                let initModel, cmd = program.Init(arg)
                trace("Initial model: {0}", $"%0A{initModel}")
                initModel, cmd
            with e ->
                trace("Error in init function: {0}", $"%0A{e}")
                reraise()

        let traceUpdate (msg, model) =
            trace("Message: {0}", $"%0A{msg}")

            try
                let newModel, cmd = program.Update(msg, model)
                trace("Updated model: {0}", $"%0A{newModel}")
                newModel, cmd
            with e ->
                trace("Error in model function: {0}", $"%0A{e}")
                reraise()

        let traceView model =
            trace("View, model = {0}", $"%0A{model}")

            try
                let info = program.View(model)
                trace("View result: {0}", $"%0A{info}")
                info
            with e ->
                trace("Error in view function: {0}", $"%0A{e}")
                reraise()

        { program with
            Init = traceInit
            Update = traceUpdate
            View = traceView }

    /// Configure how the unhandled exceptions happening during the execution of a Fabulous app with be handled
    let withExceptionHandler (handler: exn -> bool) (program: Program<'arg, 'model, 'msg, 'marker>) =
        { program with
            ExceptionHandler = handler }

    let withThemeAwareness (program: Program<'arg, 'model, 'msg, #IApplication>) =
        { Init = ThemeAwareProgram.init program.Init
          Update = ThemeAwareProgram.update program.Update
          Subscribe = fun model -> program.Subscribe model.Model |> Cmd.map ThemeAwareProgram.Msg.ModelMsg
          View = ThemeAwareProgram.view program.View
          CanReuseView = program.CanReuseView
          SyncAction = program.SyncAction
          Logger = program.Logger
          ExceptionHandler = program.ExceptionHandler }

[<RequireQualifiedAccess>]
module CmdMsg =
    let batch mapCmdMsgFn mapCmdFn cmdMsgs =
        cmdMsgs |> List.map(mapCmdMsgFn >> Cmd.map mapCmdFn) |> Cmd.batch
