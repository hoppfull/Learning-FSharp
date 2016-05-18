// explicit variable type declaration:
let x:int = 5
let y:float = 7.0

// explicit function type declaration:
let f (x:int):string = x.ToString()

type floatAndStringToString = float -> string -> string

let g:floatAndStringToString = fun x s -> x.ToString() + s

printfn "%s" (f x) // cmd: 5
printfn "%s" (g y "hello") // cmd: 7hello
