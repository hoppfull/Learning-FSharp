namespace BankApp
module JsonUtilities =
    open Newtonsoft.Json
    open Newtonsoft.Json.Linq
    open Newtonsoft.Json.Schema
    open Newtonsoft.Json.Schema.Generation
    open JWT

    let private KEY = "mykey"

    let GenerateSchema<'t> = (new JSchemaGenerator()).Generate

    let TryJsonConvert<'t> schema json =
        try let obj = JObject.Parse json
            if obj.IsValid schema then Some (obj.ToObject<'t>()) else None
        with _ -> None

    let JsonStringify record =
        JsonConvert.SerializeObject record

    let JwtEncode record = JsonWebToken.Encode(record, KEY, JwtHashAlgorithm.HS256)

    let TryDecodeJWT<'t> schema token =
        try TryJsonConvert<'t> schema <| JsonWebToken.Decode(token, KEY)
        with _ -> None
