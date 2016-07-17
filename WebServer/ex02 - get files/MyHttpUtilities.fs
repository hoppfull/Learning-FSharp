module MyHttpUtilities

open System.Net
open System.IO

open MyHttpServer

let outputFile file = 
    match File.Exists file with
    | true  -> Some (File.ReadAllText file)
    | false -> None

let getFile file contentType res (req:HttpListenerRequest) =
    match outputFile file, req.HttpMethod with
    | Some txt, "GET" -> respond res (Some {
        code            = HttpStatusCode.OK
        contentType     = contentType
        content         = txt })
    | _, _            -> respond res None