namespace Fabulous.Maui.Compatibility

open System
open Fabulous

module CompatWidgets =
    let registerWithAdditionalSetup<'T when 'T :> Microsoft.Maui.Controls.BindableObject and 'T: (new: unit -> 'T)> (additionalSetup: 'T -> IViewNode -> unit) =
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

                    let node = ViewNode(parentNode, treeContext, weakReference)

                    ViewNode.set node view

                    additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    struct (node :> IViewNode, box view)
              AttachView =
                fun (widget, treeContext, parentNode, view) ->
                    treeContext.Logger.Debug("Attaching view for {0}", typeof<'T>.Name)

                    let view = unbox<'T> view
                    let weakReference = WeakReference(view)

                    let parentNode =
                        match parentNode with
                        | ValueNone -> None
                        | ValueSome node -> Some node

                    let node = ViewNode(parentNode, treeContext, weakReference)

                    ViewNode.set node view

                    additionalSetup view node

                    Reconciler.update treeContext.CanReuseView ValueNone widget node
                    node :> IViewNode }

        WidgetDefinitionStore.set key definition
        key

    let register<'T when 'T :> Microsoft.Maui.Controls.BindableObject and 'T: (new: unit -> 'T)> () =
        registerWithAdditionalSetup<'T>(fun _ _ -> ())
