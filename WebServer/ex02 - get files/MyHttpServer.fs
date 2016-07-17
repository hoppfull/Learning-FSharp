module MyHttpServer

open System.Net
open System.Text

type HttpContentType =
    | Plain
    | Javascript
    | JSON
    | HTML

type ResponseData = {
    code:           HttpStatusCode
    contentType:    HttpContentType
    content:        string
}

let parseContentType contentType =
    match contentType with
    | Plain         -> "text/plain"
    | Javascript    -> "text/javascript"
    | JSON          -> "application/json"
    | HTML          -> "text/html"
    |> sprintf "%s;charset=utf-8"

let server address (event:string -> HttpListenerResponse -> HttpListenerRequest -> unit) =
    let listener = new HttpListener()
    listener.Prefixes.Add address
    listener.Start()

    while true do
        let context = listener.GetContext()
        async { event context.Request.RawUrl context.Response context.Request }
        |> Async.Start

let respond (response:HttpListenerResponse) (data:ResponseData option) =
    match data with
    | Some x -> let content = Encoding.UTF8.GetBytes(x.content)
                response.ContentType <- parseContentType x.contentType
                response.OutputStream.Write(content, 0, content.Length)
                response.OutputStream.Close()
    | None -> response.StatusCode <- int HttpStatusCode.NotFound
    response.Close()