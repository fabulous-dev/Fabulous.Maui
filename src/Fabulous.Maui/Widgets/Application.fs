namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Fabulous
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections

module Application =
    let WidgetKey = Widgets.register<FabApplication>()
    
    let Windows = Attributes.defineListWidgetCollection "Application_Windows" (fun target -> (target :?> FabApplication).EditableWindows)
    let ThemeChanged = Attributes.defineMauiAction' "Application" "ThemeChanged" ApplicationDefaults.OnThemeChanged FabApplicationSetters.SetOnThemeChanged
    
[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Maui.View with
        static member Application<'msg>() =
            CollectionBuilder<'msg, IApplication, IWindow>(
                Application.WidgetKey,
                Application.Windows
            )
            
[<Extension>]
 type ApplicationCollectionExtensions =
     [<Extension>]
     static member inline Yield<'msg, 'itemType when 'itemType :> IWindow>
         (
             _: CollectionBuilder<'msg, IApplication, IWindow>,
             x: WidgetBuilder<'msg, 'itemType>
         ) =
         { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>

     [<Extension>]
     static member inline Yield<'msg, 'itemType when 'itemType :> IWindow>
         (
             _: CollectionBuilder<'msg, IApplication, IWindow>,
             x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
         ) =
         { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>