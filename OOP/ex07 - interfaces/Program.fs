(*Note that this type has no constructor (no parentheses) and only
abstract members. This makes it automatically an interface: *)
type MyInterface =
    abstract member x: double
    abstract member y: double
    abstract member f: unit -> string

// explicit implementation of an interface:
type MyClass(x, y) =
    interface MyInterface with
        member this.x = x
        member this.y = y
        member this.f() = sprintf "(%.1f, %.1f)" x y

// we must apparently cast the instance of MyClass to its interface:
let myObj = new MyClass(1., 6.) :> MyInterface
printfn "%s" <| myObj.f() // cmd: (1.0, 6.0)

// in most common use case casting is implicit so no worries:
let F (o:MyInterface) =
    printfn "%s" <| o.f()

F myObj // cmd: (1.0, 6.0)
