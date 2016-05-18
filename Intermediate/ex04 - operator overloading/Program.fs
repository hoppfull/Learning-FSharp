type Complex =
    { a: double; bi: double}
    static member (+) (l: Complex, r: Complex) =
        { a = l.a + r.a; bi = l.bi + r.bi }
    static member (-) (l: Complex, r:Complex) =
        { a = l.a - r.a; bi = l.bi - r.bi }
    static member (*) (l: Complex, r:Complex) =
        { a = l.a * r.a - l.bi * r.bi; bi = l.a * r.bi * 2. }

let z0 = { a = 0.; bi = 1. }
let z1 = { a = 2.; bi = 1. }
let z2 = { a = 1.; bi = 0. }

printfn "%A" (z0 + z1) // cmd: { a = 2.0; bi = 2.0 }
printfn "%A" (z0 + z0) // cmd: { a = 0.0; bi = 2.0 }
printfn "%A" (z0 * z0) // cmd: { a = -1.0; bi = 0.0 }
printfn "%A" (z2 * z2) // cmd: { a = 1.0; bi = 0.0 }
printfn "%A" (z1 * z2) // cmd: { a = 2.0; bi = 0.0 }
printfn "%A" (z0 * z2) // cmd: { a = 0.0; bi = 0.0 }
printfn "%A" (z1 * z1) // cmd: { a = 3.0; bi = 4.0 }

// defining new operators:
// available characters: ! % & * + - . / < = > ? @ ^ | ~

open System.Text.RegularExpressions
// infix operator if two arguments:
let (@?) pattern input = Regex.IsMatch(input, pattern)

printfn "%b" ("[0-9]+" @? "hello" ) // cmd: false
printfn "%b" ("[a-z]+" @? "hello" ) // cmd: true
printfn "%b" ("\A[a-z]+\Z" @? "hello " ) // cmd: false
// oh my tits this is so cool!

// prefix if one argument:
let (!) s:string = s + "zorz!!!1!one!!"

printfn "%s" !"hello" // cmd: hellozorz!!!1!one!!
printfn "%s" !"cat" // cmd: catzorz!!!1!one!!
printfn "%s" !"laser" // cmd: laserzorz!!!1!one!!
// christing mcbollock this is awesome!
