UI components for fable-react
=======

[![npm version](https://badge.fury.io/js/fable-elmish.svg)](https://badge.fury.io/js/fable-elmish)

## Usage

### Define hubs
```ocaml

    type [<AllowNullLiteral>] MyHub =
        abstract myUpdate: Func<float,unit>

    type Hubs =
        inherit SignalR
        abstract myHub: HubClient<MyHub>
```
Notes:
* Hubs inherits from ```SignalR```
* ```HubClient``` is a binding that wraps members on the given type in a ```client``` variable

### Subscribe to hubs and start connection
```
let connection = Globals.jQuery.connection :> Hubs
connection.myHub.client.myUpdate <- (fun value -> printf "Got updated value: %f" value)
connection.hub.start[ Transport [| "serverSentEvents"; "longPolling" |]] |> ignore
``` 