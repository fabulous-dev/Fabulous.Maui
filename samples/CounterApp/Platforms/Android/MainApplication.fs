namespace CounterApp.Android

open Android.App
open Microsoft.Maui

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do CounterApp.Android.Resource.UpdateIdValues()
    
    override _.CreateMauiApp() = MauiProgram.CreateMauiApp()