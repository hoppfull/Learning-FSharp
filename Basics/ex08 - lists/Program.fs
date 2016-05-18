// list of ints:
let ls0 = [1; 2; 3; 4]
// list of chars:
let ls1 = ['a'; 'b'; 'c']
// list of strings:
let ls2:string List = ["Huey"; "Dewey"; "Louie"]
// list of floats:
let ls3:float List = [3.14; 99.9; 7.]

// concatenate operator (always concatenates at beginning):
let ls4 = 0 :: ls0 // ls4 = [0; 1; 2; 3; 4]

for l in ls0 do printf "%i " l // cmd: 1 2 3 4
printf "\n"
printfn "%A" ls1 // cmd: ['a'; 'b'; 'c']
printfn "%A" ls2 // cmd: ["Huey"; "Dewey"; "Louie"]
printfn "%A" ls3 // cmd: [3.14; 99.9; 7.]
printfn "%A" ls4 // cmd: [0; 1; 2; 3; 4]

// list comprehension:
printfn "%A" [0..5] // cmd: [0; 1; 2; 3; 4; 5]
printfn "%A" [0..2..9] // cmd: [0; 2; 4; 6; 8]
printfn "%A" [1..2..9] // cmd: [1; 3; 5; 7; 9]
printfn "%A" [for x in 0..5 do yield x + 10] // cmd: [10; 11; 12; 13; 14; 15]
