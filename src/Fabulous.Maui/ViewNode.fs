namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls

module ViewNode =
    let get (target: obj) = (target :?> BaseNode).ViewNode
    let set (value: IViewNode) (target: BaseNode) = target.ViewNode <- value
