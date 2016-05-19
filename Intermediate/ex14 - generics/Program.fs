// Generics are slow but allow us to simplify code

let f<'a> (x:'a) = x

let inline g x y = x + y

f 42 |> printfn "%i" // cmd: 42
f 7. |> printfn "%.1f" // cmd: 7.0
g 3 5 |> printfn "%i" // cmd: 8
g 7. 6. |> printfn "%.1f" // cmd: 13.0

// I think I should try to limit usage of generics. I'm not sure. We'll see...