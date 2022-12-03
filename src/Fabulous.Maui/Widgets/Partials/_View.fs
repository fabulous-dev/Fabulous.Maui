namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous
open Fabulous.Maui.Controls

module View' =
    let Background = Attributes.defineMauiProperty "Background" ViewDefaults.Background FabView.SetBackground
    let Height = Attributes.defineMauiProperty "Height" ViewDefaults.Height FabView.SetHeight
    let MinimumHeight = Attributes.defineMauiProperty "MinimumHeight" ViewDefaults.MinimumHeight FabView.SetMinimumHeight
    let MinimumWidth = Attributes.defineMauiProperty "MinimumWidth" ViewDefaults.MinimumWidth FabView.SetMinimumWidth
    let HorizontalLayoutAlignment = Attributes.defineMauiProperty "HorizontalLayoutAlignment" ViewDefaults.HorizontalLayoutAlignment FabView.SetHorizontalLayoutAlignment
    let VerticalLayoutAlignment = Attributes.defineMauiProperty "VerticalLayoutAlignment" ViewDefaults.VerticalLayoutAlignment FabView.SetVerticalLayoutAlignment
    let Semantics = Attributes.defineMauiProperty' "Semantics" ViewDefaults.CreateDefaultSemantics FabView.SetSemantics
    
[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member background(this: WidgetBuilder<'msg, #IView>, value: Paint) =
        this.AddScalar(View'.Background.WithValue(value))
        
    [<Extension>]
    static member height(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.Height.WithValue(value))
        
    [<Extension>]
    static member minimumHeight(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.MinimumHeight.WithValue(value))
        
    [<Extension>]
    static member minimumWidth(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.MinimumWidth.WithValue(value))
        
    [<Extension>]
    static member horizontalLayoutAlignment(this: WidgetBuilder<'msg, #IView>, value: LayoutAlignment) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(value))
        
    [<Extension>]
    static member semantics(this: WidgetBuilder<'msg, #IView>, value: Semantics) =
        this.AddScalar(View'.Semantics.WithValue(value))
        
[<Extension>]
type ViewExtraModifiers =
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(LayoutAlignment.Center))
        
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(View'.VerticalLayoutAlignment.WithValue(LayoutAlignment.Center))