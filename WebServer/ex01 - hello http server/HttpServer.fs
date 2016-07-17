module HttpServer

open System.Net
open System.IO
open System.Text

type HttpContentType =
    | Plain
    | Javascript
    | JSON
    | HTML

let parseContentType contentType =
    match contentType with
    | Plain -> "text/plain"
    | Javascript -> "text/javascript"
    | JSON -> "application/json"
    | HTML -> "text/html"
    |> sprintf "%s%s" ";charset=utf-8"

let server address (event:string -> HttpListenerResponse -> HttpListenerRequest -> unit) =
    let listener = new HttpListener()
    listener.Prefixes.Add address
    listener.Start()

    while true do
        let context = listener.GetContext()
        async {
            event context.Request.RawUrl context.Response context.Request
        } |> Async.Start

let respond (response:HttpListenerResponse)  =
    let writer = new StreamWriter(response.OutputStream)

    fun (statusCode:HttpStatusCode) (contentType:HttpContentType) ->
        response.StatusCode <- int statusCode
        response.ContentType <- parseContentType contentType

        fun (msg:string) ->
            response.ContentLength64 <- int64 <| Encoding.UTF8.GetByteCount msg
            writer.Write msg
            writer.Close ()