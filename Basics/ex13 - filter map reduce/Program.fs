// in F# 4.0 arrays, lists and sequences uses the same filter map reduce functions:
printfn "%A" (List.filter (fun l -> l % 2 = 0) [0..5]) // cmd: [0; 2; 4]
printfn "%A" (List.map (fun l -> l * 2) [0..5]) // cmd: [0; 2; 4; 6; 8; 10]
printfn "%A" (List.reduce (fun acc l -> acc + l ) [0..5]) // cmd: 15

printfn "%A" (Array.reduce (fun acc x -> acc + x) [|0..4|]) // cmd: 10
printfn "%A" (Seq.reduce (fun acc l -> acc + l) (seq {0..10})) // cmd: 55
