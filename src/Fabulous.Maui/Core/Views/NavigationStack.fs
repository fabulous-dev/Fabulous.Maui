namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui
open Fabulous.Maui.Controls
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui

module NavigationStack =
    let WidgetKey = Widgets.register<FabNavigationStack>()
    
    let Controller = Attributes.defineMauiProperty "Controller" NavigationStackDefaults.Controller (fun (target: IFabNavigationStack) -> target.SetController)
    
    let Stack = Attributes.defineMauiWidgetCollection "Stack" (fun (target: FabNavigationStack) -> target.Stack) (fun target -> target.NotifyStackChanged())
    
[<AutoOpen>]
module NavigationStackBuilders =    
    type Fabulous.Maui.View with
        static member inline NavigationStack(paths: seq<'path>, _, router: 'path -> WidgetBuilder<'msg, #IView>) =
            let children =
                paths
                |> Seq.map (fun path -> (router path).Compile())
                |> Array.ofSeq
                
            let children =
                match ArraySlice.fromArray children with
                | ValueNone -> ArraySlice.emptyWithNull()
                | ValueSome slice -> slice
            
            WidgetBuilder<'msg, IFabNavigationStack>(
                NavigationStack.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueNone,
                    ValueSome [| NavigationStack.Stack.WithValue(children) |]
                )
            )
            
[<Extension>]
type NavigationStackModifiers =
    [<Extension>]
    static member inline controller(this: WidgetBuilder<'msg, IFabNavigationStack>, controller: NavigationStackController<'path>) =
        this.AddScalar(NavigationStack.Controller.WithValue(controller.Controller))