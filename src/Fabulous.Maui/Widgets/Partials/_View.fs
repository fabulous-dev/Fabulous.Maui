namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous
open Fabulous.Maui.Controls

module View' =
    let Background = Attributes.defineMauiProperty "View" "Background" ViewDefaults.Background FabViewSetters.SetBackground
    let Height = Attributes.defineMauiProperty "View" "Height" ViewDefaults.Height FabViewSetters.SetHeight
    let MinimumHeight = Attributes.defineMauiProperty "View" "MinimumHeight" ViewDefaults.MinimumHeight FabViewSetters.SetMinimumHeight
    let MinimumWidth = Attributes.defineMauiProperty "View" "MinimumWidth" ViewDefaults.MinimumWidth FabViewSetters.SetMinimumWidth
    let HorizontalLayoutAlignment = Attributes.defineMauiProperty "View" "HorizontalLayoutAlignment" ViewDefaults.HorizontalLayoutAlignment FabViewSetters.SetHorizontalLayoutAlignment
    let VerticalLayoutAlignment = Attributes.defineMauiProperty "View" "VerticalLayoutAlignment" ViewDefaults.VerticalLayoutAlignment FabViewSetters.SetVerticalLayoutAlignment
    let Semantics = Attributes.defineMauiProperty' "View" "Semantics" ViewDefaults.CreateDefaultSemantics FabViewSetters.SetSemantics
    
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