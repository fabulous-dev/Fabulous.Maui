namespace Gallery

open Microsoft.Maui.Accessibility
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    type Path =
        | Home
        | Details
    
    type Model = { Paths: Path list }

    type Msg =
        | Navigated of Path list
        | GoToDetails
        | GoBack

    let init () =
        { Paths = [ Home ] }

    let update msg model =
        match msg with
        | Navigated paths -> { model with Paths = paths }
        | GoToDetails -> { model with Paths = Details :: model.Paths }
        | GoBack -> { model with Paths = List.tail model.Paths }
    
    let view model =
        Application() {
            Window(
                NavigationStack(List.rev model.Paths, Navigated, fun path ->
                    match path with
                    | Home ->
                        VStack() {
                            Label("Home")
                            TextButton("Go to details", GoToDetails)
                        }
                        
                    | Details ->
                        VStack() {
                            Label("Details")
                            TextButton("Go back", GoBack)
                        }
                )
            )
        }

    let program = Program.stateful init update view
