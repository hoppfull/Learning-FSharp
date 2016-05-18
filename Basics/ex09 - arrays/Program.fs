// array of ints:
let xs0 = [|1; 2; 3; 4|]
// array of chars:
let xs1 = [|'a'; 'b'; 'c'|]
// array of strings:
let xs2:string array = [|"Huey"; "Dewey"; "Louie"|]
// array of floats:
let xs3:float array = [|3.14; 99.9; 7.|]
// array of zeroes:
let xs4:int array = Array.zeroCreate 5
// array of sevens fives:
let xs5 = Array.create 7 5

// access element (zero-indexed):
printfn "%i" xs0.[1] // cmd: 2
// access array size:
printfn "%i" xs1.Length // cmd: 3

printfn "%A" xs0 // cmd: [|1; 2; 3; 4|]
printfn "%A" xs1 // cmd: [|'a'; 'b'; 'c'|]
printfn "%A" xs2 // cmd: [|"Huey"; "Dewey"; "Louie"|]
printfn "%A" xs3 // cmd: [|3.14; 99.9; 7.|]
printfn "%A" xs4 // cmd: [|0; 0; 0; 0; 0|]
printfn "%A" xs5 // cmd: [|5; 5; 5; 5; 5; 5; 5|]

// array comprehension:
printfn "%A" [|0..5|] // cmd: [|0; 1; 2; 3; 5|]
printfn "%A" [|0..2..9|] // cmd: [|0; 2; 4; 6; 8|]
printfn "%A" [|1..2..9|] // cmd: [|1; 3; 5; 7; 9|]
printfn "%A" [|for x in 0..5 do yield x + 10|] // cmd: [|10; 11; 12; 13; 14; 15|]