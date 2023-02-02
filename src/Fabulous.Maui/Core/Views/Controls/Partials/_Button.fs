namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Button =
    let Clicked =
        Attributes.defineMauiAction "Clicked" ButtonDefaults.OnClicked (fun (target: IFabButton) -> target.SetOnClicked)
    
    let Pressed =
        Attributes.defineMauiAction "Pressed" ButtonDefaults.OnPressed (fun (target: IFabButton) -> target.SetOnPressed)
    
    let Released =
        Attributes.defineMauiAction "Released" ButtonDefaults.OnReleased (fun (target: IFabButton) -> target.SetOnReleased)
