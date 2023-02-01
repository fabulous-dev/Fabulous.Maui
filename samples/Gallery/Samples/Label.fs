namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module Label =
    let view () =
        VStack(spacing = 15.) {
            Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .alignTextStartHorizontal()

            Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .centerTextHorizontal()

            Label("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .alignTextEndHorizontal()

            Border(
                VStack(8.) {
                    Label("Custom font regular").font(Font.OfSize(Fonts.SourceSansProRegular, 20.))

                    Label("Custom font bold").font(Font.OfSize(Fonts.SourceSansProBold, 20.))

                    Label("Custom font italic").font(Font.OfSize(Fonts.SourceSansProItalic, 20.))

                    Label("Custom font italic bold")
                        .font(Font.OfSize(Fonts.SourceSansProBoldItalic, 20.))
                }
            )

            Border(
                VStack(8.0) {
                    Label("Underline").textDecorations(TextDecorations.Underline)

                    Label("Strikethrough").textDecorations(TextDecorations.Strikethrough)

                    Border(
                        VStack() {
                            Label("🏻 👌🏻")
                            Label("🏼 👌🏼")
                            Label("🏽 👌🏽")
                            Label("🏾 👌🏾")
                            Label("🏿 👌🏿")
                        }
                    )

                    Border(Label("👪 👨‍👩‍👧 👨‍👩‍👧‍👦"))
                }
            )
        }

    let sampleProgram = Helper.createStatelessProgram view

    let sample =
        { Name = "Label"
          Description = "A label widget that displays text on the interface"
          Program = sampleProgram }
