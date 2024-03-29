namespace Fabulous.Maui.Compatibility

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabCompatDragGestureRecognizer =
    inherit IFabCompatGestureRecognizer

module DragGestureRecognizer =
    let WidgetKey = CompatWidgets.register<DragGestureRecognizer>()

    let CanDrag = Attributes.defineBindableBool DragGestureRecognizer.CanDragProperty

    let DragStarting =
        Attributes.defineEvent<DragStartingEventArgs> "DragGestureRecognizer_DragStarting" (fun target -> (target :?> DragGestureRecognizer).DragStarting)

    let DropCompleted =
        Attributes.defineEvent<DropCompletedEventArgs> "DragGestureRecognizer_DropCompleted" (fun target -> (target :?> DragGestureRecognizer).DropCompleted)


[<AutoOpen>]
module DragGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        static member inline DragGestureRecognizer<'msg>(onDragStarting: DragStartingEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabCompatDragGestureRecognizer>(
                DragGestureRecognizer.WidgetKey,
                DragGestureRecognizer.DragStarting.WithValue(fun args -> onDragStarting args |> box)
            )

[<Extension>]
type DragGestureRecognizerModifiers =

    /// <summary>Sets whether users are allowed to drag</summary>
    /// <param name="value">true to allow users to drag; otherwise, false</param>
    [<Extension>]
    static member inline canDrag(this: WidgetBuilder<'msg, #IFabCompatDragGestureRecognizer>, value: bool) =
        this.AddScalar(DragGestureRecognizer.CanDrag.WithValue(value))

    [<Extension>]
    static member inline onDropCompleted(this: WidgetBuilder<'msg, #IFabCompatDragGestureRecognizer>, onDropCompleted: 'msg) =
        this.AddScalar(DragGestureRecognizer.DropCompleted.WithValue(fun _ -> onDropCompleted |> box))
