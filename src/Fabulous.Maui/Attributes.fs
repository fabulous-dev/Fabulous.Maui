namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls

module Attributes =
    let defineMauiEvent<'args> (name: string) (propertyName: string) (set: obj -> ('args -> unit) -> unit) (unset: obj -> unit) =
        Attributes.defineSimpleScalar
            name
            ScalarAttributeComparers.noCompare
            (fun prevOpt currOpt node ->
                let target = node.Target :?> BaseNode
                match currOpt with
                | ValueNone -> unset target
                | ValueSome curr ->
                    let fn args =
                        let r = curr args
                        Dispatcher.dispatch node r
                    set target fn
                if target.Handler <> null then target.Handler.UpdateValue(propertyName)
            )

    let defineMauiSimpleScalarWithEquality (name: string) (propertyName: string) (updateNode: 'T voption -> 'T voption -> BaseNode -> unit) =
        Attributes.defineSimpleScalarWithEquality name (fun prevOpt currOpt node ->
            let target = node.Target :?> BaseNode
            updateNode prevOpt currOpt target
            if target.Handler <> null then target.Handler.UpdateValue(propertyName)
        )
        
    let defineMauiPropertyWidget (name: string) (propertyName: string) (get: obj -> obj) (set: obj -> 'T -> unit) =
        Attributes.definePropertyWidget name get (fun target value ->
            let target = target :?> BaseNode
            set target value
            if target.Handler <> null then target.Handler.UpdateValue(propertyName)
        )