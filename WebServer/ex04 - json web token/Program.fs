open System.Net
open JWT

open MyHttpServer
open MyHttpUtilities
open MyJsonUtilities

let PRIVATE_KEY = "mykey"

type User = { name:string; pw:string }
let UserSchema = schemaGenerator.Generate typeof<User>

type AccountBalance = { balance:int }
type AccountName = { name:string }

type Session = { token:string }
let SessionSchema = schemaGenerator.Generate typeof<Session>

type Account = { user:User; balance:int }
let accounts = [ { user={ name="Huey";  pw="abc" }; balance=0 };
                 { user={ name="Dewey"; pw="xyz" }; balance=5 };
                 { user={ name="Louie"; pw="uvw" }; balance=8 } ]
let tryFindAccount user =
    List.tryFind (fun account -> account.user = user) accounts

let jwtEncode<'t> record = JsonWebToken.Encode(record, PRIVATE_KEY, JwtHashAlgorithm.HS256)

let okRequest = { code=HttpStatusCode.OK;
                  contentType=HttpContentType.JSON;
                  content="" }

let badRequest = { code=HttpStatusCode.BadRequest;
                   contentType=HttpContentType.Plain;
                   content="" }

type handler = string -> ResponseData option

let handle (h:handler):RequestHandler = fun res req ->
    (readStream req.InputStream |> h |> respond) res req

let login data =
    match tryJsonConvert<User> UserSchema data with
    | Some user -> match tryFindAccount user with
                   | Some account -> { okRequest with content=jsonStringify { token=jwtEncode user } }
                   | None         -> { badRequest with content="Invalid login credentials" }
    | None      -> { badRequest with content="Bad request data format" }
    |> Some


let decodeSessionCredentials data =
    match tryJsonConvert<Session> SessionSchema data with
    | Some session -> tryDecodeJWT<User> UserSchema PRIVATE_KEY session.token
    | None -> None

let decodeSessionAccount data =
    match decodeSessionCredentials data with
    | Some user -> tryFindAccount user
    | None      -> None

let okResponseDataWithJson record =
    Some { okRequest with content=jsonStringify record }

let getBalance data =
    match decodeSessionAccount data with
    | Some account -> okResponseDataWithJson { AccountBalance.balance=account.balance }
    | None         -> None

let getName data =
    match decodeSessionAccount data with
    | Some account -> okResponseDataWithJson { AccountName.name=account.user.name }
    | None         -> None

let route url mthd = 
    match mthd, url with
    | GET, "/"          -> getFile "index.html" HTML
    | GET, "/main.js"   -> getFile "main.js" Javascript
    | POST, "/login"    -> handle login
    | POST, "/balance"  -> handle getBalance
    | POST, "/name"     -> handle getName
    | _, _              -> respond None

[<EntryPoint>]
let Main _ =
    server "http://localhost:8000/" route
    0 // Application termination
