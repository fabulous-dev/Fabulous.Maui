namespace Fabulous.Maui

open System.Collections
open Fabulous

type WidgetItems =
    { OriginalItems: IEnumerable
      Template: obj -> Widget }

type GroupedWidgetItems =
    { OriginalItems: IEnumerable
      HeaderTemplate: obj -> Widget
      FooterTemplate: (obj -> Widget) option
      ItemTemplate: obj -> Widget }
