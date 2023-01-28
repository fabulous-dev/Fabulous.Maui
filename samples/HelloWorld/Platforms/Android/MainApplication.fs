namespace HelloWorld.Android

open Android.App
open Microsoft.Maui
open HelloWorld

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do HelloWorld.Resource.UpdateIdValues()

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()
