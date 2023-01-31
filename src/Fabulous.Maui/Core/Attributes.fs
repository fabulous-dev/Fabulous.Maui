namespace Fabulous.Maui

open System
open Fabulous
open Fabulous.Maui.Controls
open Microsoft.Maui

module Attributes =
    let inline defineMauiAction<'target> (propertyName: string) (defaultValue: Action) ([<InlineIfLambda>] set: 'target -> Action -> unit) =
        Attributes.defineSimpleScalar
            $"{typeof<'target>.Name}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: (unit -> obj) voption) node ->
                let target = node.Target :?> 'target

                match currOpt with
                | ValueNone -> set target defaultValue
                | ValueSome curr ->
                    let fn args =
                        let r = curr args
                        Dispatcher.dispatch node r

                    set target fn

                let element = node.Target :?> FabElement

                if element.Handler <> null then
                    element.Handler.UpdateValue(propertyName))

    let inline defineMauiAction'<'target, 'args>
        (propertyName: string)
        (defaultValue: Action<'args>)
        ([<InlineIfLambda>] set: 'target -> Action<'args> -> unit)
        =
        Attributes.defineSimpleScalar
            $"{typeof<'target>.Name}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: ('args -> obj) voption) node ->
                let target = node.Target :?> 'target

                match currOpt with
                | ValueNone -> set target defaultValue
                | ValueSome curr ->
                    let fn args =
                        let r = curr args
                        Dispatcher.dispatch node r

                    set target fn

                let element = node.Target :?> FabElement

                if element.Handler <> null then
                    element.Handler.UpdateValue(propertyName))

    let defineMauiProperty'<'target, 'value when 'value: equality> (propertyName: string) (defaultValueFn: unit -> 'value) (set: 'target -> 'value -> unit) =
        Attributes.defineSimpleScalarWithEquality $"{typeof<'target>.Name}_{propertyName}" (fun _ currOpt node ->
            let target = node.Target :?> 'target

            match currOpt with
            | ValueNone -> set target (defaultValueFn())
            | ValueSome curr -> set target curr

            let element = node.Target :?> FabElement

            if element.Handler <> null then
                element.Handler.UpdateValue(propertyName))

    let defineMauiProperty<'target, 'value when 'value: equality> (propertyName: string) (defaultValue: 'value) (set: 'target -> 'value -> unit) =
        defineMauiProperty'<'target, 'value> propertyName (fun () -> defaultValue) set

    let defineMauiAttachedData<'target, 'value when 'target :> IView and 'value: equality> (propertyName: string) (defaultValue: 'value) =
        defineMauiProperty'<'target, 'value> propertyName (fun () -> defaultValue) (fun target value -> target.SetAttachedData(propertyName, value))

    let inline defineMauiPropertyWithEvent<'target, 'value when 'value: equality>
        (propertyName: string)
        (defaultValue: 'value)
        (defaultEvent: Action<'value>)
        ([<InlineIfLambda>] set: 'target -> 'value * Action<'value> -> unit)
        =
        Attributes.defineSimpleScalar
            $"{typeof<'target>.Name}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: ValueEventData<'value, 'value> voption) node ->
                let target = node.Target :?> 'target

                match currOpt with
                | ValueNone -> set target (defaultValue, defaultEvent)
                | ValueSome data ->
                    let fn args =
                        let r = data.Event args
                        Dispatcher.dispatch node r

                    set target (data.Value, fn)

                let element = node.Target :?> FabElement

                if element.Handler <> null then
                    element.Handler.UpdateValue(propertyName))

    let inline defineMauiPropertyWidget<'target, 'value when 'value: null>
        (propertyName: string)
        ([<InlineIfLambda>] get: 'target -> obj)
        ([<InlineIfLambda>] set: 'target -> 'value -> unit)
        =
        Attributes.definePropertyWidget $"{typeof<'target>.Name}_{propertyName}" (fun target -> get(target :?> 'target)) (fun t value ->
            let target = t :?> 'target
            set target value

            let element = t :?> FabElement

            if element.Handler <> null then
                element.Handler.UpdateValue(propertyName))

    let defineMauiWidgetCollection<'target, 'itemType>
        name
        (getCollection: 'target -> System.Collections.Generic.IList<'itemType>)
        (handlerUpdate: 'target -> unit)
        =
        let applyDiff _ (diffs: WidgetCollectionItemChanges) (node: IViewNode) =
            let target = node.Target :?> 'target
            let targetColl = getCollection target

            // If the collection is mutated (everything except Change.Update), we need to warn the handler
            let mutable shouldUpdateHandler = false

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Remove(index, widget) ->
                    let itemNode = node.TreeContext.GetViewNode(box targetColl.[index])

                    // Trigger the unmounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Unmounted
                    itemNode.Disconnect()

                    // Remove the child from the UI tree
                    targetColl.RemoveAt(index)

                    shouldUpdateHandler <- true

                | _ -> ()

            for diff in diffs do
                match diff with
                | WidgetCollectionItemChange.Insert(index, widget) ->
                    let struct (itemNode, view) = Helpers.createViewForWidget node widget

                    // Insert the new child into the UI tree
                    targetColl.Insert(index, unbox view)

                    // Trigger the mounted event
                    Dispatcher.dispatchEventForAllChildren itemNode widget Lifecycle.Mounted

                    shouldUpdateHandler <- true

                | WidgetCollectionItemChange.Update(index, widgetDiff) ->
                    let childNode = node.TreeContext.GetViewNode(box targetColl.[index])

                    childNode.ApplyDiff(&widgetDiff)

                | WidgetCollectionItemChange.Replace(index, oldWidget, newWidget) ->
                    let prevItemNode = node.TreeContext.GetViewNode(box targetColl.[index])

                    let struct (nextItemNode, view) = Helpers.createViewForWidget node newWidget

                    // Trigger the unmounted event for the old child
                    Dispatcher.dispatchEventForAllChildren prevItemNode oldWidget Lifecycle.Unmounted
                    prevItemNode.Disconnect()

                    // Replace the existing child in the UI tree at the index with the new one
                    targetColl.[index] <- unbox view

                    // Trigger the mounted event for the new child
                    Dispatcher.dispatchEventForAllChildren nextItemNode newWidget Lifecycle.Mounted

                    shouldUpdateHandler <- true

                | _ -> ()

            if shouldUpdateHandler then
                handlerUpdate target

        let updateNode _ (newValueOpt: ArraySlice<Widget> voption) (node: IViewNode) =
            let target = node.Target :?> 'target
            let targetColl = getCollection target
            targetColl.Clear()

            match newValueOpt with
            | ValueNone -> ()
            | ValueSome widgets ->
                for widget in ArraySlice.toSpan widgets do
                    let struct (_, view) = Helpers.createViewForWidget node widget

                    targetColl.Add(unbox view)

            handlerUpdate target

        Attributes.defineWidgetCollection name applyDiff updateNode
