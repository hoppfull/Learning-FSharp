let fAsync x = async {
    // let! do! and return! will block thread until done
    do! Async.Sleep 5000
    // heavy calculation:
    return x * 2
}

// these are not even evaluated yet:
let resultAsync =
    [1..10]
    |> List.map fAsync
    |> Async.Parallel

// threads start and finish here:
for result in Async.RunSynchronously resultAsync do
    printfn "%i" result
