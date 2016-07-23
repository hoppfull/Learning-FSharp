namespace BankApp
module Routing =
    open System.Net
    open System.Text.RegularExpressions

    open DbAccessLayer
    open JsonUtilities
    open HttpServer

    open Models

    let private TryParseJsonLogin =
        TryJsonConvert<Credentials> credentialsSchema

    let private badRequestFormat = { code=HttpStatusCode.BadRequest;
                                     reason="Bad request data format" }
    
    let private jwtResponse (user:Credentials) =
        { okResponse with content=JwtEncode user }

    let private validateCredentials user =
        Regex.Match(user.Username, @"\A[a-zA-Z0-9-_.@]{4,}\Z").Success &&
        Regex.Match(user.Password, @"\A[a-zA-Z0-9-_ .]{8,}\Z").Success

    let Login:Handler = fun body ->
        match TryParseJsonLogin body with
        | Some user -> if validateCredentials user
                       then if AccountExists user
                            then Success <| jwtResponse user
                            else Failure { code=HttpStatusCode.Unauthorized
                                           reason="User does not exist or wrong password" }
                        else Failure { code=HttpStatusCode.Forbidden
                                       reason="Credentials do not meet expectation" }
        | None      -> Failure badRequestFormat

    let Register:Handler = fun body ->
        match TryParseJsonLogin body with
        | Some user -> if validateCredentials user
                       then if CreateAccount user
                            then Success { okResponse with content="Account created successfully" }
                            else Failure { code=HttpStatusCode.Conflict
                                           reason="User already exists" }
                       else Failure { code=HttpStatusCode.Forbidden
                                      reason="Credentials do not meet expectations" }
        | None      -> Failure badRequestFormat

    let GetAccountData:Handler = fun jwt ->
        match TryDecodeJWT<Credentials> credentialsSchema jwt with
        | Some user -> match GetAccount user with
                       | Some account -> Success { contentType=ContentType.JSON
                                                   content=JsonStringify account }
                       | None -> Failure { code=HttpStatusCode.Forbidden
                                           reason="Account does not exist" }
        | None      -> Failure badRequestFormat

    let Deposition jwt:Handler = fun body ->
        match TryDecodeJWT<Credentials> credentialsSchema jwt with
        | Some user -> match TryJsonConvert<BalanceUpdate> balanceupdateSchema body with
                       | Some balanceUpdate -> if Deposit balanceUpdate.Amount user
                                               then Success { okResponse with content="Deposition successful" }
                                               else Failure { code=HttpStatusCode.Forbidden
                                                              reason="Could not perform balance update" }
                       | None               -> Failure badRequestFormat
        | None      -> Failure badRequestFormat

    let Withdrawal jwt:Handler = fun body ->
        match TryDecodeJWT<Credentials> credentialsSchema jwt with
        | Some user -> match TryJsonConvert<BalanceUpdate> balanceupdateSchema body with
                       | Some balanceUpdate -> if Withdraw balanceUpdate.Amount user
                                               then Success { okResponse with content="Withdrawal successful" }
                                               else Failure { code=HttpStatusCode.Forbidden
                                                              reason="Could not perform balance update" }
                       | None               -> Failure badRequestFormat
        | None      -> Failure badRequestFormat