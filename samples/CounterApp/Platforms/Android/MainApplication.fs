namespace CounterApp.Android

open Android.App
open Microsoft.Maui
open CounterApp

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do CounterApp.Resource.UpdateIdValues()

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()
