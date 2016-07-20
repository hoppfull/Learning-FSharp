module MyHttpServer

open System.Net
open System.IO
open System.Text

type HttpContentType =
    | Plain
    | JavaScript
    | JSON
    | HTML

type RequestHandler = HttpListenerResponse -> unit
type RequestRouter = string -> string -> Stream -> RequestHandler

let startServer port (router:RequestRouter) =
    let listener = new HttpListener()
    sprintf "http://localhost:%i/" port
    |> listener.Prefixes.Add
    listener.Start()

    while true do
        let ctx = listener.GetContext()
        let req, res = ctx.Request, ctx.Response
        async { router req.RawUrl req.HttpMethod req.InputStream res
                res.Close() }
        |> Async.Start

type SuccessData = { contentType: HttpContentType; content: string }
type FailureData = { code: HttpStatusCode; reason: string }

type ResponseOption =
    | Success of SuccessData
    | Failure of FailureData

let respond:ResponseOption -> HttpListenerResponse -> unit = fun config res ->
    match config with
    | Success data -> let content = Encoding.UTF8.GetBytes(data.content)
                      res.StatusCode <- int HttpStatusCode.OK
                      res.ContentType <- match data.contentType with
                                         | JavaScript -> "text/javascript"
                                         | Plain      -> "text/plain"
                                         | JSON       -> "application/json"
                                         | HTML       -> "text/html"
                                         |> sprintf "%s;charset=utf-8"
                      res.OutputStream.Write(content, 0, content.Length)
                      res.OutputStream.Close()
    | Failure data -> res.StatusCode <- int data.code
                      res.StatusDescription <- data.reason
