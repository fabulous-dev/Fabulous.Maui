namespace CounterApp

open Microsoft.Maui.Hosting
open Fabulous.Maui

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp
            .CreateBuilder()
            .UseFabulousApp(App.program)
            .ConfigureFonts(fun fonts ->
                fonts
                    .AddFont("OpenSans_Regular.ttf", "OpenSansRegular")
                    .AddFont("OpenSans_Semibold.ttf", "OpenSansSemibold")
                |> ignore)
            .Build()
