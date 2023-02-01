namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults
open Fabulous.Maui.Controls

module Button =
    let Clicked =
        Attributes.defineMauiAction "Clicked" ButtonDefaults.OnClicked (fun (target: IFabButton) -> target.SetOnClicked)
