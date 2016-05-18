// default variables are immutable:
let x = 5.5 // strong implicit typing, x is a float

// mutable variables are mutable:
let mutable z = 5
z <- 42 // assign new value to mutable variable z

printfn "%.2f" x
printfn "%i" z
