type MyClass() =
    do printfn "hello"

    new(a) =
        printf "%s" a
        MyClass()

    new(x) =
        printf "%i" x
        MyClass()

let myObj0 = new MyClass() // cmd: hello
let myObj1 = new MyClass(42) // cmd: 42hello
let myObj2 = new MyClass("whatsup") // cmd: whatsuphello
