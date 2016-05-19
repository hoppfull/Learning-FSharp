type MyClass() =
    let mutable myPropB = 0
    let mutable myPropC = 0
    // immutable property (only get method):
    member this.MyPropA = 5
    // mutable property (both get and set methods):
    member this.MyPropB
        with get() = myPropB
        and set value = myPropB <- value

    // mutable property (but with private set):
    member this.MyPropC
        with get() = myPropC
        and private set value = myPropC <- value

    // automatic immutable property:
    member val MyPropD = 0
    // automatic mutable property:
    member val MyPropE = 0 with get, set
