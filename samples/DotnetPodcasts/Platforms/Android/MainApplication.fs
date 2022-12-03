namespace DotnetPodcasts.Android

open Android.App
open Microsoft.Maui
open DotnetPodcasts

[<Application>]
type MainApplication(handle, ownership) =
    inherit MauiApplication(handle, ownership)

    do DotnetPodcasts.Resource.UpdateIdValues()
    
    override this.CreateMauiApp() =
        MauiProgram.CreateMauiApp()