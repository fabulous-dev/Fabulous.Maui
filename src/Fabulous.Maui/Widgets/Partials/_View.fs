namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous
open Fabulous.Maui.Controls

module View' =
    let Background = Attributes.defineMauiSimpleScalarWithEquality "View_Background" "Background" (fun _ (currOpt: Paint voption) target ->
        let target = target :?> FabView
        match currOpt with
        | ValueNone -> target.Background <- ViewDefaults.Background
        | ValueSome curr -> target.Background <- curr
    )
    
    let Height = Attributes.defineMauiSimpleScalarWithEquality "View_Height" "Height" (fun _ currOpt target ->
        let target = target :?> FabView
        match currOpt with
        | ValueNone -> target.Height <- ViewDefaults.Height
        | ValueSome curr -> target.Height <- curr
    )
    
    let HorizontalLayoutAlignment = Attributes.defineMauiSimpleScalarWithEquality "View_HorizontalLayoutAlignment" "HorizontalLayoutAlignment" (fun _ currOpt target ->
        let target = target :?> FabView
        match currOpt with
        | ValueNone -> target.HorizontalLayoutAlignment <- ViewDefaults.HorizontalLayoutAlignment
        | ValueSome curr -> target.HorizontalLayoutAlignment <- curr
    )
    
    let VerticalLayoutAlignment = Attributes.defineMauiSimpleScalarWithEquality "View_HorizontalLayoutAlignment" "HorizontalLayoutAlignment" (fun _ currOpt target ->
        let target = target :?> FabView
        match currOpt with
        | ValueNone -> target.VerticalLayoutAlignment <- ViewDefaults.VerticalLayoutAlignment
        | ValueSome curr -> target.VerticalLayoutAlignment <- curr
    )
    
[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member background(this: WidgetBuilder<'msg, #IView>, value: Paint) =
        this.AddScalar(View'.Background.WithValue(value))
        
    [<Extension>]
    static member height(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.Height.WithValue(value))
        
    [<Extension>]
    static member horizontalLayoutAlignment(this: WidgetBuilder<'msg, #IView>, value: LayoutAlignment) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(value))
        
[<Extension>]
type ViewExtraModifiers =
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(LayoutAlignment.Center))
        
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(View'.VerticalLayoutAlignment.WithValue(LayoutAlignment.Center))