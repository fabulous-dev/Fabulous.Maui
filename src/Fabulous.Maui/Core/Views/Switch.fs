namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls

module Switch =
    let WidgetKey = Widgets.register<FabSwitch>()

    let IsOn = Attributes.defineMauiPropertyWithEvent "IsOn" SwitchDefaults.IsOn SwitchDefaults.OnIsOnChanged FabSwitch.SetIsOn
    
[<AutoOpen>]
module SwitchBuilders =
    type Fabulous.Maui.View with
        static member inline Switch<'msg>(isOn: bool, isOnChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabSwitch>(
                Switch.WidgetKey,
                Switch.IsOn.WithValue(ValueEventData.create isOn (isOnChanged >> box))
            )