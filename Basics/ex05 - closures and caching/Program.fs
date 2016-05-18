// the returned function remembers its closure and the value of i:
let genIncrementer i = fun x -> x + i

let inc1 = genIncrementer 1
let inc7 = genIncrementer 7

printfn "%i" (inc1 10) // cmd: 11
printfn "%i" (inc7 23) // cmd: 30

// memoization (caching):

// every time f_bad is called, calc is evaluated:
let f_bad x =
    let calc = 1 + 1 // calc is not cached
    calc * x

// the value of calc is cached so it's only evaluated once:
let f_good =
    let calc = 1 + 1 // calc is cached
    fun x -> calc * x

printfn "%i" (f_bad 101) // cmd: 202
printfn "%i" (f_good 101) // cmd: 202
