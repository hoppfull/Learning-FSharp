open System
open System.Net

open HttpServer

let routeIndex res req =
    respond res HttpStatusCode.OK HTML "<h1>Tjenare</h1>"
    res.Close()

let routeDefault res req =
    respond res HttpStatusCode.NotFound Plain ""
    res.Close()

let route url =
    match url with
    | "/" -> routeIndex
    | _ -> routeDefault

[<EntryPoint>]
let Main argv =
    printfn "Starting server..."
    server "http://localhost:8000/" route
    printfn "Server terminated"
    0 // Application termination response
