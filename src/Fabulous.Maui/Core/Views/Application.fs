namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections

module Application =
    let WidgetKey = Widgets.register<FabApplication>()

    let Windows =
        Attributes.defineListWidgetCollection "Application_Windows" (fun target -> (target :?> FabApplication).EditableWindows)

    let ThemeChanged =
        Attributes.defineMauiAction' "ThemeChanged" ApplicationDefaults.OnThemeChanged (fun (target: IFabApplication) -> target.SetOnThemeChanged)

[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Maui.View with

        static member Application<'msg>() =
            CollectionBuilder<'msg, IFabApplication, IWindow>(Application.WidgetKey, Application.Windows)

[<Extension>]
type ApplicationModifiers =
    [<Extension>]
    static member inline onThemeChanged(this: WidgetBuilder<'msg, #IFabApplication>, value: AppTheme -> 'msg) =
        this.AddScalar(Application.ThemeChanged.WithValue(fun args -> value args |> box))

[<Extension>]
type ApplicationCollectionExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IWindow>
        (
            _: CollectionBuilder<'msg, IFabApplication, IWindow>,
            x: WidgetBuilder<'msg, 'itemType>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) }: Content<'msg>

    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IWindow>
        (
            _: CollectionBuilder<'msg, IFabApplication, IWindow>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) }: Content<'msg>
