open JWT

let key = "scrooge"

type point = { x:int; y:int; s:string }

let token = JsonWebToken.Encode({ x=5; y=9; s="hello" }, key, JwtHashAlgorithm.HS256)

printfn "%s" token

let json = JsonWebToken.Decode(token, key)

printfn "%s" json

printfn "%s" <| try JsonWebToken.Decode("nonsensestring", key) with _ -> "failed"
