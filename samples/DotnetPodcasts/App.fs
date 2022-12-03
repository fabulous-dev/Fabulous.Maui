namespace DotnetPodcasts

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Devices
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

[<Extension>]
type WindowExtensions =
    [<Extension>]
    static member inline defaultSizesOnDesktop(this: WidgetBuilder<'msg, #IWindow>) =
        if DeviceInfo.Platform = DevicePlatform.WinUI || DeviceInfo.Platform = DevicePlatform.MacCatalyst then
            this
                .minimumWidth(1080.)
                .maximumWidth(1920.)
                .minimumHeight(500.)
                .maximumHeight(1080.)
        else
            this

module App =
    let view () =
        Application() {
            Window(
                Label("")
            )
                .defaultSizesOnDesktop()
        }
        
    let program =
        Program.stateless view
        |> Program.withThemeAwareness
