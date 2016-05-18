// a 3-tuple of three ints:
let t0 = 1, 1, 0
// a 3-tuple of two floats and a string:
let t1 = 3.14, 7., "hello"
// a tuple of two chars:
let t2 = 'a', 'b'
// functions fst and snd only work on 2-tuples
printfn "%c" (fst t2) // cmd: a
printfn "%c" (snd t2) // cmd: b

// use "deconstruction" (see ex15) to retrieve elements from tuples!