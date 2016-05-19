type IPoint =
    abstract member x: int
    abstract member y: int

let f (o:IPoint) =
    o.x + o.y

// define new object that implements IPoint inline:
{ new IPoint with
    member this.x = 7
    member this.y = 5 }
|> f
|> printfn "%i" // cmd: 12

// factory pattern + interface implementation for IPoint:
let newPoint x y =
    { new IPoint with 
        member this.x = x
        member this.y = y }

newPoint 42 18
|> f
|> printfn "%i" // cmd: 60