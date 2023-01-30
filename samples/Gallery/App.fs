namespace Gallery

open Microsoft.Maui.Accessibility
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    let semanticAnnounce text =
        fun () -> SemanticScreenReader.Announce(text)
        |> Cmd.ignore

    type Model = { Count: int; ButtonText: string }

    type Msg = | Increment

    let init () =
        { Count = 0; ButtonText = "Click me!" }, Cmd.none

    let update msg model =
        match msg with
        | Increment ->
            let newCount = model.Count + 1

            let text =
                match newCount with
                | 1 -> "Clicked: 1 time"
                | count -> $"Clicked: {count} times"

            { model with
                Count = newCount
                ButtonText = text },
            semanticAnnounce text

    let view model =
        Application() {
            Window(
                ScrollView(
                    (Grid(coldefs = [ Star ], rowdefs = [ Auto; Star ]) {
                        VStack(spacing = 20.) {
                            Label("Fabulous gallery")
                                .style(Styles.title)
                                
                            Label(".NET MAUI")
                                .style(Styles.subtitle)
                            
                            Label("A collection of code samples to showcase the capabilities of Fabulous and .NET MAUI")
                            Label("Available on: iOS & Android")
                        }
                        
                        Label("Second row")
                            .gridRow(1)
                    })
                        .margin(32.)
                )
            )
        }

    let program = Program.statefulWithCmd init update view |> Program.withThemeAwareness
