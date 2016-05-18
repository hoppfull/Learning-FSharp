(* Sets are unordered collections.
Sets may not contain duplicates. *)

// set of ints
let lset0 = Set.empty.Add(1).Add(5).Add(7).Add(7)
let lset1 = Set.ofList [0..5]

printfn "%A" lset0 // cmd: set [1; 5; 7]
printfn "%A" lset1 // cmd: set [0; 1; 2; 3; 4; 5]

printfn "%i" lset0.Count // cmd: 3
printfn "%i" lset1.Count // cmd: 6

// what exists in the first set that doesn't exist in the second set:
printfn "%A" (Set.difference lset0 lset1) // cmd: set [7]
printfn "%A" (Set.difference lset1 lset0) // cmd: set [0; 2; 3; 4]

// what exists in both sets:
printfn "%A" (Set.intersect lset0 lset1) // cmd: set [1; 5]
