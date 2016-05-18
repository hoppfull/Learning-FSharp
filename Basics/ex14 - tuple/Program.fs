// a 3-tuple of three ints:
let t0 = 1, 1, 0
// a 3-tuple of two floats and a string:
let t1 = 3.14, 7., "hello"
// a tuple of two chars:
let t2 = 'a', 'b'
// functions fst and snd only work on 2-tuples
printfn "%c" (fst t2) // cmd: a
printfn "%c" (snd t2) // cmd: b

// use "deconstruction" to retrieve elements from tuples!

(* Deconstruction is a technique for extracting data
from a datastructure and is used a lot in F# programs.
Useful for simplifying code and readability.*)

// a 3-tuple:
let t = "hello", 7., 'x'
let s, f, c = t
printfn "%s" s // cmd: hello
printfn "%.2f" f // cmd: 7.00
printfn "%c" c // cmd: x

let myFunc (a, b, c:char) =
    printfn "%s" (a + c.ToString())
    b * 2.

printfn "%.1f" (myFunc t)
// cmd: hellox
// cmd: 14.0