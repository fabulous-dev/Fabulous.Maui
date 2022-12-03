namespace DotnetPodcasts.Resources

open Fabulous.Maui

module Images =
    let [<Literal>] discover = "discover.png"
    let [<Literal>] discoverDark = "discover-dark.png"

module ThemeImages =
    let discover () = ThemeAware.Of(Images.discover, Images.discoverDark)
