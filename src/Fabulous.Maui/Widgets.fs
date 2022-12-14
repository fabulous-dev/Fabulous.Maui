namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui.Controls
open Microsoft.Maui.ApplicationModel

/// Holds all widgets definitions
[<AbstractClass; Sealed>]
type View =
    class
    end

module Widgets =
    let registerWithAdditionalSetup<'T when 'T :> FabElement and 'T: (new: unit -> 'T)> (additionalSetup: 'T -> IViewNode -> unit) =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = typeof<'T>.Name
              TargetType = typeof<'T>
              CreateView =
                  fun (widget, treeContext, parentNode) ->
                    treeContext.Logger.Debug("Creating view for {0}", typeof<'T>.Name)

                    let view = new 'T()
                    let weakReference = WeakReference(view)

                    let parentNode =
                        match parentNode with
                        | ValueNone -> None
                        | ValueSome node -> Some node

                    match parentNode with
                    | None -> ()
                    | Some node -> view.Parent <- node.Target :?> FabElement

                    let node = ViewNode(parentNode, treeContext, weakReference)

                    ViewNode.set node view

                    additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    struct (node :> IViewNode, box view) }

        WidgetDefinitionStore.set key definition
        key

    let register<'T when 'T :> FabElement and 'T: (new: unit -> 'T)> () =
        registerWithAdditionalSetup<'T>(fun _ _ -> ())
        
[<Extension>]
type FabElementExtensions =
    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #Microsoft.Maui.IElement>, fn: WidgetBuilder<'msg, #Microsoft.Maui.IElement> -> WidgetBuilder<'msg, #Microsoft.Maui.IElement>) =
        fn this