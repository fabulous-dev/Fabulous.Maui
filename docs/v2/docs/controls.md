# Available widgets

- ✅: A handler is available in Microsoft.Maui.Core and we need to provide a Fabulous.Maui.Core implementation for it


- ❌: A handler is not available in Microsoft.Maui.Core, so we should keep the Fabulous.Maui.Compatibility implementation.  
We should also add a warning to prefer using the Core alternative if available.


- ❓: We don't know yet if a handler is available in Microsoft.Maui.Core. Further investigation is needed.  
Meanwhile, we should keep the Fabulous.Maui.Compatibility implementation.

## Common widgets

| Control                   | Has MAUI Core Handlers | Core          | Compatibility       | Sample    | Comments                      |
|---------------------------|------------------------|---------------|---------------------|-----------|-------------------------------|
| Application               | ✅                      | [Application] | [CompatApplication] | _Missing_ |                               |
| Window                    | ✅                      | [Window]      | N/A                 | _Missing_ |                               |

[Application]: ../../../src/Fabulous.Maui/Core/Views/Application.fs
[CompatApplication]: ../../../src/Fabulous.Maui/Compatibility/Views/CompatApplication.fs

[Window]: ../../../src/Fabulous.Maui/Core/Views/Window.fs

## Control widgets

| Control                   | Has MAUI Core Handlers | Core          | Compatibility       | Sample               | Comments                      |
|---------------------------|------------------------|---------------|---------------------|----------------------|-------------------------------|
| Label                     | ✅                      | [Label]       | [CompatLabel]       | [Label sample]       |                               |
| Image                     | ✅                      | [Image]       | [CompatImage]       | _Missing_            |                               |
| ImageButton               | ✅                      | [ImageButton] | [CompatImageButton] | [ImageButton sample] |                               |
| Slider                    | ✅                      | [Slider]      | [CompatSlider]      | _Missing_            |                               |
| Switch                    | ✅                      | [Switch]      | [CompatSwitch]      | _Missing_            |                               |
| TextButton                | ✅                      | [TextButton]  | N/A                 | [TextButton sample]  |                               |
| CompatButton (was Button) | ❌                      | N/A           | [CompatButton]      | _Missing_            | Prefer TextButton if possible |


[Label]: ../../../src/Fabulous.Maui/Core/Views/Controls/Label.fs
[CompatLabel]: ../../../src/Fabulous.Maui/Compatibility/Views/Controls/CompatLabel.fs
[Label sample]: ../../../samples/Gallery/Samples/Label.fs

[Image]: ../../../src/Fabulous.Maui/Core/Views/Controls/Image.fs
[CompatImage]: ../../../src/Fabulous.Maui/Compatibility/Views/Controls/CompatImage.fs

[ImageButton]: ../../../src/Fabulous.Maui/Core/Views/Controls/ImageButton.fs
[CompatImageButton]: ../../../src/Fabulous.Maui/Compatibility/Views/Controls/CompatImageButton.fs
[ImageButton sample]: ../../../samples/Gallery/Samples/ImageButton.fs

[Slider]: ../../../src/Fabulous.Maui/Core/Views/Controls/Slider.fs
[CompatSlider]: ../../../src/Fabulous.Maui/Compatibility/Views/Controls/CompatSlider.fs

[Switch]: ../../../src/Fabulous.Maui/Core/Views/Controls/Switch.fs
[CompatSwitch]: ../../../src/Fabulous.Maui/Compatibility/Views/Controls/CompatSwitch.fs

[TextButton]: ../../../src/Fabulous.Maui/Core/Views/Controls/TextButton.fs
[TextButton sample]: ../../../samples/Gallery/Samples/TextButton.fs

[CompatButton]: ../../../src/Fabulous.Maui/Compatibility/Views/Controls/CompatButton.fs

## Layout widgets

| Layout         | Has MAUI Core Handlers | Core            | Compatibility       | Sample    | Comments                  |
|----------------|------------------------|-----------------|---------------------|-----------|---------------------------|
| AbsoluteLayout | ❓                      | _Not available_ | [AbsoluteLayout]    | _Missing_ |                           |
| Border         | ✅                      | [Border]        | [CompatBorder]      | _Missing_ |                           |
| ContentView    | ✅                      | [ContentView]   | [CompatContentView] | _Missing_ |                           |
| FlexLayout     | ❓                      | _Not available_ | [FlexLayout]        | _Missing_ |                           |
| Frame          | ❌                      | N/A             | [Frame]             | _Missing_ | Prefer Border if possible |
| Grid           | ✅                      | [Grid]          | [CompatGrid]        | _Missing_ |                           |
| HStack         | ✅                      | [HStack]        | [CompatHStack]      | _Missing_ |                           |
| ScrollView     | ✅                      | [ScrollView]    | [CompatScrollView]  | _Missing_ |                           |
| SwipeItem      | ❓                      | _Not available_ | [SwipeItem]         | _Missing_ |                           |
| SwipeItems     | ❓                      | _Not available_ | [SwipeItems]        | _Missing_ |                           |
| SwipeView      | ❓                      | _Not available_ | [SwipeView]         | _Missing_ |                           |
| RefreshView    | ❓                      | _Not available_ | [RefreshView]       | _Missing_ |                           |
| VStack         | ✅                      | [VStack]        | [CompatVStack]      | _Missing_ |                           |


[AbsoluteLayout]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/AbsoluteLayout.fs

[Border]: ../../../src/Fabulous.Maui/Core/Views/Layouts/Border.fs
[CompatBorder]: ../../../src/Fabulous.Maui/Core/Views/Layouts/Border.fs

[ContentView]: ../../../src/Fabulous.Maui/Core/Views/Layouts/ContentView.fs
[CompatContentView]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/CompatContentView.fs

[FlexLayout]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/FlexLayout.fs

[Frame]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/Frame.fs

[Grid]: ../../../src/Fabulous.Maui/Core/Views/Layouts/Grid.fs
[CompatGrid]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/CompatGrid.fs

[HStack]: ../../../src/Fabulous.Maui/Core/Views/Layouts/HStack.fs
[CompatHStack]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/CompatHStack.fs

[ScrollView]: ../../../src/Fabulous.Maui/Core/Views/Layouts/ScrollView.fs
[CompatScrollView]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/CompatScrollView.fs

[SwipeItem]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/SwipeItem.fs

[SwipeItems]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/SwipeItems.fs

[SwipeView]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/SwipeView.fs

[RefreshView]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/RefreshView.fs

[VStack]: ../../../src/Fabulous.Maui/Core/Views/Layouts/VStack.fs
[CompatVStack]: ../../../src/Fabulous.Maui/Compatibility/Views/Layouts/CompatVStack.fs