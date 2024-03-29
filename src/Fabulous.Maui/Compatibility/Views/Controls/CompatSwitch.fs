namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatSwitch =
    inherit IFabCompatView
    inherit ISwitch

module CompatSwitch =
    let WidgetKey = CompatWidgets.register<Switch>()

    let ColorOn = Attributes.defineBindableAppThemeColor Switch.OnColorProperty

    let ThumbColor = Attributes.defineBindableAppThemeColor Switch.ThumbColorProperty

    let IsToggledWithEvent =
        Attributes.defineBindableWithEvent "Switch_Toggled" Switch.IsToggledProperty (fun target -> (target :?> Switch).Toggled)

[<AutoOpen>]
module SwitchBuilders =
    type Fabulous.Maui.View with

        static member inline CompatSwitch<'msg>(isToggled: bool, onToggled: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCompatSwitch>(
                CompatSwitch.WidgetKey,
                CompatSwitch.IsToggledWithEvent.WithValue(ValueEventData.create isToggled (fun args -> onToggled args.Value |> box))
            )

[<Extension>]
type SwitchModifiers =
    /// <summary>Set the color of the thumbColor.</summary>
    /// <param name="light">The color of the thumbColor in the light theme.</param>
    /// <param name="dark">The color of the thumbColor in the dark theme.</param>
    [<Extension>]
    static member inline thumbColor(this: WidgetBuilder<'msg, #IFabCompatSwitch>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatSwitch.ThumbColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the on state.</summary>
    /// <param name="light">The color of the on state in the light theme.</param>
    /// <param name="dark">The color of the on state in the dark theme.</param>
    [<Extension>]
    static member inline colorOn(this: WidgetBuilder<'msg, #IFabCompatSwitch>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(CompatSwitch.ColorOn.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct Switch control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatSwitch>, value: ViewRef<Switch>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
