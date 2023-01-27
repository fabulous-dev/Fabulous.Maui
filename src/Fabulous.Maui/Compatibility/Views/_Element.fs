namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCompatElement = inherit IElement

module Element =
    let AutomationId =
        Attributes.defineBindableWithEquality<string> Element.AutomationIdProperty

[<Extension>]
type ElementModifiers =
    /// Sets a value that allows the automation framework to find and interact with this element.
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IFabCompatElement>, value: string) =
        this.AddScalar(Element.AutomationId.WithValue(value))

    [<Extension>]
    static member inline onMounted(this: WidgetBuilder<'msg, #IFabCompatElement>, value: 'msg) =
        this.AddScalar(Lifecycle.Mounted.WithValue(value))

    [<Extension>]
    static member inline onUnmounted(this: WidgetBuilder<'msg, #IFabCompatElement>, value: 'msg) =
        this.AddScalar(Lifecycle.Unmounted.WithValue(value))
