(*Pattern matching is a kind of switch statement that
has its own set deconstruction syntax. In F# we have
what's called pattern exhaustion which means that the
compiler will warn if a pattern match isn't checking
all possible cases.*)


let f1 x =
    match x with
    | 0 -> "zero" // if x = 0, return "zero"
    | 1 -> "one" // if x = 1, return "one"
    | _ -> "other" // else return "other"

(* the underscore is called the wildcard symbol and is
used when we don't care about a result.*)

// this function doesn't care about the second and third parameters:
let g a _ _ b c = a + b + c

let f2 =
    function
    | 0 -> "zero"
    | 1 -> "one"
    | _ -> "other"

// f1 and f2 are equivalent functions

printfn "%s" (f1 0) // cmd: zero
printfn "%s" (f1 1) // cmd: one
printfn "%s" (f1 2) // cmd: other
printfn "%s" (f2 0) // cmd: zero
printfn "%s" (f2 1) // cmd: one
printfn "%s" (f2 2) // cmd: other

let t = "hello", true

// deconstructing a tuple into its components:
match t with
| (a, b) when b -> a
| (a, b) when a = "goodbye" -> "bye"
| _ -> "whatevs"
|> printfn "%s" // cmd: hello

// deconstructing a list into its head and tail:
match [2..9] with
| h::t when h > 3 -> h
| h::t when t.Length = 7 -> t.Length * 10
| _ -> 0
|> printfn "%i" // cmd: 70