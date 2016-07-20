open System.Net

open MyHttpServer
open MyHttpUtilities

let okResponse = { contentType=HttpContentType.Plain; content="" }

let router:RequestRouter = fun url httpMethod inputStream ->
    match httpMethod, url with
    | GET, "/"                           -> getFile "index.html" HTML
    | GET, FileRequest "js" file         -> getFile file JavaScript
    | GET, TaggedRequest "session" token -> respond (Success { okResponse with content=token })
    | GET, TaggedRequest "data" data     -> respond (Success { okResponse with content=data })
    | _, _ -> respond (Failure { code=HttpStatusCode.NotFound; reason="Error: Not found" })

[<EntryPoint>]
let main argv = 
    let port = 8000
    printfn "Listening on port %i" port
    startServer port router
    0 // exit code
