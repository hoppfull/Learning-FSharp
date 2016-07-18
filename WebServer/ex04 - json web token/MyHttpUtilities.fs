module MyHttpUtilities

open System.Net
open System.IO

open MyHttpServer

let outputFile file = 
    match File.Exists file with
    | true  -> Some (File.ReadAllText file)
    | false -> None

let getFile file contentType =
    match outputFile file with
    | Some txt      -> respond (Some {
        code            = HttpStatusCode.OK
        contentType     = contentType
        content         = txt })
    | None          -> respond None

let readStream (stream:Stream) =
    let reader = new StreamReader(stream)
    reader.ReadToEnd()
