open System
open System.Net
open System.IO

open FSharp.Data

open MyHttpServer
open MyHttpUtilities

type Point = { x:int; y:int }
let PointSchema = schemaGenerator.Generate typeof<Point>

let myrequest:RequestHandler = fun res req ->
    let body = readStream req.InputStream
    match TryJsonConvert<Point> PointSchema body with
    | Some point    -> printfn "x: %i, y: %i" point.x point.y
    | None          -> printfn "boo"
    ()

let route url mthd =
    match mthd, url with
    | GET, "/"              -> getFile "index.html" HTML
    | GET, "/main.js"       -> getFile "main.js" Javascript
    | POST, "/myrequest"    -> myrequest
    | _, _                  -> respond None

[<EntryPoint>]
let Main _ =
    server "http://localhost:8000/" route
    0 // Application termination
