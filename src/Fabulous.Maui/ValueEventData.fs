namespace Fabulous.Maui

[<Struct>]
type ValueEventData<'data, 'eventArgs> =
    { Value: 'data
      Event: 'eventArgs -> obj }

module ValueEventData =
    let create (value: 'data) (event: 'eventArgs -> obj) = { Value = value; Event = event }
