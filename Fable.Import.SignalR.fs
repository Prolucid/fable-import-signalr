namespace Fable.Import
open System
open Fable.Core
open Fable.Import.JS
open Browser

//[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
[<Import("*","signalr")>]
module SignalRModule =

    type ConnectionState =
        | Connecting = 0
        | Connected = 1
        | Reconnecting = 2
        | Disconnected = 4

    and [<AllowNullLiteral>] AvailableEvents =
        abstract onStart: string with get, set
        abstract onStarting: string with get, set
        abstract onReceived: string with get, set
        abstract onError: string with get, set
        abstract onConnectionSlow: string with get, set
        abstract onReconnect: string with get, set
        abstract onStateChanged: string with get, set
        abstract onDisconnect: string with get, set

    and [<AllowNullLiteral>] Transport =
        abstract name: string with get, set
        abstract supportsKeepAlive: unit -> bool
        abstract send: connection: Connection * data: obj -> unit
        abstract start: connection: Connection * onSuccess: Func<unit> * onFailed: Func<ConnectionError, unit> -> unit
        abstract reconnect: connection: Connection -> unit
        abstract lostConnection: connection: Connection -> unit
        abstract stop: connection: Connection -> unit
        abstract abort: connection: Connection * async: bool -> unit

    and [<AllowNullLiteral>] Transports =
        abstract foreverFrame: Transport with get, set
        abstract longPolling: Transport with get, set
        abstract serverSentEvents: Transport with get, set
        abstract webSockets: Transport with get, set

    and [<AllowNullLiteral>] StateChanged =
        abstract oldState: float with get, set
        abstract newState: float with get, set

    and [<AllowNullLiteral>] ConnectionStates =
        abstract connecting: float with get, set
        abstract connected: float with get, set
        abstract reconnecting: float with get, set
        abstract disconnected: float with get, set

    and [<AllowNullLiteral>] Resources =
        abstract nojQuery: string with get, set
        abstract noTransportOnInit: string with get, set
        abstract errorOnNegotiate: string with get, set
        abstract stoppedWhileLoading: string with get, set
        abstract stoppedWhileNegotiating: string with get, set
        abstract errorParsingNegotiateResponse: string with get, set
        abstract errorDuringStartRequest: string with get, set
        abstract stoppedDuringStartRequest: string with get, set
        abstract errorParsingStartResponse: string with get, set
        abstract invalidStartResponse: string with get, set
        abstract protocolIncompatible: string with get, set
        abstract sendFailed: string with get, set
        abstract parseFailed: string with get, set
        abstract longPollFailed: string with get, set
        abstract eventSourceFailedToConnect: string with get, set
        abstract eventSourceError: string with get, set
        abstract webSocketClosed: string with get, set
        abstract pingServerFailedInvalidResponse: string with get, set
        abstract pingServerFailed: string with get, set
        abstract pingServerFailedStatusCode: string with get, set
        abstract pingServerFailedParse: string with get, set
        abstract noConnectionTransport: string with get, set
        abstract webSocketsInvalidState: string with get, set
        abstract reconnectTimeout: string with get, set
        abstract reconnectWindowTimeout: string with get, set

    and [<AllowNullLiteral>] AjaxDefaults =
        abstract processData: bool with get, set
        abstract timeout: float with get, set
        abstract async: bool with get, set
        abstract ``global``: bool with get, set
        abstract cache: bool with get, set

    and [<KeyValueList>] ConnectionOptions =
        | Transport of string array
        | Callback of obj
        | WaitForPageReload of bool
        | Jsonp of bool
        | PingInterval of float

    and [<AllowNullLiteral>] HubClient<'T> =
        abstract client: 'T with get, set

    and [<AllowNullLiteral>] SimplifyLocation =
        abstract protocol: string with get, set
        abstract host: string with get, set

    and [<AllowNullLiteral>] ConnectionErrorContext =
        abstract readyState: float with get, set
        abstract responseText: string with get, set
        abstract status: float with get, set
        abstract statusText: string with get, set

    and [<AllowNullLiteral>] ConnectionError =
        inherit Error
        abstract context: ConnectionErrorContext with get, set
        abstract transport: string option with get, set
        abstract source: string option with get, set

    and [<AllowNullLiteral>] Connection =
        abstract clientProtocol: string with get, set
        abstract ajaxDataType: string with get, set
        abstract contentType: string with get, set
        abstract id: string with get, set
        abstract json: JSON with get, set
        abstract logging: bool with get, set
        abstract url: string with get, set
        abstract qs: obj with get, set
        abstract state: float with get, set
        abstract reconnectDelay: float with get, set
        abstract transportConnectTimeout: float with get, set
        abstract disconnectTimeout: float with get, set
        abstract reconnectWindow: float with get, set
        abstract keepAliveWarnAt: float with get, set
        abstract hub: Connection with get, set
        abstract lastError: ConnectionError with get, set
        abstract resources: Resources with get, set
        abstract start: unit -> JQueryPromise<obj>
        abstract start: callback: Func<unit> -> JQueryPromise<obj>
        abstract start: options: ConnectionOptions list -> JQueryPromise<obj>
        abstract start: options: ConnectionOptions * callback: Func<unit> -> JQueryPromise<obj>
        abstract starting: callback: Func<unit> -> Connection
        abstract send: data: string -> Connection
        abstract received: callback: Func<obj, unit> -> Connection
        abstract stateChanged: callback: Func<StateChanged, unit> -> Connection
        abstract error: callback: Func<ConnectionError, unit> -> Connection
        abstract disconnected: callback: Func<unit> -> Connection
        abstract connectionSlow: callback: Func<unit> -> Connection
        abstract reconnecting: callback: Func<unit> -> Connection
        abstract reconnected: callback: Func<unit> -> Connection
        abstract stop: ?async: bool * ?notifyServer: bool -> Connection
        abstract log: msg: string -> Connection
        abstract isCrossDomain: url: string * ?against: U2<Location, SimplifyLocation> -> bool


    module Hub =
        type [<AllowNullLiteral>] Proxy =
            abstract state: obj with get, set
            abstract connection: Connection with get, set
            abstract hubName: string with get, set
            abstract init: connection: Connection * hubName: string -> unit
            abstract hasSubscriptions: unit -> bool
            abstract on: eventName: string * callback: Func<obj, unit> -> Proxy
            abstract off: eventName: string * callback: Func<obj, unit> -> Proxy
            abstract invoke: methodName: string * [<ParamArray>] args: obj[] -> JQueryPromise<obj>

        and [<AllowNullLiteral>] Options =
            abstract qs: string option with get, set
            abstract logging: bool option with get, set
            abstract useDefaultPath: bool option with get, set

        and [<AllowNullLiteral>] ClientHubInvocation =
            abstract Hub: string with get, set
            abstract Method: string with get, set
            abstract Args: string with get, set
            abstract State: string with get, set

        and [<AllowNullLiteral>] HubConnection =
            inherit Connection
            abstract proxies: obj with get, set
            abstract transport: obj with get, set
            abstract createHubProxy: hubName: string -> Proxy

        and [<AllowNullLiteral>] HubCreator =
            [<Emit("$0($1...)")>] abstract Invoke: ?url: string * ?options: Options -> Connection

        and [<AllowNullLiteral>] IHub =
            abstract start: unit -> unit                      
                        

type [<AllowNullLiteral>] SignalR =
    abstract ajaxDefaults: SignalRModule.AjaxDefaults with get, set
    abstract connectionState: SignalRModule.ConnectionStates with get, set
    abstract events: SignalRModule.AvailableEvents with get, set
    abstract transports: SignalRModule.Transports with get, set
    abstract hub: SignalRModule.Hub.HubConnection with get, set
    abstract hubConnection: SignalRModule.Hub.HubCreator with get, set
    abstract version: string with get, set
    [<Emit("$0($1...)")>] abstract Invoke: url: string * ?queryString: U2<string, obj> * ?logging: bool -> SignalRModule.Connection
    abstract changeState: connection: SignalRModule.Connection * expectedState: float * newState: float -> unit
    abstract isDisconnecting: connection: SignalRModule.Connection -> bool
    abstract noConflict: unit -> SignalRModule.Connection
    
    
and [<AllowNullLiteral; Import("jQuery","jquery")>] JQueryStatic =
    abstract ajaxSettings: JQueryAjaxSettings with get, set
    abstract param: JQueryParam with get, set
    abstract cssHooks: obj with get, set
    abstract cssNumber: obj with get, set
    abstract easing: JQueryEasingFunctions with get, set
    abstract fx: obj with get, set
    abstract Event: JQueryEventConstructor with get, set
    abstract expr: obj with get, set
    abstract fn: obj with get, set
    abstract isReady: bool with get, set
    abstract support: JQuerySupport with get, set
    abstract ajax: settings: JQueryAjaxSettings -> JQueryXHR
    abstract ajax: url: string * ?settings: JQueryAjaxSettings -> JQueryXHR
    abstract ajaxPrefilter: dataTypes: string * handler: Func<obj, JQueryAjaxSettings, JQueryXHR, obj> -> unit
    abstract ajaxPrefilter: handler: Func<obj, JQueryAjaxSettings, JQueryXHR, obj> -> unit
    abstract ajaxSetup: options: JQueryAjaxSettings -> unit
    abstract get: url: string * ?success: Func<obj, string, JQueryXHR, obj> * ?dataType: string -> JQueryXHR
    abstract get: url: string * ?data: U2<obj, string> * ?success: Func<obj, string, JQueryXHR, obj> * ?dataType: string -> JQueryXHR
    abstract get: settings: JQueryAjaxSettings -> JQueryXHR
    abstract getJSON: url: string * ?success: Func<obj, string, JQueryXHR, obj> -> JQueryXHR
    abstract getJSON: url: string * ?data: U2<obj, string> * ?success: Func<obj, string, JQueryXHR, obj> -> JQueryXHR
    abstract getScript: url: string * ?success: Func<string, string, JQueryXHR, obj> -> JQueryXHR
    abstract post: url: string * ?success: Func<obj, string, JQueryXHR, obj> * ?dataType: string -> JQueryXHR
    abstract post: url: string * ?data: U2<obj, string> * ?success: Func<obj, string, JQueryXHR, obj> * ?dataType: string -> JQueryXHR
    abstract post: settings: JQueryAjaxSettings -> JQueryXHR
    abstract Callbacks: ?flags: string -> JQueryCallback
    abstract holdReady: hold: bool -> unit
    [<Emit("$0($1...)")>] abstract Invoke: selector: string * ?context: U2<Element, JQuery> -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: element: Element -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: elementArray: ResizeArray<Element> -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: callback: Func<JQueryStatic, obj> -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: ``object``: obj -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: ``object``: JQuery -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: unit -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: html: string * ?ownerDocument: Document -> JQuery
    [<Emit("$0($1...)")>] abstract Invoke: html: string * attributes: obj -> JQuery
    abstract noConflict: ?removeAll: bool -> JQueryStatic
    abstract ``when``: [<ParamArray>] deferreds: U2<'T, JQueryPromise<'T>>[] -> JQueryPromise<'T>
    abstract data: element: Element * key: string * value: 'T -> 'T
    abstract data: element: Element * key: string -> obj
    abstract data: element: Element -> obj
    abstract dequeue: element: Element * ?queueName: string -> unit
    abstract hasData: element: Element -> bool
    abstract queue: element: Element * ?queueName: string -> ResizeArray<obj>
    abstract queue: element: Element * queueName: string * newQueue: ResizeArray<Function> -> JQuery
    abstract queue: element: Element * queueName: string * callback: Function -> JQuery
    abstract removeData: element: Element * ?name: string -> JQuery
    abstract Deferred: ?beforeStart: Func<JQueryDeferred<'T>, obj> -> JQueryDeferred<'T>
    abstract proxy: fnction: Func<obj, obj> * context: obj * [<ParamArray>] additionalArguments: obj[] -> obj
    abstract proxy: context: obj * name: string * [<ParamArray>] additionalArguments: obj[] -> obj
    abstract error: message: obj -> JQuery
    abstract contains: container: Element * contained: Element -> bool
    abstract each: collection: ResizeArray<'T> * callback: Func<float, 'T, obj> -> obj
    abstract each: collection: obj * callback: Func<obj, obj, obj> -> obj
    abstract extend: target: obj * ?object1: obj * [<ParamArray>] objectN: obj[] -> obj
    abstract extend: deep: bool * target: obj * ?object1: obj * [<ParamArray>] objectN: obj[] -> obj
    abstract globalEval: code: string -> obj
    abstract grep: array: ResizeArray<'T> * func: Func<'T, float, bool> * ?invert: bool -> ResizeArray<'T>
    abstract inArray: value: 'T * array: ResizeArray<'T> * ?fromIndex: float -> float
    abstract isArray: obj: obj -> bool
    abstract isEmptyObject: obj: obj -> bool
    abstract isFunction: obj: obj -> bool
    abstract isNumeric: value: obj -> bool
    abstract isPlainObject: obj: obj -> bool
    abstract isWindow: obj: obj -> bool
    abstract isXMLDoc: node: Node -> bool
    abstract makeArray: obj: obj -> ResizeArray<obj>
    abstract map: array: ResizeArray<'T> * callback: Func<'T, float, 'U> -> ResizeArray<'U>
    abstract map: arrayOrObject: obj * callback: Func<obj, obj, obj> -> obj
    abstract merge: first: ResizeArray<'T> * second: ResizeArray<'T> -> ResizeArray<'T>
    abstract noop: unit -> obj
    abstract now: unit -> float
    abstract parseJSON: json: string -> obj
    abstract parseXML: data: string -> XMLDocument
    abstract trim: str: string -> string
    abstract ``type``: obj: obj -> string
    abstract unique: array: ResizeArray<Element> -> ResizeArray<Element>
    abstract parseHTML: data: string * ?context: HTMLElement * ?keepScripts: bool -> ResizeArray<obj>
    abstract parseHTML: data: string * ?context: Document * ?keepScripts: bool -> ResizeArray<obj>
    
    abstract signalR: 'T with get, set
    abstract connection: 'T with get, set
    abstract hubConnection: SignalRModule.Hub.HubCreator with get, set

type Globals =
    [<Global; Emit("jQuery")>] static member jQuery with get(): JQueryStatic = failwith "JS only" and set(v: JQueryStatic): unit = failwith "JS only"
    [<Global; Emit("$")>] static member ``$`` with get(): JQueryStatic = failwith "JS only" and set(v: JQueryStatic): unit = failwith "JS only"