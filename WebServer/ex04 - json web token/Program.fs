open System.Net
open JWT

open MyHttpServer
open MyHttpUtilities
open MyJsonUtilities

let PRIVATE_KEY = "mykey"

type User = { name:string; pw:string }
let UserSchema = schemaGenerator.Generate typeof<User>

type Balance = { name:string; balance:int }

type Session = { token:string }
let SessionSchema = schemaGenerator.Generate typeof<Session>

type Account = { user:User; balance:int }
let accounts = [ { user={ name="Huey";  pw="abc" }; balance=0 };
                 { user={ name="Dewey"; pw="xyz" }; balance=5 };
                 { user={ name="Louie"; pw="uvw" }; balance=8 } ]

let login:RequestHandler = fun res req ->
    let body = readStream req.InputStream
    (match tryJsonConvert<User> UserSchema body with
    | Some user ->
        match List.tryFind (fun a -> a.user = user) accounts with
        | Some account ->
            let token = JsonWebToken.Encode(user, PRIVATE_KEY, JwtHashAlgorithm.HS256)
            let jsonData = jsonStringify { token=token }
            respond (Some { code=HttpStatusCode.OK;
                            contentType=HttpContentType.JSON;
                            content=jsonData })
        | None ->
            respond (Some { code=HttpStatusCode.Unauthorized;
                            contentType=HttpContentType.Plain;
                            content="Invalid login credentials" })
    | None ->
        respond (Some { code=HttpStatusCode.BadRequest;
                        contentType=HttpContentType.Plain;
                        content="Bad request data format" })
    ) res req

let getBalance:RequestHandler = fun res req ->
    let body = readStream req.InputStream
    (match tryJsonConvert<Session> SessionSchema body with
    | Some session -> match tryDecodeJWT<User> UserSchema PRIVATE_KEY session.token with
                      | Some user -> match List.tryFind (fun a -> a.user = user) accounts with
                                     | Some account -> let jsonData = jsonStringify { name=account.user.name; balance=account.balance }
                                                       respond (Some { code=HttpStatusCode.OK;
                                                                       contentType=HttpContentType.JSON
                                                                       content=jsonData })
                                     | None -> respond (Some { code=HttpStatusCode.NotFound;
                                                               contentType=HttpContentType.Plain;
                                                               content="Error: User not found!" })
                      | None -> respond (Some { code=HttpStatusCode.BadRequest;
                                                contentType=HttpContentType.Plain;
                                                content="Bad request data format" })
    | None -> respond (Some { code=HttpStatusCode.BadRequest;
                              contentType=HttpContentType.Plain;
                              content="Bad request data format" })
    ) res req

let route url mthd =
    match mthd, url with
    | GET, "/"          -> getFile "index.html" HTML
    | GET, "/main.js"   -> getFile "main.js" Javascript
    | POST, "/login"    -> login
    | POST, "/balance"  -> getBalance
    | _, _              -> respond None

[<EntryPoint>]
let Main _ =
    server "http://localhost:8000/" route
    0 // Application termination
