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
