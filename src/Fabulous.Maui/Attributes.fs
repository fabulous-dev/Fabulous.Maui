namespace Fabulous.Maui

open System
open Fabulous
open Fabulous.Maui.Controls

module Attributes =
    let defineMauiAction<'target> (propertyName: string) (defaultValue: Action) (set: 'target * Action -> unit) =
        Attributes.defineSimpleScalar
            $"{typeof<'target>.Name}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: (unit -> obj) voption) node ->
                let target = node.Target :?> 'target
                match currOpt with
                | ValueNone -> set(target, defaultValue)
                | ValueSome curr ->
                    let fn args =
                        let r = curr args
                        Dispatcher.dispatch node r
                    set(target, fn)
                    
                let element = node.Target :?> FabElement
                if element.Handler <> null then element.Handler.UpdateValue(propertyName)
            )
            
    let defineMauiAction'<'target, 'args> (propertyName: string) (defaultValue: Action<'args>) (set: 'target * Action<'args> -> unit) =
        Attributes.defineSimpleScalar
            $"{typeof<'target>.Name}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: ('args -> obj) voption) node ->
                let target = node.Target :?> 'target
                match currOpt with
                | ValueNone -> set(target, defaultValue)
                | ValueSome curr ->
                    let fn args =
                        let r = curr args
                        Dispatcher.dispatch node r
                    set(target, fn)
                    
                let element = node.Target :?> FabElement
                if element.Handler <> null then element.Handler.UpdateValue(propertyName)
            )
    
    let inline defineMauiEvent<'args> (containerName: string) (propertyName: string) (defaultValue: 'args -> unit) ([<InlineIfLambda>] set: FabElement * ('args -> unit) -> unit) =
        Attributes.defineSimpleScalar
            $"{containerName}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun prevOpt currOpt node ->
                let target = node.Target :?> FabElement
                match currOpt with
                | ValueNone -> set(target, defaultValue)
                | ValueSome curr ->
                    let fn args =
                        let r = curr args
                        Dispatcher.dispatch node r
                    set(target, fn)
                if target.Handler <> null then target.Handler.UpdateValue(propertyName)
            )

    let inline defineMauiProperty'<'target, 'value when 'value : equality> (propertyName: string) (defaultValueFn: unit -> 'value) ([<InlineIfLambda>] set: 'target * 'value -> unit) =
        Attributes.defineSimpleScalarWithEquality
           $"{typeof<'target>.Name}_{propertyName}"
           (fun _ currOpt node ->
                let target = node.Target :?> 'target
                match currOpt with
                | ValueNone -> set(target, defaultValueFn ())
                | ValueSome curr -> set(target, curr)
                
                let element = node.Target :?> FabElement
                if element.Handler <> null then element.Handler.UpdateValue(propertyName)
            )
        
    let inline defineMauiProperty<'target, 'value when 'value : equality> (propertyName: string) (defaultValue: 'value) ([<InlineIfLambda>] set: 'target * 'value -> unit) =
        defineMauiProperty'<'target, 'value> propertyName (fun () -> defaultValue) set
        
    let inline defineMauiPropertyWidget<'target, 'value when 'value : null> (propertyName: string) ([<InlineIfLambda>] get: 'target -> obj) ([<InlineIfLambda>] set: 'target -> 'value -> unit) =
        Attributes.definePropertyWidget
            $"{typeof<'target>.Name}_{propertyName}"
            (fun target -> get (target :?> 'target))
            (fun t value ->
                let target = t :?> 'target
                set target value
                
                let element = t :?> FabElement
                if element.Handler <> null then element.Handler.UpdateValue(propertyName)
            )