namespace CounterApp

open Microsoft.Maui.Graphics
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
                ScrollView(
                    VStack(25.) {
                        Image("dotnet_bot.png")
                            .height(200.)
                            .centerHorizontal()
                        
                        Label("Hello, World!")
                            .centerHorizontal()
                            
                        Label("Welcome to .NET Multi-platform App UI")
                            .centerHorizontal()
                        
                        let text = if model.Count = 0 then "Click me!" else $"Clicked: {model.Count} times"
                        TextButton(text, Increment)
                            .centerHorizontal()
                    }
                )
                    .centerVertical()
                    .padding(30., 0.)
            )
        }
        
    let program = Program.stateful init update view
