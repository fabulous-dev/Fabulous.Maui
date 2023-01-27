namespace HelloWorld

open Microsoft.Maui
open Microsoft.Maui.Accessibility
open Fabulous
open Fabulous.Maui.Compatibility
open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    let semanticAnnounce text =
        fun () -> SemanticScreenReader.Announce(text)
        |> Cmd.ignore
            
    type Model =
        { Count: int
          ButtonText: string }
        
    type Msg =
        | Increment
        
    let init() =
        { Count = 0; ButtonText = "Click me!" }, Cmd.none
        
    let update msg model =
        match msg with
        | Increment ->
            let newCount = model.Count + 1
            let text =
                match newCount with
                | 1 -> "Clicked: 1 time"
                | count -> $"Clicked: {count} times"
            
            { model with Count = newCount; ButtonText = text }, semanticAnnounce text
    
    let view model =
        Application() {
            Window(
                ContentView(
                    ScrollView(
                        VStack(25.) {
                            Image("dotnet_bot.png")
                                .semantics(Semantics(Description = "Cute dotnet bot waving hi to you!"))
                                .height(200.)
                                .centerHorizontal()
                            
                            Label("Hello, World!")
                                .style(Styles.label)
                                .semantics(Semantics(HeadingLevel = SemanticHeadingLevel.Level1))
                                .font(Font.SystemFontOfSize(32.))
                                .centerHorizontal()
                                
                            Label("Welcome to .NET Multi-platform App UI")
                                .style(Styles.label)
                                .semantics(Semantics(HeadingLevel = SemanticHeadingLevel.Level2, Description = "Welcome to dot net Multi platform App U I"))
                                .font(Font.SystemFontOfSize(18.))
                                .centerHorizontal()
                                
                            // Compatibility button
                            Button(model.ButtonText, Increment)
                                //.style(Styles.textButton)
                                //.semantics(Semantics(Hint = "Counts the number of times you click"))
                                .centerHorizontal()
                        }
                    )
                        .centerVertical()
                        .padding(30., 0.)
                )
                    .style(Styles.contentView)
            )
        }
        
    let program =
        Program.statefulWithCmd init update view
        |> Program.withThemeAwareness
