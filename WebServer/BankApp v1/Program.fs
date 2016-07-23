open System.Net

open BankApp.Routing
open BankApp.HttpServer
open BankApp.HttpUtilities

let router:RequestRouter = fun url httpMethod inputStream ->
    let handlePost = HandlePost inputStream
    match httpMethod, url with
    | GET, "/"                                      -> GetFile "index.html" HTML
    | GET, FileRequest "js" file                    -> GetFile file JavaScript
    | GET, FileRequest "css" file                   -> GetFile file XSS
    | POST, "/login"                                -> handlePost Login
    | POST, "/register"                             -> handlePost Register
    | POST, TaggedRequest "/deposit" "session" jwt  -> handlePost (Deposition jwt)
    | POST, TaggedRequest "/withdraw" "session" jwt -> handlePost (Withdrawal jwt)
    | GET, TaggedRequest "/account" "session" jwt   -> HandleGet jwt GetAccountData
    | _, _ -> Respond (Failure { code=HttpStatusCode.NotFound; reason="Error: Not found" })

[<EntryPoint>]
let Main args =
    BankApp.DbAccessLayer.CreateDbIfNotExists()
    Listen 8000 router
    0 // integer exit code
