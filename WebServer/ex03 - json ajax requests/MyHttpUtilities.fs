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

open Newtonsoft.Json.Linq
open Newtonsoft.Json.Schema
open Newtonsoft.Json.Schema.Generation

let schemaGenerator = new JSchemaGenerator()

let TryJsonConvert<'t> schema s =
    try let obj = JObject.Parse s
        if obj.IsValid schema then Some (obj.ToObject<'t>()) else None
    with _ -> None

let readStream (stream:Stream) =
    let reader = new StreamReader(stream)
    reader.ReadToEnd()
