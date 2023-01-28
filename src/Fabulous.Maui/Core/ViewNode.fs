namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls

module ViewNode =
    let get (target: obj) = (target :?> FabElement).ViewNode
    let set (value: IViewNode) (target: FabElement) = target.ViewNode <- value
