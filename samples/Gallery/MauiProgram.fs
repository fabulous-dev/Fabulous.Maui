namespace Gallery

open Microsoft.Maui.Hosting
open Fabulous.Maui

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp
            .CreateBuilder()
            .UseFabulousApp(App.program)
            .ConfigureFonts(fun fonts ->
                fonts
                    .AddFont("OpenSans_Regular.ttf", Fonts.OpenSansRegular)
                    .AddFont("OpenSans_Semibold.ttf", Fonts.OpenSansSemibold)
                    .AddFont("OpenSans_Bold.ttf", Fonts.OpenSansBold)
                |> ignore)
            .Build()
