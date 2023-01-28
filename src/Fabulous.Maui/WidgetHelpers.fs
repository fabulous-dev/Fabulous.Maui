namespace Fabulous.Maui

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.WidgetCollectionAttributeDefinitions

module WidgetHelpers =
    let inline compileSeq (items: seq<WidgetBuilder<'msg, 'marker>>) =
        items |> Seq.map(fun item -> item.Compile()) |> Seq.toArray

    let inline buildWidgets<'msg, 'marker> (key: WidgetKey) (attrs: WidgetAttribute[]) =
        WidgetBuilder<'msg, 'marker>(key, struct (StackList.empty(), ValueSome attrs, ValueNone))

    let inline buildAttributeCollection<'msg, 'marker, 'item>
        (collectionAttributeDefinition: WidgetCollectionAttributeDefinition)
        (widget: WidgetBuilder<'msg, 'marker>)
        =
        AttributeCollectionBuilder<'msg, 'marker, 'item>(widget, collectionAttributeDefinition)

    let buildItems<'msg, 'marker, 'itemData, 'itemMarker>
        key
        (attrDef: SimpleScalarAttributeDefinition<WidgetItems>)
        (items: seq<'itemData>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        =
        let template (item: obj) =
            let item = unbox<'itemData> item
            (itemTemplate item).Compile()

        let data: WidgetItems =
            { OriginalItems = items
              Template = template }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))

    let buildGroupItems<'msg, 'marker, 'groupData, 'itemData, 'groupMarker, 'itemMarker when 'groupData :> seq<'itemData>>
        key
        (attrDef: SimpleScalarAttributeDefinition<GroupedWidgetItems>)
        (items: seq<'groupData>)
        (groupHeaderTemplate: 'groupData -> WidgetBuilder<'msg, 'groupMarker>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        (groupFooterTemplate: 'groupData -> WidgetBuilder<'msg, 'groupMarker>)
        =
        let data: GroupedWidgetItems =
            { OriginalItems = items
              HeaderTemplate = fun d -> (groupHeaderTemplate(unbox d)).Compile()
              FooterTemplate = Some(fun d -> (groupFooterTemplate(unbox d)).Compile())
              ItemTemplate = fun d -> (itemTemplate(unbox d)).Compile() }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))

    let buildGroupItemsNoFooter<'msg, 'marker, 'groupData, 'itemData, 'groupMarker, 'itemMarker when 'groupData :> seq<'itemData>>
        key
        (attrDef: SimpleScalarAttributeDefinition<GroupedWidgetItems>)
        (items: seq<'groupData>)
        (groupHeaderTemplate: 'groupData -> WidgetBuilder<'msg, 'groupMarker>)
        (itemTemplate: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
        =
        let data: GroupedWidgetItems =
            { OriginalItems = items
              HeaderTemplate = fun d -> (groupHeaderTemplate(unbox d)).Compile()
              FooterTemplate = None
              ItemTemplate = fun d -> (itemTemplate(unbox d)).Compile() }

        WidgetBuilder<'msg, 'marker>(key, attrDef.WithValue(data))
