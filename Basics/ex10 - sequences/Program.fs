(* Sequences are like lists except they are lazy. This
means that sequences can represent arbitrarily large
data sets. They are defined with sequence expressions.*)

// sequence expressions:
let lseq0 = seq {0..5}
let lseq1 = seq {for l in 0..9 do yield l * 2}
let lseq2 = seq {for l in 0..3..20 do yield l * 2}

// infinite sequences:
let lseq3 = 
    let rec loop l = seq {yield l; yield! loop (l + 1)} // advanced
    loop 0

let lseq4 = Seq.initInfinite (fun x -> x * 2 + 10) // simple

printfn "%A" lseq0 // cmd: seq [0; 1; 2; 3; ...]
printfn "%A" lseq1 // cmd: seq [0; 2; 4; 6; ...]
printfn "%A" lseq2 // cmd: seq [0; 6; 12; 18; ...]
printfn "%A" lseq3 // cmd: seq [0; 1; 2; 3; ...]
printfn "%A" lseq4 // cmd: seq [10; 12; 14; 16; ...]

// iterate through squence to get 50th item:
printfn "%i" (Seq.item 50 lseq4) // cmd: 110

printfn "%A" (Seq.take 3 lseq4) // cmd: seq [10; 12; 14]
printfn "%A" (Seq.takeWhile (fun x -> x < 18) lseq4) // cmd: seq [10; 12; 14; 16]
