// Maps are collections of key-value pairs like dictionaries

let lmap =
    Map.empty
        .Add("Han Solo", "Chewbacca")
        .Add("Cat", "Dog")
        .Add("Black", "White")

printfn "%s" lmap.["Han Solo"] // cmd: Chewbacca
printfn "%s" lmap.["Cat"] // cmd: Dog
printfn "%s" lmap.["Black"] // cmd: White
