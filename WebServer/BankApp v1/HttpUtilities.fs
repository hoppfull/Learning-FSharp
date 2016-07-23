namespace BankApp
module HttpUtilities =
    open System.Net
    open System.IO
    open System.Text.RegularExpressions

    let private outputFile file = 
        match File.Exists file with
        | true  -> Some (File.ReadAllText file)
        | false -> None

    let GetFile file fileType =
        HttpServer.Respond <|
        match outputFile file with
        | Some txt -> HttpServer.Success { contentType=fileType; content=txt }
        | None     -> HttpServer.Failure { code=HttpStatusCode.NotFound;
                                           reason="File not found" }
    
    let (|POST|GET|PUT|PATCH|DELETE|UNKNOWN|) = function
        | "POST"   -> POST
        | "GET"    -> GET
        | "PUT"    -> PUT
        | "PATCH"  -> PATCH
        | "DELETE" -> DELETE
        | _ -> UNKNOWN

    let (|FileRequest|_|) ending (url:string) =
        let filePattern = sprintf @"\A/[a-z][a-z0-9.-_ ]+.%s\Z" ending
        if Regex.Match(url.ToLower(), filePattern).Success
        then Some (url.Substring 1)
        else None

    let (|TaggedRequest|_|) rawUrl tag (url:string) =
        let tag_ = sprintf "%s=" tag
        let urlPattern = sprintf @"\A%s\?%s[a-zA-Z0-9-_. ]+\Z" rawUrl tag_
        if Regex.Match(url, urlPattern).Success
        then let index = url.LastIndexOf(tag_) + tag_.Length
             Some (url.Remove(0, index))
        else None
