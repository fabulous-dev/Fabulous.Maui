namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.ApplicationModel
open Fabulous
open Fabulous.Maui
open Microsoft.Maui.FabCompat

[<AbstractClass; Sealed>]
type ThemeAware =
    static member Of(light: 'T, dark: 'T) =
        if AppInfoFixed.RequestedTheme = AppTheme.Dark then
            dark
        else
            light

module ThemeAwareProgram =
    type Model<'model> = { Theme: AppTheme; Model: 'model }

    type Msg<'msg> =
        | ThemeChanged of AppTheme
        | ModelMsg of 'msg

    let init (init: 'arg -> 'model * Cmd<'msg>) (arg: 'arg) =
        let model, cmd = init arg

        { Theme = AppInfoFixed.RequestedTheme
          Model = model },
        Cmd.map ModelMsg cmd

    let update (update: 'msg * 'model -> 'model * Cmd<'msg>) (msg: Msg<'msg>, model: Model<'model>) =
        match msg with
        | ThemeChanged theme -> { model with Theme = theme }, Cmd.none
        | ModelMsg msg ->
            let subModel, cmd = update(msg, model.Model)
            { model with Model = subModel }, Cmd.map ModelMsg cmd

    let view (subView: 'model -> WidgetBuilder<'msg, #IApplication>) (model: Model<'model>) =
        (View.map ModelMsg (subView model.Model)).onThemeChanged(ThemeChanged)
