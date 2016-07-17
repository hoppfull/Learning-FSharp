open System
open System.Net
open System.IO

open MyHttpServer
open MyHttpUtilities

let route url =
    match url with
    | "/"               -> getFile "index.html" HTML
    | "/main.js"        -> getFile "main.js" Javascript
    | _ -> fun res _    -> respond res None

[<EntryPoint>]
let Main _ =
    server "http://localhost:8000/" route
    0 // Application termination
