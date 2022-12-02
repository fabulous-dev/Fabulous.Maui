namespace Fabulous.Maui

open Microsoft.Maui.Handlers.Defaults;
open Fabulous.Maui.Controls

module Button =
    let Clicked = Attributes.defineMauiAction "Button" "Clicked" ButtonDefaults.OnClicked FabButtonSetters.SetOnClicked
