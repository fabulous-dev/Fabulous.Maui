namespace Fabulous.Maui

open System
open Fabulous
open Fabulous.Maui.Controls

module Attributes =
    let defineMauiAction (containerName: string) (propertyName: string) (defaultValue: Action) (set: FabElement * Action -> unit) =
        Attributes.defineSimpleScalar
            $"{containerName}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: (unit -> obj) voption) node ->
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
            
    let defineMauiAction'<'args> (containerName: string) (propertyName: string) (defaultValue: Action<'args>) (set: FabElement * Action<'args> -> unit) =
        Attributes.defineSimpleScalar
            $"{containerName}_{propertyName}"
            ScalarAttributeComparers.noCompare
            (fun _ (currOpt: ('args -> obj) voption) node ->
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
    
    let defineMauiEvent<'args> (containerName: string) (propertyName: string) (defaultValue: 'args -> unit) (set: FabElement * ('args -> unit) -> unit) =
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

    let defineMauiProperty' (containerName: string) (propertyName: string) (defaultValueFn: unit -> 'T) (set: FabElement * 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality $"{containerName}_{propertyName}" (fun _ currOpt node ->
            let target = node.Target :?> FabElement
            match currOpt with
            | ValueNone -> set(target, defaultValueFn ())
            | ValueSome curr -> set(target, curr)
            if target.Handler <> null then target.Handler.UpdateValue(propertyName)
        )
        
    let defineMauiProperty (containerName: string) (propertyName: string) (defaultValue: 'T) (set: FabElement * 'T -> unit) =
        defineMauiProperty' containerName propertyName (fun () -> defaultValue) set
        
    let defineMauiPropertyWidget (name: string) (propertyName: string) (get: obj -> obj) (set: obj -> 'T -> unit) =
        Attributes.definePropertyWidget name get (fun target value ->
            let target = target :?> FabElement
            set target value
            if target.Handler <> null then target.Handler.UpdateValue(propertyName)
        )