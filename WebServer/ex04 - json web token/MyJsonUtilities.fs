module MyJsonUtilities

open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Newtonsoft.Json.Schema
open Newtonsoft.Json.Schema.Generation

open JWT

let schemaGenerator = new JSchemaGenerator()

let tryJsonConvert<'t> schema json =
    try let obj = JObject.Parse json
        if obj.IsValid schema then Some (obj.ToObject<'t>()) else None
    with _ -> None

let jsonStringify record =
    JsonConvert.SerializeObject record

let tryDecodeJWT<'t> schema (key:string) (token:string) =
    try tryJsonConvert<'t> schema <| JsonWebToken.Decode(token, key)
    with _ -> None