open System.Threading

let fAsync msg = async {
    do! Async.Sleep 4000
    return msg
}

printfn "starting task"
let task = fAsync "task done!" |> Async.StartAsTask

printfn "doing work"
Thread.Sleep 3500
printfn "work done"

printfn "%s" task.Result

(* Tasks start doing work right away
and parent thread continues with its life*)