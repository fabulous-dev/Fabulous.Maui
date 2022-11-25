namespace CounterApp

open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    let view () =
        Application() {
            Window(
                Label("Hello, World!")
            )
        }
        
    let program = Program.stateless view
