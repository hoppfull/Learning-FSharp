(* The option type is a built in discriminated union
used to deal with success or failure of some kind.
It's called the Maybe monad in Haskell. The option
type as two cases, Some of 'a and None.*)

// if client code tries to divide by 0, we get a None, else Some value:
let divide x y =
    match y with
    | y when y = 0 -> None
    | _ -> Some (x / y)

match (divide 10 0) with
| Some x -> "success! result = " + x.ToString()
| None -> "Failure! No result!"
|> printfn "%s" // cmd: Failure! No result!

(* This is useful when dealing with operations that could
fail but we don't want whole program to crash. We instead
want to deal with the error. This provides safety and
robustness to our programs.*)