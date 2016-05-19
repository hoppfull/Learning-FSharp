(* if not all abstract members are implemented, then class has to be
abstract which is defined with the AbstractClass-decorator: *)
[<AbstractClass>]
type MyClassA() =
    abstract member x: double
    abstract member y: double
    abstract member f: double -> double

    // members can but must not be defined in an abstract class:
    default this.f x = x * 2.

type MyClassB(name) =
    member this.name = name
    abstract member sprintf: string
    // all abstract members must be defined in a non-abstract class:
    default this.sprintf = sprintf "%s" this.name

type MyClassBSub(name) =
    inherit MyClassB(name)
    // abstract members can be overriden with new implementation:
    override this.sprintf = sprintf "Hello, %s!" base.sprintf

type MyClassASub(x, y) =
    inherit MyClassA()

    // all abstract members with no defaults has to be implemented:
    override this.x = x
    override this.y = y
    override this.f z = base.f (x + y + z)
