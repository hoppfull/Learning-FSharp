module MyHttpServer

open System.Net
open System.Text

type HttpContentType =
    | Plain
    | Javascript
    | JSON
    | HTML

let (|GET|PUT|POST|DELETE|UNKNOWN|) = function
    | "GET"     -> GET
    | "PUT"     -> PUT
    | "POST"    -> POST
    | "DELETE"  -> DELETE
    | _         -> UNKNOWN

type ResponseData = {
    code:           HttpStatusCode
    contentType:    HttpContentType
    content:        string
}

type RequestHandler = HttpListenerResponse -> HttpListenerRequest -> unit

let parseContentType contentType =
    match contentType with
    | Plain         -> "text/plain"
    | Javascript    -> "text/javascript"
    | JSON          -> "application/json"
    | HTML          -> "text/html"
    |> sprintf "%s;charset=utf-8"

let server address (event:string -> string -> RequestHandler) =
    let listener = new HttpListener()
    listener.Prefixes.Add address
    listener.Start()

    while true do
        let ctx = listener.GetContext()
        let req, res = ctx.Request, ctx.Response
        async { event req.RawUrl req.HttpMethod res req
                res.Close() }
        |> Async.Start

let respond:ResponseData option -> RequestHandler = fun data res req ->
    match data with
    | Some d -> let content = Encoding.UTF8.GetBytes(d.content)
                res.ContentType <- parseContentType d.contentType
                res.OutputStream.Write(content, 0, content.Length)
                res.OutputStream.Close()
    | None -> res.StatusCode <- int HttpStatusCode.NotFound
    res.Close()
