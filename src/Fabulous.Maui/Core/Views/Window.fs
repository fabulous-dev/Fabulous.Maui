namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers.Defaults

module Window =
    let WidgetKey = Widgets.register<FabWindow>()

    let Content =
        Attributes.defineMauiPropertyWidget<IFabWindow, IView> "Content" (fun target -> target.Content) (fun target -> target.SetContent)

    let FlowDirection =
        Attributes.defineMauiProperty' "FlowDirection" WindowDefaults.CreateFlowDirection (fun (target: IFabWindow) -> target.SetFlowDirection)

    let Height =
        Attributes.defineMauiProperty "Height" WindowDefaults.Height (fun (target: IFabWindow) -> target.SetHeight)

    let MaximumHeight =
        Attributes.defineMauiProperty "MaximumHeight" WindowDefaults.MaximumHeight (fun (target: IFabWindow) -> target.SetMaximumHeight)

    let MaximumWidth =
        Attributes.defineMauiProperty "MaximumWidth" WindowDefaults.MaximumWidth (fun (target: IFabWindow) -> target.SetMaximumWidth)

    let MinimumHeight =
        Attributes.defineMauiProperty "MinimumHeight" WindowDefaults.MinimumHeight (fun (target: IFabWindow) -> target.SetMinimumHeight)

    let MinimumWidth =
        Attributes.defineMauiProperty "MinimumWidth" WindowDefaults.MinimumWidth (fun (target: IFabWindow) -> target.SetMinimumWidth)

    let OnActivated =
        Attributes.defineMauiAction "OnActivated" WindowDefaults.OnActivated (fun (target: IFabWindow) -> target.SetOnActivated)

    let OnBackButtonClicked =
        Attributes.defineMauiFuncBool "OnBackButtonClicked" WindowDefaults.OnBackButtonClicked (fun (target: IFabWindow) -> target.SetOnBackButtonClicked)

    let OnBackgrounding =
        Attributes.defineMauiAction' "OnBackgrounding" WindowDefaults.OnBackgrounding (fun (target: IFabWindow) -> target.SetOnBackgrounding)

    let OnCreated =
        Attributes.defineMauiAction "OnCreated" WindowDefaults.OnCreated (fun (target: IFabWindow) -> target.SetOnCreated)

    let OnDeactivated =
        Attributes.defineMauiAction "OnDeactivated" WindowDefaults.OnDeactivated (fun (target: IFabWindow) -> target.SetOnDeactivated)

    let OnDestroying =
        Attributes.defineMauiAction "OnDestroying" WindowDefaults.OnDestroying (fun (target: IFabWindow) -> target.SetOnDestroying)

    let OnDisplayDensityChanged =
        Attributes.defineMauiAction' "OnDisplayDensityChanged" WindowDefaults.OnDisplayDensityChanged (fun (target: IFabWindow) ->
            target.SetOnDisplayDensityChanged)

    let OnFrameChanged =
        Attributes.defineMauiAction' "OnFrameChanged" WindowDefaults.OnFrameChanged (fun (target: IFabWindow) -> target.SetOnFrameChanged)

    let OnResumed =
        Attributes.defineMauiAction "OnResumed" WindowDefaults.OnResumed (fun (target: IFabWindow) -> target.SetOnResumed)

    let OnStopped =
        Attributes.defineMauiAction "OnStopped" WindowDefaults.OnStopped (fun (target: IFabWindow) -> target.SetOnStopped)

    let VisualDiagnosticsOverlay =
        Attributes.defineMauiProperty "VisualDiagnosticsOverlay" WindowDefaults.VisualDiagnosticsOverlay (fun (target: IFabWindow) ->
            target.SetVisualDiagnosticsOverlay)

    let Width =
        Attributes.defineMauiProperty "Width" WindowDefaults.Width (fun (target: IFabWindow) -> target.SetWidth)

    let X =
        Attributes.defineMauiProperty "X" WindowDefaults.X (fun (target: IFabWindow) -> target.SetX)

    let Y =
        Attributes.defineMauiProperty "Y" WindowDefaults.Y (fun (target: IFabWindow) -> target.SetY)

[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Maui.View with

        static member inline Window(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IFabWindow>(
                Window.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Window.Content.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type WindowModifiers =
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabWindow>, value: FlowDirection) =
        this.AddScalar(Window.FlowDirection.WithValue(value))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.Height.WithValue(value))

    [<Extension>]
    static member inline maximumHeight(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MaximumHeight.WithValue(value))

    [<Extension>]
    static member inline maximumWidth(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MaximumWidth.WithValue(value))

    [<Extension>]
    static member inline minimumHeight(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MinimumHeight.WithValue(value))

    [<Extension>]
    static member inline minimumWidth(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.MinimumWidth.WithValue(value))

    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnActivated.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline onBackButtonClicked(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnBackButtonClicked.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline onBackgrounding(this: WidgetBuilder<'msg, #IFabWindow>, fn: IPersistedState -> 'msg) =
        this.AddScalar(Window.OnBackgrounding.WithValue(fun args -> box(fn args)))

    [<Extension>]
    static member inline onCreated(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnCreated.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnDeactivated.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline onDestroying(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnDestroying.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline onDisplayDensityChanged(this: WidgetBuilder<'msg, #IFabWindow>, fn: float32 -> 'msg) =
        this.AddScalar(Window.OnDisplayDensityChanged.WithValue(fun args -> box(fn args)))

    [<Extension>]
    static member inline onFrameChanged(this: WidgetBuilder<'msg, #IFabWindow>, fn: Rect -> 'msg) =
        this.AddScalar(Window.OnFrameChanged.WithValue(fun args -> box(fn args)))

    [<Extension>]
    static member inline onResumed(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnResumed.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline onStopped(this: WidgetBuilder<'msg, #IFabWindow>, msg: 'msg) =
        this.AddScalar(Window.OnStopped.WithValue(fun () -> box msg))

    [<Extension>]
    static member inline visualDiagnosticsOverlay(this: WidgetBuilder<'msg, #IFabWindow>, value: VisualDiagnosticsOverlay) =
        this.AddScalar(Window.VisualDiagnosticsOverlay.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.Width.WithValue(value))

    [<Extension>]
    static member inline x(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.X.WithValue(value))

    [<Extension>]
    static member inline y(this: WidgetBuilder<'msg, #IFabWindow>, value: double) =
        this.AddScalar(Window.Y.WithValue(value))
