namespace Fabulous.Maui.Compatibility

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.ApplicationModel

type CompatApplication() =
    inherit Application()

    let start = Event<EventHandler, EventArgs>()
    let sleep = Event<EventHandler, EventArgs>()
    let resume = Event<EventHandler, EventArgs>()

    [<CLIEvent>]
    member _.Start = start.Publish

    override this.OnStart() = start.Trigger(this, EventArgs())

    [<CLIEvent>]
    member _.Sleep = sleep.Publish

    override this.OnSleep() = sleep.Trigger(this, EventArgs())

    [<CLIEvent>]
    member _.Resume = resume.Publish

    override this.OnResume() = resume.Trigger(this, EventArgs())

type IFabCompatApplication =
    inherit IFabCompatElement
    inherit IApplication

module CompatApplication =
    let WidgetKey = CompatWidgets.register<CompatApplication>()

    let MainPage =
        Attributes.definePropertyWidget "Application_MainPage" (fun target -> (target :?> Application).MainPage :> obj) (fun target value ->
            (target :?> Application).MainPage <- value)

    let Resources =
        Attributes.defineSimpleScalarWithEquality<ResourceDictionary> "Application_Resources" (fun _ newValueOpt node ->
            let application = node.Target :?> Application

            let value =
                match newValueOpt with
                | ValueNone -> application.Resources
                | ValueSome v -> v

            application.Resources <- value)

    let UserAppTheme =
        Attributes.defineEnum<AppTheme> "Application_UserAppTheme" (fun _ newValueOpt node ->
            let application = node.Target :?> Application

            let value =
                match newValueOpt with
                | ValueNone -> AppTheme.Unspecified
                | ValueSome v -> v

            application.UserAppTheme <- value)

    let RequestedThemeChanged =
        Attributes.defineEvent<AppThemeChangedEventArgs> "Application_RequestedThemeChanged" (fun target -> (target :?> Application).RequestedThemeChanged)

    let ModalPopped =
        Attributes.defineEvent<ModalPoppedEventArgs> "Application_ModalPopped" (fun target -> (target :?> Application).ModalPopped)

    let ModalPopping =
        Attributes.defineEvent<ModalPoppingEventArgs> "Application_ModalPopping" (fun target -> (target :?> Application).ModalPopping)

    let ModalPushed =
        Attributes.defineEvent<ModalPushedEventArgs> "Application_ModalPushed" (fun target -> (target :?> Application).ModalPushed)

    let ModalPushing =
        Attributes.defineEvent<ModalPushingEventArgs> "Application_ModalPushing" (fun target -> (target :?> Application).ModalPushing)

    let Start =
        Attributes.defineEventNoArg "Application_Start" (fun target -> (target :?> CompatApplication).Start)

    let Sleep =
        Attributes.defineEventNoArg "Application_Sleep" (fun target -> (target :?> CompatApplication).Sleep)

    let Resume =
        Attributes.defineEventNoArg "Application_Resume" (fun target -> (target :?> CompatApplication).Resume)

[<AutoOpen>]
module CompatApplicationBuilders =
    type Fabulous.Maui.View with

        static member inline CompatApplication<'msg, 'marker when 'marker :> IFabCompatPage>(mainPage: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IFabCompatApplication> CompatApplication.WidgetKey [| CompatApplication.MainPage.WithValue(mainPage.Compile()) |]

[<Extension>]
type CompatApplicationModifiers =
    [<Extension>]
    static member inline userAppTheme(this: WidgetBuilder<'msg, #IFabCompatApplication>, value: AppTheme) =
        this.AddScalar(CompatApplication.UserAppTheme.WithValue(value))

    [<Extension>]
    static member inline resources(this: WidgetBuilder<'msg, #IFabCompatApplication>, value: ResourceDictionary) =
        this.AddScalar(CompatApplication.Resources.WithValue(value))

    [<Extension>]
    static member inline onRequestedThemeChanged(this: WidgetBuilder<'msg, #IFabCompatApplication>, onRequestedThemeChanged: AppTheme -> 'msg) =
        this.AddScalar(CompatApplication.RequestedThemeChanged.WithValue(fun args -> onRequestedThemeChanged args.RequestedTheme |> box))

    [<Extension>]
    static member inline onModalPopped(this: WidgetBuilder<'msg, #IFabCompatApplication>, onModalPopped: ModalPoppedEventArgs -> 'msg) =
        this.AddScalar(CompatApplication.ModalPopped.WithValue(onModalPopped >> box))

    [<Extension>]
    static member inline onModalPopping(this: WidgetBuilder<'msg, #IFabCompatApplication>, onModalPopping: ModalPoppingEventArgs -> 'msg) =
        this.AddScalar(CompatApplication.ModalPopping.WithValue(onModalPopping >> box))

    [<Extension>]
    static member inline onModalPushed(this: WidgetBuilder<'msg, #IFabCompatApplication>, onModalPushed: ModalPushedEventArgs -> 'msg) =
        this.AddScalar(CompatApplication.ModalPushed.WithValue(onModalPushed >> box))

    [<Extension>]
    static member inline onModalPushing(this: WidgetBuilder<'msg, #IFabCompatApplication>, onModalPushing: ModalPushingEventArgs -> 'msg) =
        this.AddScalar(CompatApplication.ModalPushing.WithValue(onModalPushing >> box))

    /// Dispatch a message when the application starts
    [<Extension>]
    static member inline onStart(this: WidgetBuilder<'msg, #IFabCompatApplication>, onStart: 'msg) =
        this.AddScalar(CompatApplication.Start.WithValue(onStart))

    /// Dispatch a message when the application is paused by the OS
    [<Extension>]
    static member inline onSleep(this: WidgetBuilder<'msg, #IFabCompatApplication>, onSleep: 'msg) =
        this.AddScalar(CompatApplication.Sleep.WithValue(onSleep))

    /// Dispatch a message when the application is resumed by the OS
    [<Extension>]
    static member inline onResume(this: WidgetBuilder<'msg, #IFabCompatApplication>, onResume: 'msg) =
        this.AddScalar(CompatApplication.Resume.WithValue(onResume))

    /// Link a ViewRef to access the direct Application instance
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatApplication>, value: ViewRef<Application>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
