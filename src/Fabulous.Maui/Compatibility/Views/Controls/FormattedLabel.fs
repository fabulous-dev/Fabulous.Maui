namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls

type IFabCompatFormattedLabel =
    inherit IFabCompatLabel

module FormattedLabel =
    let WidgetKey = CompatWidgets.register<Label>()

    let Spans =
        Attributes.defineListWidgetCollection "FormattedString_Spans" (fun target ->
            let label = target :?> Label

            if label.FormattedText = null then
                label.FormattedText <- FormattedString()

            label.FormattedText.Spans)

[<AutoOpen>]
module FormattedLabelBuilders =
    type Fabulous.Maui.View with

        static member inline FormattedLabel<'msg>() =
            CollectionBuilder<'msg, IFabCompatFormattedLabel, IFabCompatSpan>(FormattedLabel.WidgetKey, FormattedLabel.Spans)

[<Extension>]
type FormattedLabelModifiers =
    /// <summary>Link a ViewRef to access the direct Label control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompatFormattedLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type FormattedLabelCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabCompatFormattedLabel and 'itemType :> IFabCompatSpan>
        (
            _: CollectionBuilder<'msg, 'marker, IFabCompatSpan>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabCompatFormattedLabel and 'itemType :> IFabCompatSpan>
        (
            _: CollectionBuilder<'msg, 'marker, IFabCompatSpan>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
        