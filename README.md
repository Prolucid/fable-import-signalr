Fable bindings for [SignalR](http://www.asp.net/signalr)
=======

[![npm version](https://badge.fury.io/js/fable-import-signalr.svg)](https://badge.fury.io/js/fable-import-signalr)

## Usage

### Define hubs
```ocaml

    type [<AllowNullLiteral>] MyHub =
        abstract myUpdate: (float -> unit) with get, set

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

## Add Dependencies
```
<script src="https://code.jquery.com/jquery-1.6.4.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/signalr/jquery.signalr-2.2.1.min.js"></script>
<script src="/signalr/hubs"></script>
```