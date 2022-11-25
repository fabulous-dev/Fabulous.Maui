namespace Fabulous.Maui

open Fabulous.Maui.Controls

module Button =
    let Clicked =
        Attributes.defineMauiEvent<unit>
            "Button_Clicked"
            "Clicked"
            (fun target fn -> (target :?> FabButton).OnClicked <- fn)
            (fun target -> (target :?> FabButton).OnClicked <- ButtonDefaults.OnClicked)
