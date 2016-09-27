namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Browser

type [<AllowNullLiteral>] JQueryAjaxSettings =
    abstract accepts: obj option with get, set
    abstract async: bool option with get, set
    abstract cache: bool option with get, set
    abstract contents: obj option with get, set
    abstract contentType: obj option with get, set
    abstract context: obj option with get, set
    abstract converters: obj option with get, set
    abstract crossDomain: bool option with get, set
    abstract data: obj option with get, set
    abstract dataType: string option with get, set
    abstract ``global``: bool option with get, set
    abstract headers: obj option with get, set
    abstract ifModified: bool option with get, set
    abstract isLocal: bool option with get, set
    abstract jsonp: obj option with get, set
    abstract jsonpCallback: obj option with get, set
    abstract ``method``: string option with get, set
    abstract mimeType: string option with get, set
    abstract password: string option with get, set
    abstract processData: bool option with get, set
    abstract scriptCharset: string option with get, set
    abstract statusCode: obj option with get, set
    abstract timeout: float option with get, set
    abstract traditional: bool option with get, set
    abstract ``type``: string option with get, set
    abstract url: string option with get, set
    abstract username: string option with get, set
    abstract xhr: obj option with get, set
    abstract xhrFields: obj option with get, set
    abstract beforeSend: jqXHR: JQueryXHR * settings: JQueryAjaxSettings -> obj
    abstract complete: jqXHR: JQueryXHR * textStatus: string -> obj
    abstract dataFilter: data: obj * ty: obj -> obj
    abstract error: jqXHR: JQueryXHR * textStatus: string * errorThrown: string -> obj
    abstract success: data: obj * textStatus: string * jqXHR: JQueryXHR -> obj

and [<AllowNullLiteral>] JQueryXHR =
    inherit XMLHttpRequest
    inherit JQueryPromise<obj>
    abstract responseJSON: obj option with get, set
    abstract overrideMimeType: mimeType: string -> obj
    abstract abort: ?statusText: string -> unit
    abstract ``then``: doneCallback: Func<obj, string, JQueryXHR, 'R> * ?failCallback: Func<JQueryXHR, string, obj, unit> -> JQueryPromise<'R>
    abstract error: xhr: JQueryXHR * textStatus: string * errorThrown: string -> unit

and [<AllowNullLiteral>] JQueryCallback =
    abstract add: callbacks: Function -> JQueryCallback
    abstract add: callbacks: ResizeArray<Function> -> JQueryCallback
    abstract disable: unit -> JQueryCallback
    abstract disabled: unit -> bool
    abstract empty: unit -> JQueryCallback
    abstract fire: [<ParamArray>] arguments: obj[] -> JQueryCallback
    abstract fired: unit -> bool
    abstract fireWith: ?context: obj * ?args: ResizeArray<obj> -> JQueryCallback
    abstract has: callback: Function -> bool
    abstract lock: unit -> JQueryCallback
    abstract locked: unit -> bool
    abstract remove: callbacks: Function -> JQueryCallback
    abstract remove: callbacks: ResizeArray<Function> -> JQueryCallback

and [<AllowNullLiteral>] JQueryGenericPromise<'T> =
    abstract ``then``: doneFilter: Func<'T, obj, U2<'U, JQueryPromise<'U>>> * ?failFilter: Func<obj, obj> * ?progressFilter: Func<obj, obj> -> JQueryPromise<'U>
    abstract ``then``: doneFilter: Func<'T, obj, unit> * ?failFilter: Func<obj, obj> * ?progressFilter: Func<obj, obj> -> JQueryPromise<unit>

and [<AllowNullLiteral>] JQueryPromiseCallback<'T> =
    [<Emit("$0($1...)")>] abstract Invoke: ?value: 'T * [<ParamArray>] args: obj[] -> unit

and [<AllowNullLiteral>] JQueryPromiseOperator<'T, 'U> =
    [<Emit("$0($1...)")>] abstract Invoke: callback1: U2<JQueryPromiseCallback<'T>, ResizeArray<JQueryPromiseCallback<'T>>> * [<ParamArray>] callbacksN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryPromise<'U>

and [<AllowNullLiteral>] JQueryPromise<'T> =
    inherit JQueryGenericPromise<'T>
    abstract state: unit -> string
    abstract always: ?alwaysCallback1: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>> * [<ParamArray>] alwaysCallbacksN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryPromise<'T>
    abstract ``done``: ?doneCallback1: U2<JQueryPromiseCallback<'T>, ResizeArray<JQueryPromiseCallback<'T>>> * [<ParamArray>] doneCallbackN: U2<JQueryPromiseCallback<'T>, ResizeArray<JQueryPromiseCallback<'T>>>[] -> JQueryPromise<'T>
    abstract fail: ?failCallback1: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>> * [<ParamArray>] failCallbacksN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryPromise<'T>
    abstract progress: ?progressCallback1: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>> * [<ParamArray>] progressCallbackN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryPromise<'T>
    abstract pipe: ?doneFilter: Func<obj, obj> * ?failFilter: Func<obj, obj> * ?progressFilter: Func<obj, obj> -> JQueryPromise<obj>

and [<AllowNullLiteral>] JQueryDeferred<'T> =
    inherit JQueryGenericPromise<'T>
    abstract state: unit -> string
    abstract always: ?alwaysCallback1: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>> * [<ParamArray>] alwaysCallbacksN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryDeferred<'T>
    abstract ``done``: ?doneCallback1: U2<JQueryPromiseCallback<'T>, ResizeArray<JQueryPromiseCallback<'T>>> * [<ParamArray>] doneCallbackN: U2<JQueryPromiseCallback<'T>, ResizeArray<JQueryPromiseCallback<'T>>>[] -> JQueryDeferred<'T>
    abstract fail: ?failCallback1: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>> * [<ParamArray>] failCallbacksN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryDeferred<'T>
    abstract progress: ?progressCallback1: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>> * [<ParamArray>] progressCallbackN: U2<JQueryPromiseCallback<obj>, ResizeArray<JQueryPromiseCallback<obj>>>[] -> JQueryDeferred<'T>
    abstract notify: ?value: obj * [<ParamArray>] args: obj[] -> JQueryDeferred<'T>
    abstract notifyWith: context: obj * ?value: ResizeArray<obj> -> JQueryDeferred<'T>
    abstract reject: ?value: obj * [<ParamArray>] args: obj[] -> JQueryDeferred<'T>
    abstract rejectWith: context: obj * ?value: ResizeArray<obj> -> JQueryDeferred<'T>
    abstract resolve: ?value: 'T * [<ParamArray>] args: obj[] -> JQueryDeferred<'T>
    abstract resolveWith: context: obj * ?value: ResizeArray<'T> -> JQueryDeferred<'T>
    abstract promise: ?target: obj -> JQueryPromise<'T>
    abstract pipe: ?doneFilter: Func<obj, obj> * ?failFilter: Func<obj, obj> * ?progressFilter: Func<obj, obj> -> JQueryPromise<obj>

and [<AllowNullLiteral>] BaseJQueryEventObject =
    inherit Event
    abstract currentTarget: Element with get, set
    abstract data: obj with get, set
    abstract delegateTarget: Element with get, set
    abstract ``namespace``: string with get, set
    abstract originalEvent: Event with get, set
    abstract relatedTarget: Element with get, set
    abstract result: obj with get, set
    abstract target: Element with get, set
    abstract pageX: float with get, set
    abstract pageY: float with get, set
    abstract which: float with get, set
    abstract metaKey: bool with get, set
    abstract isDefaultPrevented: unit -> bool
    abstract isImmediatePropagationStopped: unit -> bool
    abstract isPropagationStopped: unit -> bool
    abstract preventDefault: unit -> obj
    abstract stopImmediatePropagation: unit -> unit
    abstract stopPropagation: unit -> unit

and [<AllowNullLiteral>] JQueryInputEventObject =
    inherit BaseJQueryEventObject
    abstract altKey: bool with get, set
    abstract ctrlKey: bool with get, set
    abstract metaKey: bool with get, set
    abstract shiftKey: bool with get, set

and [<AllowNullLiteral>] JQueryMouseEventObject =
    inherit JQueryInputEventObject
    abstract button: float with get, set
    abstract clientX: float with get, set
    abstract clientY: float with get, set
    abstract offsetX: float with get, set
    abstract offsetY: float with get, set
    abstract pageX: float with get, set
    abstract pageY: float with get, set
    abstract screenX: float with get, set
    abstract screenY: float with get, set

and [<AllowNullLiteral>] JQueryKeyEventObject =
    inherit JQueryInputEventObject
    abstract char: obj with get, set
    abstract charCode: float with get, set
    abstract key: obj with get, set
    abstract keyCode: float with get, set

and [<AllowNullLiteral>] JQueryEventObject =
    inherit BaseJQueryEventObject
    inherit JQueryInputEventObject
    inherit JQueryMouseEventObject
    inherit JQueryKeyEventObject


and [<AllowNullLiteral>] JQuerySupport =
    abstract ajax: bool option with get, set
    abstract boxModel: bool option with get, set
    abstract changeBubbles: bool option with get, set
    abstract checkClone: bool option with get, set
    abstract checkOn: bool option with get, set
    abstract cors: bool option with get, set
    abstract cssFloat: bool option with get, set
    abstract hrefNormalized: bool option with get, set
    abstract htmlSerialize: bool option with get, set
    abstract leadingWhitespace: bool option with get, set
    abstract noCloneChecked: bool option with get, set
    abstract noCloneEvent: bool option with get, set
    abstract opacity: bool option with get, set
    abstract optDisabled: bool option with get, set
    abstract optSelected: bool option with get, set
    abstract style: bool option with get, set
    abstract submitBubbles: bool option with get, set
    abstract tbody: bool option with get, set
    abstract scriptEval: unit -> bool

and [<AllowNullLiteral>] JQueryParam =
    [<Emit("$0($1...)")>] abstract Invoke: obj: obj -> string
    [<Emit("$0($1...)")>] abstract Invoke: obj: obj * traditional: bool -> string

and [<AllowNullLiteral>] JQueryEventConstructor =
    [<Emit("$0($1...)")>] abstract Invoke: name: string * ?eventProperties: obj -> JQueryEventObject
    [<Emit("new $0($1...)")>] abstract Create: name: string * ?eventProperties: obj -> JQueryEventObject

and [<AllowNullLiteral>] JQueryCoordinates =
    abstract left: float with get, set
    abstract top: float with get, set

and [<AllowNullLiteral>] JQuerySerializeArrayElement =
    abstract name: string with get, set
    abstract value: string with get, set

and [<AllowNullLiteral>] JQueryAnimationOptions =
    abstract duration: obj option with get, set
    abstract easing: string option with get, set
    abstract complete: Function option with get, set
    abstract step: Func<float, obj, obj> option with get, set
    abstract progress: Func<JQueryPromise<obj>, float, float, obj> option with get, set
    abstract start: Func<JQueryPromise<obj>, obj> option with get, set
    abstract ``done``: Func<JQueryPromise<obj>, bool, obj> option with get, set
    abstract fail: Func<JQueryPromise<obj>, bool, obj> option with get, set
    abstract always: Func<JQueryPromise<obj>, bool, obj> option with get, set
    abstract queue: obj option with get, set
    abstract specialEasing: obj option with get, set

and [<AllowNullLiteral>] JQueryEasingFunction =
    [<Emit("$0($1...)")>] abstract Invoke: percent: float -> float

and [<AllowNullLiteral>] JQueryEasingFunctions =
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: name: string -> JQueryEasingFunction with get, set
    abstract linear: JQueryEasingFunction with get, set
    abstract swing: JQueryEasingFunction with get, set

and [<AllowNullLiteral>] JQuery =
    abstract context: Element with get, set
    abstract jquery: string with get, set
    abstract length: float with get, set
    abstract selector: string with get, set
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: index: string -> obj with get, set
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: index: float -> HTMLElement with get, set
    abstract ajaxComplete: handler: Func<JQueryEventObject, XMLHttpRequest, obj, obj> -> JQuery
    abstract ajaxError: handler: Func<JQueryEventObject, JQueryXHR, JQueryAjaxSettings, obj, obj> -> JQuery
    abstract ajaxSend: handler: Func<JQueryEventObject, JQueryXHR, JQueryAjaxSettings, obj> -> JQuery
    abstract ajaxStart: handler: Func<obj> -> JQuery
    abstract ajaxStop: handler: Func<obj> -> JQuery
    abstract ajaxSuccess: handler: Func<JQueryEventObject, XMLHttpRequest, JQueryAjaxSettings, obj> -> JQuery
    abstract load: url: string * ?data: U2<string, obj> * ?complete: Func<string, string, XMLHttpRequest, obj> -> JQuery
    abstract serialize: unit -> string
    abstract serializeArray: unit -> ResizeArray<JQuerySerializeArrayElement>
    abstract addClass: className: string -> JQuery
    abstract addClass: func: Func<float, string, string> -> JQuery
    abstract addBack: ?selector: string -> JQuery
    abstract attr: attributeName: string -> string
    abstract attr: attributeName: string * value: U2<string, float> -> JQuery
    abstract attr: attributeName: string * func: Func<float, string, U2<string, float>> -> JQuery
    abstract attr: attributes: obj -> JQuery
    abstract hasClass: className: string -> bool
    abstract html: unit -> string
    abstract html: htmlString: string -> JQuery
    abstract html: func: Func<float, string, string> -> JQuery
    abstract prop: propertyName: string -> obj
    abstract prop: propertyName: string * value: U3<string, float, bool> -> JQuery
    abstract prop: properties: obj -> JQuery
    abstract prop: propertyName: string * func: Func<float, obj, obj> -> JQuery
    abstract removeAttr: attributeName: string -> JQuery
    abstract removeClass: ?className: string -> JQuery
    abstract removeClass: func: Func<float, string, string> -> JQuery
    abstract removeProp: propertyName: string -> JQuery
    abstract toggleClass: className: string * ?swtch: bool -> JQuery
    abstract toggleClass: ?swtch: bool -> JQuery
    abstract toggleClass: func: Func<float, string, bool, string> * ?swtch: bool -> JQuery
    abstract ``val``: unit -> obj
    abstract ``val``: value: U3<string, ResizeArray<string>, float> -> JQuery
    abstract ``val``: func: Func<float, string, string> -> JQuery
    abstract css: propertyName: string -> string
    abstract css: propertyName: string * value: U2<string, float> -> JQuery
    abstract css: propertyName: string * value: Func<float, string, U2<string, float>> -> JQuery
    abstract css: properties: obj -> JQuery
    abstract height: unit -> float
    abstract height: value: U2<float, string> -> JQuery
    abstract height: func: Func<float, float, U2<float, string>> -> JQuery
    abstract innerHeight: unit -> float
    abstract innerHeight: height: U2<float, string> -> JQuery
    abstract innerWidth: unit -> float
    abstract innerWidth: width: U2<float, string> -> JQuery
    abstract offset: unit -> JQueryCoordinates
    abstract offset: coordinates: JQueryCoordinates -> JQuery
    abstract offset: func: Func<float, JQueryCoordinates, JQueryCoordinates> -> JQuery
    abstract outerHeight: ?includeMargin: bool -> float
    abstract outerHeight: height: U2<float, string> -> JQuery
    abstract outerWidth: ?includeMargin: bool -> float
    abstract outerWidth: width: U2<float, string> -> JQuery
    abstract position: unit -> JQueryCoordinates
    abstract scrollLeft: unit -> float
    abstract scrollLeft: value: float -> JQuery
    abstract scrollTop: unit -> float
    abstract scrollTop: value: float -> JQuery
    abstract width: unit -> float
    abstract width: value: U2<float, string> -> JQuery
    abstract width: func: Func<float, float, U2<float, string>> -> JQuery
    abstract clearQueue: ?queueName: string -> JQuery
    abstract data: key: string * value: obj -> JQuery
    abstract data: key: string -> obj
    abstract data: obj: obj -> JQuery
    abstract data: unit -> obj
    abstract dequeue: ?queueName: string -> JQuery
    abstract removeData: name: string -> JQuery
    abstract removeData: list: ResizeArray<string> -> JQuery
    abstract removeData: unit -> JQuery
    abstract promise: ?``type``: string * ?target: obj -> JQueryPromise<obj>
    abstract animate: properties: obj * ?duration: U2<string, float> * ?complete: Function -> JQuery
    abstract animate: properties: obj * ?duration: U2<string, float> * ?easing: string * ?complete: Function -> JQuery
    abstract animate: properties: obj * options: JQueryAnimationOptions -> JQuery
    abstract delay: duration: float * ?queueName: string -> JQuery
    abstract fadeIn: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract fadeIn: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract fadeIn: options: JQueryAnimationOptions -> JQuery
    abstract fadeOut: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract fadeOut: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract fadeOut: options: JQueryAnimationOptions -> JQuery
    abstract fadeTo: duration: U2<string, float> * opacity: float * ?complete: Function -> JQuery
    abstract fadeTo: duration: U2<string, float> * opacity: float * ?easing: string * ?complete: Function -> JQuery
    abstract fadeToggle: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract fadeToggle: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract fadeToggle: options: JQueryAnimationOptions -> JQuery
    abstract finish: ?queue: string -> JQuery
    abstract hide: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract hide: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract hide: options: JQueryAnimationOptions -> JQuery
    abstract show: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract show: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract show: options: JQueryAnimationOptions -> JQuery
    abstract slideDown: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract slideDown: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract slideDown: options: JQueryAnimationOptions -> JQuery
    abstract slideToggle: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract slideToggle: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract slideToggle: options: JQueryAnimationOptions -> JQuery
    abstract slideUp: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract slideUp: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract slideUp: options: JQueryAnimationOptions -> JQuery
    abstract stop: ?clearQueue: bool * ?jumpToEnd: bool -> JQuery
    abstract stop: ?queue: string * ?clearQueue: bool * ?jumpToEnd: bool -> JQuery
    abstract toggle: ?duration: U2<float, string> * ?complete: Function -> JQuery
    abstract toggle: ?duration: U2<float, string> * ?easing: string * ?complete: Function -> JQuery
    abstract toggle: options: JQueryAnimationOptions -> JQuery
    abstract toggle: showOrHide: bool -> JQuery
    abstract bind: eventType: string * eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract bind: eventType: string * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract bind: eventType: string * eventData: obj * preventBubble: bool -> JQuery
    abstract bind: eventType: string * preventBubble: bool -> JQuery
    abstract bind: events: obj -> JQuery
    abstract blur: unit -> JQuery
    abstract blur: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract blur: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract change: unit -> JQuery
    abstract change: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract change: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract click: unit -> JQuery
    abstract click: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract click: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract contextmenu: unit -> JQuery
    abstract contextmenu: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract contextmenu: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract dblclick: unit -> JQuery
    abstract dblclick: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract dblclick: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract ``delegate``: selector: obj * eventType: string * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract ``delegate``: selector: obj * eventType: string * eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract focus: unit -> JQuery
    abstract focus: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract focus: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract focusin: unit -> JQuery
    abstract focusin: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract focusin: eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract focusout: unit -> JQuery
    abstract focusout: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract focusout: eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract hover: handlerIn: Func<JQueryEventObject, obj> * handlerOut: Func<JQueryEventObject, obj> -> JQuery
    abstract hover: handlerInOut: Func<JQueryEventObject, obj> -> JQuery
    abstract keydown: unit -> JQuery
    abstract keydown: handler: Func<JQueryKeyEventObject, obj> -> JQuery
    abstract keydown: ?eventData: obj * ?handler: Func<JQueryKeyEventObject, obj> -> JQuery
    abstract keypress: unit -> JQuery
    abstract keypress: handler: Func<JQueryKeyEventObject, obj> -> JQuery
    abstract keypress: ?eventData: obj * ?handler: Func<JQueryKeyEventObject, obj> -> JQuery
    abstract keyup: unit -> JQuery
    abstract keyup: handler: Func<JQueryKeyEventObject, obj> -> JQuery
    abstract keyup: ?eventData: obj * ?handler: Func<JQueryKeyEventObject, obj> -> JQuery
    abstract load: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract load: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract mousedown: unit -> JQuery
    abstract mousedown: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mousedown: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseenter: unit -> JQuery
    abstract mouseenter: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseenter: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseleave: unit -> JQuery
    abstract mouseleave: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseleave: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mousemove: unit -> JQuery
    abstract mousemove: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mousemove: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseout: unit -> JQuery
    abstract mouseout: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseout: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseover: unit -> JQuery
    abstract mouseover: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseover: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseup: unit -> JQuery
    abstract mouseup: handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract mouseup: eventData: obj * handler: Func<JQueryMouseEventObject, obj> -> JQuery
    abstract off: unit -> JQuery
    abstract off: events: string * ?selector: string * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract off: events: string * handler: Func<JQueryEventObject, obj, obj> -> JQuery
    abstract off: events: string * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract off: events: obj * ?selector: string -> JQuery
    abstract on: events: string * handler: Func<JQueryEventObject, obj, obj> -> JQuery
    abstract on: events: string * data: obj * handler: Func<JQueryEventObject, obj, obj> -> JQuery
    abstract on: events: string * selector: string * handler: Func<JQueryEventObject, obj, obj> -> JQuery
    abstract on: events: string * selector: string * data: obj * handler: Func<JQueryEventObject, obj, obj> -> JQuery
    abstract on: events: obj * ?selector: string * ?data: obj -> JQuery
    abstract on: events: obj * ?data: obj -> JQuery
    abstract one: events: string * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract one: events: string * data: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract one: events: string * selector: string * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract one: events: string * selector: string * data: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract one: events: obj * ?selector: string * ?data: obj -> JQuery
    abstract one: events: obj * ?data: obj -> JQuery
//    abstract ready: handler: Func<JQueryStatic, obj> -> JQuery
    abstract resize: unit -> JQuery
    abstract resize: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract resize: eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract scroll: unit -> JQuery
    abstract scroll: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract scroll: eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract select: unit -> JQuery
    abstract select: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract select: eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract submit: unit -> JQuery
    abstract submit: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract submit: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract trigger: eventType: string * ?extraParameters: U2<ResizeArray<obj>, obj> -> JQuery
    abstract trigger: ``event``: JQueryEventObject * ?extraParameters: U2<ResizeArray<obj>, obj> -> JQuery
    abstract triggerHandler: eventType: string * [<ParamArray>] extraParameters: obj[] -> obj
    abstract triggerHandler: ``event``: JQueryEventObject * [<ParamArray>] extraParameters: obj[] -> obj
    abstract unbind: ?eventType: string * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract unbind: eventType: string * fls: bool -> JQuery
    abstract unbind: evt: obj -> JQuery
    abstract undelegate: unit -> JQuery
    abstract undelegate: selector: string * eventType: string * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract undelegate: selector: string * events: obj -> JQuery
    abstract undelegate: ``namespace``: string -> JQuery
    abstract unload: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract unload: ?eventData: obj * ?handler: Func<JQueryEventObject, obj> -> JQuery
    abstract error: handler: Func<JQueryEventObject, obj> -> JQuery
    abstract error: eventData: obj * handler: Func<JQueryEventObject, obj> -> JQuery
    abstract pushStack: elements: ResizeArray<obj> -> JQuery
    abstract pushStack: elements: ResizeArray<obj> * name: string * arguments: ResizeArray<obj> -> JQuery
    abstract after: content1: obj * [<ParamArray>] content2: obj[] -> JQuery
    abstract after: func: Func<float, string, U3<string, Element, JQuery>> -> JQuery
    abstract append: content1: obj * [<ParamArray>] content2: obj[] -> JQuery
    abstract append: func: Func<float, string, U3<string, Element, JQuery>> -> JQuery
    abstract appendTo: target: U4<JQuery, ResizeArray<obj>, Element, string> -> JQuery
    abstract before: content1: obj * [<ParamArray>] content2: obj[] -> JQuery
    abstract before: func: Func<float, string, U3<string, Element, JQuery>> -> JQuery
    abstract clone: ?withDataAndEvents: bool * ?deepWithDataAndEvents: bool -> JQuery
    abstract detach: ?selector: string -> JQuery
    abstract empty: unit -> JQuery
    abstract insertAfter: target: obj -> JQuery
    abstract insertBefore: target: obj -> JQuery
    abstract prepend: content1: obj * [<ParamArray>] content2: obj[] -> JQuery
    abstract prepend: func: Func<float, string, U3<string, Element, JQuery>> -> JQuery
    abstract prependTo: target: U4<JQuery, ResizeArray<obj>, Element, string> -> JQuery
    abstract remove: ?selector: string -> JQuery
    abstract replaceAll: target: U4<JQuery, ResizeArray<obj>, Element, string> -> JQuery
    abstract replaceWith: newContent: obj -> JQuery
    abstract replaceWith: func: Func<U2<Element, JQuery>> -> JQuery
    abstract text: unit -> string
    abstract text: text: U3<string, float, bool> -> JQuery
    abstract text: func: Func<float, string, string> -> JQuery
    abstract toArray: unit -> ResizeArray<HTMLElement>
    abstract unwrap: unit -> JQuery
    abstract wrap: wrappingElement: U3<JQuery, Element, string> -> JQuery
    abstract wrap: func: Func<float, U2<string, JQuery>> -> JQuery
    abstract wrapAll: wrappingElement: U3<JQuery, Element, string> -> JQuery
    abstract wrapAll: func: Func<float, string> -> JQuery
    abstract wrapInner: wrappingElement: U3<JQuery, Element, string> -> JQuery
    abstract wrapInner: func: Func<float, string> -> JQuery
    abstract each: func: Func<float, Element, obj> -> JQuery
    abstract get: index: float -> HTMLElement
    abstract get: unit -> ResizeArray<HTMLElement>
    abstract index: unit -> float
    abstract index: selector: U3<string, JQuery, Element> -> float
    abstract add: selector: string * ?context: Element -> JQuery
    abstract add: [<ParamArray>] elements: Element[] -> JQuery
    abstract add: html: string -> JQuery
    abstract add: obj: JQuery -> JQuery
    abstract children: ?selector: string -> JQuery
    abstract closest: selector: string -> JQuery
    abstract closest: selector: string * ?context: Element -> JQuery
    abstract closest: obj: JQuery -> JQuery
    abstract closest: element: Element -> JQuery
    abstract closest: selectors: obj * ?context: Element -> ResizeArray<obj>
    abstract contents: unit -> JQuery
    abstract ``end``: unit -> JQuery
    abstract eq: index: float -> JQuery
    abstract filter: selector: string -> JQuery
    abstract filter: func: Func<float, Element, obj> -> JQuery
    abstract filter: element: Element -> JQuery
    abstract filter: obj: JQuery -> JQuery
    abstract find: selector: string -> JQuery
    abstract find: element: Element -> JQuery
    abstract find: obj: JQuery -> JQuery
    abstract first: unit -> JQuery
    abstract has: selector: string -> JQuery
    abstract has: contained: Element -> JQuery
    abstract is: selector: string -> bool
    abstract is: func: Func<float, Element, bool> -> bool
    abstract is: obj: JQuery -> bool
    abstract is: elements: obj -> bool
    abstract last: unit -> JQuery
    abstract map: callback: Func<float, Element, obj> -> JQuery
    abstract next: ?selector: string -> JQuery
    abstract nextAll: ?selector: string -> JQuery
    abstract nextUntil: ?selector: string * ?filter: string -> JQuery
    abstract nextUntil: ?element: Element * ?filter: string -> JQuery
    abstract nextUntil: ?obj: JQuery * ?filter: string -> JQuery
    abstract not: selector: string -> JQuery
    abstract not: func: Func<float, Element, bool> -> JQuery
    abstract not: elements: U2<Element, ResizeArray<Element>> -> JQuery
    abstract not: obj: JQuery -> JQuery
    abstract offsetParent: unit -> JQuery
    abstract parent: ?selector: string -> JQuery
    abstract parents: ?selector: string -> JQuery
    abstract parentsUntil: ?selector: string * ?filter: string -> JQuery
    abstract parentsUntil: ?element: Element * ?filter: string -> JQuery
    abstract parentsUntil: ?obj: JQuery * ?filter: string -> JQuery
    abstract prev: ?selector: string -> JQuery
    abstract prevAll: ?selector: string -> JQuery
    abstract prevUntil: ?selector: string * ?filter: string -> JQuery
    abstract prevUntil: ?element: Element * ?filter: string -> JQuery
    abstract prevUntil: ?obj: JQuery * ?filter: string -> JQuery
    abstract siblings: ?selector: string -> JQuery
    abstract slice: start: float * ?``end``: float -> JQuery
    abstract queue: ?queueName: string -> ResizeArray<obj>
    abstract queue: newQueue: ResizeArray<Function> -> JQuery
    abstract queue: callback: Function -> JQuery
    abstract queue: queueName: string * newQueue: ResizeArray<Function> -> JQuery
    abstract queue: queueName: string * callback: Function -> JQuery


