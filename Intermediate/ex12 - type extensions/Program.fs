(* In F# any type can be extended with member fields and methods
both static and non static.*)

type MyRecordType = { x: int; y: int } with
    member this.sprintf = sprintf "{ x = %i; y = %i }" this.x this.y

{x = 7; y = 42}.sprintf
|> printfn "%s" // cmd: {x = 7; y = 42}

type MyUnion =
    | Huey
    | Dewey
    | Louie
    with
    member this.sprintf =
        match this with
        | Huey  -> "Huey"
        | Dewey -> "Dewey"
        | Louie -> "Louie"
        |> sprintf "%s"

MyUnion.Dewey.sprintf
|> printfn "%s" // cmd: Dewey

type System.Int32 with
    member this.sprintf = sprintf "the integer number: %i" this
    static member IsPositive x = x >= 0

let x = 42
x.sprintf
|> printfn "%s" // cmd: the integer number: 42

System.Int32.IsPositive -7
|> printfn "%b" // cmd: false
