let f x = x * 2

(* the forward pipe operator (FPO) takes the left hand
argument and applies it to the right hand argument:*)
let result = 10 |> f
printfn "%i" result // cmd: 10

"hello" |> printfn "%s" // cmd: hello

// the FPO allows us to make a long expression more readable:
42
|> fun x -> x * 2 // results in 84
|> fun x -> x + 15 // results in 99
|> fun x -> x.ToString() + " red balloons" // results in "99 red balloons"
|> printfn "%s" // cmd: 99 red balloons
