namespace NewApp

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Accessibility

open type Fabulous.Maui.View

module App =
    type Model = { Count: int }

    type Msg = | Clicked

    type CmdMsg = SemanticAnnounce of string

    let semanticAnnounce text =
        Cmd.ofSub(fun _ -> SemanticScreenReader.Announce(text))

    let mapCmd cmdMsg =
        match cmdMsg with
        | SemanticAnnounce text -> semanticAnnounce text

    let init () = { Count = 0 }, []

    let update msg model =
        match msg with
        | Clicked -> { model with Count = model.Count + 1 }, [ SemanticAnnounce $"Clicked {model.Count} times" ]

    let view model =
        Application() {
            Window(
                ScrollView(
                    (VStack(spacing = 25.) {
                        Image("dotnet_bot.png")
                            .semantics(Semantics(Description = "Cute dotnet bot waving hi to you!"))
                            .height(200.)
                            .centerHorizontal()

                        Label("Hello, World!")
                            .semantics(Semantics(HeadingLevel = SemanticHeadingLevel.Level1))
                            .font(Font.SystemFontOfSize(32.))
                            .centerTextHorizontal()

                        Label("Welcome to .NET Multi-platform App UI powered by Fabulous")
                            .semantics(Semantics(HeadingLevel = SemanticHeadingLevel.Level2, Description = "Welcome to dot net Multi platform App U I powered by Fabulous"))
                            .font(Font.SystemFontOfSize(18.))
                            .centerTextHorizontal()

                        let text =
                            if model.Count = 0 then
                                "Click me"
                            else
                                $"Clicked {model.Count} times"

                        TextButton(text, Clicked)
                            .semantics(Semantics(Hint = "Counts the number of times you click"))
                            .centerHorizontal()
                    })
                        .padding(Thickness(30., 0., 30., 0.))
                        .centerVertical()
                )
            )
        }

    let program = Program.statefulWithCmdMsg init update view mapCmd