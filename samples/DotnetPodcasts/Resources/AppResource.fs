namespace DotnetPodcasts.Resources

open System.Reflection
open System.Resources
open System.Threading

[<RequireQualifiedAccess>]
type AppResource() =
    [<Literal>]
    static let resourceName = "DotnetPodcasts.Resources.AppResource"

    static let resourceManager =
        ResourceManager(resourceName, typeof<AppResource>.GetTypeInfo().Assembly)

    static let get(key: string) =
        resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture)

    static member Autodownload_Using_Data = get "Autodownload_Using_Data"
    static member Autodownload_Using_Data_Subtitle = get "Autodownload_Using_Data_Subtitle"
    static member Categories = get "Categories"
    static member Close = get "Close"
    static member Dark_Mode = get "Dark_Mode"
    static member Delete_Played_Episodes = get "Delete_Played_Episodes"
    static member Discover = get "Discover"
    static member Download_Settings = get "Download_Settings"
    static member Error_Message = get "Error_Message"
    static member Error_Title = get "Error_Title"
    static member Home = get "Home"
    static member Listen_Later = get "Listen_Later"
    static member Listen_Later_Remove_Episode = get "Listen_Later_Remove_Episode"
    static member Listen_Later_Short = get "Listen_Later_Short"
    static member Listen_Together = get "Listen_Together"
    static member Listen_Together_Short = get "Listen_Together_Short"
    static member Only_Wifi = get "Only_Wifi"
    static member Play = get "Play"
    static member Play_Or_Pause = get "Play_Or_Pause"
    static member See_All_Categories = get "See_All_Categories"
    static member Semantic_Description_Tap_Listen_Later = get "Semantic_Description_Tap_Listen_Later"
    static member Semantic_Description_Tap_Play_Episode = get "Semantic_Description_Tap_Play_Episode"
    static member Semantic_Description_Tap_Search = get "Semantic_Description_Tap_Search"
    static member Semantic_Description_Tap_See_All_Categories = get "Semantic_Description_Tap_See_All_Categories"
    static member Semantic_Description_Tap_Select = get "Semantic_Description_Tap_Select"
    static member Semantic_Description_Tap_Subscribe_Podcast = get "Semantic_Description_Tap_Subscribe_Podcast"
    static member Semantic_Description_Toggle_Mode = get "Semantic_Description_Toggle_Mode"
    static member Semantic_Description_Toggle_Wifi = get "Semantic_Description_Toggle_Wifi"
    static member Settings = get "Settings"
    static member Settings_Info = get "Settings_Info"
    static member Specially_For_You = get "Specially_For_You"
    static member Subscribe = get "Subscribe"
    static member Subscribed = get "Subscribed"
    static member Subscriptions = get "Subscriptions"
    static member Version = get "Version"
    static member Whats_New = get "Whats_New"
