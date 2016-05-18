(* Discriminated unions are like enums but that can
contain data. Very interesting! *)

type MyUnion0 =
    | State1
    | State2
    | State3

let myState0 = MyUnion0.State2

match myState0 with
| State1 -> "Huey"
| State2 -> "Dewey"
| State3 -> "Louie"
|> printfn "%s" // cmd: Dewey

type MyUnion1 =
    | State1 of int
    | State2 of string
    | State3

// we use deconstruction to retrieve values stored with union case:
MyUnion1.State2 "hello"
|> function
| State1 x -> x
| State2 s -> s.Length
| State3 -> 0
|> printfn "%i" // cmd: 5
