namespace CounterApp

open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    type Model =
        { Count: int }
        
    type Msg =
        | Increment
        
    let init() =
        { Count = 0 }
        
    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
    
    let view model =
        Application() {
            Window(
                let text = if model.Count = 0 then "Click me!" else $"Clicked: {model.Count} times"
                TextButton(text, Increment)
            )
        }
        
    let program = Program.stateful init update view
