// total active pattern:
let (|Huey|Dewey|Louie|None|) = function
    | "Red"     -> Huey
    | "Blue"    -> Dewey
    | "Green"   -> Louie
    | _         -> None

"Green"
|> function
| Huey  -> "It's Huey!"
| Dewey -> "Hello Dewey!"
| Louie -> "Louie, I greet thee!"
| None  -> "I don't know you..."
|> printfn "%s" // cmd: Louie, I greet thee!

// partial active pattern 1:
let (|Positive|_|) x = if x > 0 then Some x else None
// partial active pattern 2:
let (|Negative|_|) x = if x < 0 then Some x else None

let f = function
    | Positive x -> sprintf "%i is positive!" x
    | Negative x -> sprintf "%i is negative!" x
    | _ -> "0 is neutral!"

printfn "%s" (f 13) // cmd: 13 is positive!
printfn "%s" (f 42) // cmd: 42 is positive!
printfn "%s" (f -7) // cmd: -7 is negative!
printfn "%s" (f 0) // cmd: 0 is neutral!
