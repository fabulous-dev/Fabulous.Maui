namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Handlers.Defaults
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Fabulous
open Fabulous.Maui.Controls

module View' =
    let AutomationId =
        Attributes.defineMauiProperty "AutomationId" ViewDefaults.AutomationId (fun (target: IFabView) -> target.SetAutomationId)

    let Background =
        Attributes.defineMauiProperty "Background" ViewDefaults.Background (fun (target: IFabView) -> target.SetBackground)

    let Clip =
        Attributes.defineMauiPropertyWidget "Clip" (fun (target: IFabView) -> target.Clip) (fun target -> target.SetClip)

    let Focus =
        Attributes.defineMauiPropertyWithEvent "IsFocused" ViewDefaults.IsFocused ViewDefaults.OnFocusChanged (fun (target: IFabView) -> target.SetFocus)

    let FlowDirection =
        Attributes.defineMauiProperty "FlowDirection" ViewDefaults.FlowDirection (fun (target: IFabView) -> target.SetFlowDirection)

    let Height =
        Attributes.defineMauiProperty "Height" ViewDefaults.Height (fun (target: IFabView) -> target.SetHeight)

    let HorizontalLayoutAlignment =
        Attributes.defineMauiProperty "HorizontalLayoutAlignment" ViewDefaults.HorizontalLayoutAlignment (fun (target: IFabView) ->
            target.SetHorizontalLayoutAlignment)

    let InputTransparent =
        Attributes.defineMauiProperty "InputTransparent" ViewDefaults.InputTransparent (fun (target: IFabView) -> target.SetInputTransparent)

    let IsEnabled =
        Attributes.defineMauiProperty "IsEnabled" ViewDefaults.IsEnabled (fun (target: IFabView) -> target.SetIsEnabled)

    let Margin =
        Attributes.defineMauiProperty' "Margin" ViewDefaults.CreateDefaultMargin (fun (target: IFabView) -> target.SetMargin)

    let MaximumHeight =
        Attributes.defineMauiProperty "MaximumHeight" ViewDefaults.MaximumHeight (fun (target: IFabView) -> target.SetMaximumHeight)

    let MaximumWidth =
        Attributes.defineMauiProperty "MaximumWidth" ViewDefaults.MaximumWidth (fun (target: IFabView) -> target.SetMaximumWidth)

    let MinimumHeight =
        Attributes.defineMauiProperty "MinimumHeight" ViewDefaults.MinimumHeight (fun (target: IFabView) -> target.SetMinimumHeight)

    let MinimumWidth =
        Attributes.defineMauiProperty "MinimumWidth" ViewDefaults.MinimumWidth (fun (target: IFabView) -> target.SetMinimumWidth)

    let Opacity =
        Attributes.defineMauiProperty "Opacity" ViewDefaults.Opacity (fun (target: IFabView) -> target.SetOpacity)

    let Semantics =
        Attributes.defineMauiProperty' "Semantics" ViewDefaults.CreateDefaultSemantics (fun (target: IFabView) -> target.SetSemantics)

    let Shadow =
        Attributes.defineMauiPropertyWidget "Shadow" (fun (target: IFabView) -> target.Shadow) (fun target -> target.SetShadow)

    let VerticalLayoutAlignment =
        Attributes.defineMauiProperty "VerticalLayoutAlignment" ViewDefaults.VerticalLayoutAlignment (fun (target: IFabView) ->
            target.SetVerticalLayoutAlignment)

    let Visibility =
        Attributes.defineMauiProperty "Visibility" ViewDefaults.Visibility (fun (target: IFabView) -> target.SetVisibility)

    let Width =
        Attributes.defineMauiProperty "Width" ViewDefaults.Width (fun (target: IFabView) -> target.SetWidth)

    let ZIndex =
        Attributes.defineMauiProperty "ZIndex" ViewDefaults.ZIndex (fun (target: IFabView) -> target.SetZIndex)

[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member automationId(this: WidgetBuilder<'msg, #IFabView>, value: string) =
        this.AddScalar(View'.AutomationId.WithValue(value))

    [<Extension>]
    static member background(this: WidgetBuilder<'msg, #IFabView>, value: Paint) =
        this.AddScalar(View'.Background.WithValue(value))

    [<Extension>]
    static member clip(this: WidgetBuilder<'msg, #IFabView>, value: WidgetBuilder<'msg, #IShape>) =
        this.AddWidget(View'.Clip.WithValue(value.Compile()))

    [<Extension>]
    static member focus(this: WidgetBuilder<'msg, #IFabView>, isFocused: bool, onFocusChanged: bool -> 'msg) =
        this.AddScalar(View'.Focus.WithValue(ValueEventData.create isFocused (onFocusChanged >> box)))

    [<Extension>]
    static member flowDirection(this: WidgetBuilder<'msg, #IFabView>, value: FlowDirection) =
        this.AddScalar(View'.FlowDirection.WithValue(value))

    [<Extension>]
    static member height(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.Height.WithValue(value))

    [<Extension>]
    static member horizontalLayoutAlignment(this: WidgetBuilder<'msg, #IFabView>, value: LayoutAlignment) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(value))

    [<Extension>]
    static member inputTransparent(this: WidgetBuilder<'msg, #IFabView>, value: bool) =
        this.AddScalar(View'.InputTransparent.WithValue(value))

    [<Extension>]
    static member isEnabled(this: WidgetBuilder<'msg, #IFabView>, value: bool) =
        this.AddScalar(View'.IsEnabled.WithValue(value))

    [<Extension>]
    static member margin(this: WidgetBuilder<'msg, #IFabView>, value: Thickness) =
        this.AddScalar(View'.Margin.WithValue(value))

    [<Extension>]
    static member maximumHeight(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MaximumHeight.WithValue(value))

    [<Extension>]
    static member maximumWidth(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MaximumWidth.WithValue(value))

    [<Extension>]
    static member minimumHeight(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MinimumHeight.WithValue(value))

    [<Extension>]
    static member minimumWidth(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.MinimumWidth.WithValue(value))

    [<Extension>]
    static member Opacity(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.Opacity.WithValue(value))

    [<Extension>]
    static member semantics(this: WidgetBuilder<'msg, #IFabView>, value: Semantics) =
        this.AddScalar(View'.Semantics.WithValue(value))

    [<Extension>]
    static member shadow(this: WidgetBuilder<'msg, #IFabView>, value: WidgetBuilder<'msg, #IShadow>) =
        this.AddWidget(View'.Shadow.WithValue(value.Compile()))

    [<Extension>]
    static member verticalLayoutAlignment(this: WidgetBuilder<'msg, #IFabView>, value: LayoutAlignment) =
        this.AddScalar(View'.VerticalLayoutAlignment.WithValue(value))

    [<Extension>]
    static member visibility(this: WidgetBuilder<'msg, #IFabView>, value: Visibility) =
        this.AddScalar(View'.Visibility.WithValue(value))

    [<Extension>]
    static member width(this: WidgetBuilder<'msg, #IFabView>, value: float) =
        this.AddScalar(View'.Width.WithValue(value))

    [<Extension>]
    static member zIndex(this: WidgetBuilder<'msg, #IFabView>, value: int) =
        this.AddScalar(View'.ZIndex.WithValue(value))

[<Extension>]
type ViewExtraModifiers =
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.horizontalLayoutAlignment(LayoutAlignment.Center)

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabView>) =
        this.verticalLayoutAlignment(LayoutAlignment.Center)

    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.horizontalLayoutAlignment(LayoutAlignment.Start)

    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IFabView>) =
        this.verticalLayoutAlignment(LayoutAlignment.Start)

    [<Extension>]
    static member margin(this: WidgetBuilder<'msg, #IFabView>, uniformSize: float) = this.margin(Thickness(uniformSize))

    [<Extension>]
    static member margin(this: WidgetBuilder<'msg, #IFabView>, horizontalSize: float, verticalSize: float) =
        this.margin(Thickness(horizontalSize, verticalSize))

    [<Extension>]
    static member margin(this: WidgetBuilder<'msg, #IFabView>, left: float, top: float, right: float, bottom: float) =
        this.margin(Thickness(left, top, right, bottom))
