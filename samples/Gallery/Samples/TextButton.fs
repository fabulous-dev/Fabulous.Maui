namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module TextButton =
    let view () =
        VStack(spacing = 15.) {
            TextButton("Regular button", ())

            TextButton("Disabled button", ()).isEnabled(false)

            TextButton("White text, red background", ())
                .background(SolidPaint(Colors.Red))
                .textColor(Colors.White)
                .width(250.)
        }

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "TextButton"
          Description = "A button widget that reacts to touch events"
          Program = sampleProgram }
