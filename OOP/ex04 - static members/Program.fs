// the singleton pattern with static member:
type MyClass(x) =
    do printf "created new instance! "
    static let mutable instance:MyClass Option = None
    static member Instance
        with get() = match instance with
                     | None   -> instance <- Some <| new MyClass(5)
                                 instance.Value
                     | Some i -> i
    member this.x = x

// a default instance is created:
printfn "%i" <| MyClass.Instance.x // cmd: created new instance! 5
printfn "%i" <| MyClass.Instance.x // cmd: 5
printfn "%i" <| MyClass.Instance.x // cmd: 5
printfn "%i" <| MyClass.Instance.x // cmd: 5

// custom instance is created:
let myObj = new MyClass(7)
printfn "%i" <| myObj.x // cmd: created new instance! 7

// I think this is ideal for mocking. Not sure if I've done it right.
