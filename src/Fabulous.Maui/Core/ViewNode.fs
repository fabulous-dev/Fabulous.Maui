namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls

module ViewNode =
    let get (target: obj) = (target :?> IFabElement).ViewNode
    let set (value: IViewNode) (target: IFabElement) = target.ViewNode <- value
