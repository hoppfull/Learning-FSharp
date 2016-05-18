// function declaration:
let f x = x * 2
// anonymous function:
let g = fun x -> x - 1

// function invocation:
let result1 = f 10

printfn "%i" result1 // cmd: 20
printfn "%i" (g 10) // cmd: 9

// higher order function:
let F f = f 10

printfn "%i" (F (fun x -> x * x)) // cmd: 100
printfn "%i" (F (fun x -> x / 2)) // cmd: 5

// multiple arguments:
let h a b c = a + b * c

printfn "%i" (h 10 20 30) // cmd: 610

// function composition:
let fg = f >> g
let gf = f << g

printfn "%i" (fg 20) // cmd: 39
printfn "%i" (gf 10) // cmd: 18

// partial application:
let hc = h 100 2
printfn "%i" (hc 3) // cmd: 106
