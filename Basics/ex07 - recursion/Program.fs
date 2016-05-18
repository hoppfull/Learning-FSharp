// CLR doesn't have tail call optimization (TCO)
// We declare a function as recursive to force TCO:
let rec f x sum =
    if x > 0 then f (x - 1) (sum + x)
    else sum

f 10 0 |> printfn "%i" // cmd: 55

// A pattern for hard coding initial values:
let g =
    let rec h x sum =
        if x > 0 then f (x - 1) (sum + x)
        else sum
    fun x -> h x 0

g 10 |> printfn "%i" // cmd: 55
