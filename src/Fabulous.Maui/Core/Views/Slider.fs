namespace Fabulous.Maui

open Fabulous
open Fabulous.Maui.Controls
open Microsoft.Maui

module Slider =
    let WidgetKey = Widgets.register<FabSlider>()
    
[<AutoOpen>]
module SliderBuilders =
    type Fabulous.Maui.View with
        static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IFabSlider>(
                Slider.WidgetKey,
                Range.MinimumMaximum.WithValue(struct (min, max)),
                Range.Value.WithValue(ValueEventData.create value (onValueChanged >> box))
            )

