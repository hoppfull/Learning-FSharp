type MyClassA(x) =
    member this.x = x

type MyClassB(x, y) =
    inherit MyClassA(x)
    member this.y = y
    member this.sprintf = sprintf "(%i, %i)" x y

let myObj = new MyClassB(7, 42)
printfn "%s" <| myObj.sprintf // cmd: (7, 42)
