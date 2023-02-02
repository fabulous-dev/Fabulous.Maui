namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui
open Fabulous.Maui.Controls

module SharedAttributes =
    let inline defineAttachedData<'value when 'value: equality> (key: string) =
        Attributes.defineSimpleScalarWithEquality<'value> $"AttachedData_{key}" (fun _ currOpt node ->
            let target = node.Target :?> IView

            match currOpt with
            | ValueNone -> target.ClearAttachedData(key)
            | ValueSome value -> target.SetAttachedData(key, value))
