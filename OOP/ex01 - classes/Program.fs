// class declaration:
type MyClass(a, b, c) =
    member this.MyFieldA = a
    member this.MyFieldB = b
    member this.MyFieldC = c
    member this.MyMethod x y z =
        x * a + y * b + z * c

(* "this" is not a keyword but an identifier which can be anything and
refers recursively to its object just like the keyword "this" in C#. *)

(* Type signature of MyClass is:
type MyClass =
    class
        new: a:int * b:int * c:int -> MyClass
        member MyFieldA:int
        member MyFieldB:int
        member MyFieldC:int
        memberg MyMethod: int -> int -> int -> int
    end *)

// object instantiation:
let myObj = new MyClass (1, 2, 3)

myObj.MyMethod 10 20 30
|> printfn "%i" // cmd: 140

(* In this example class the self-identifier is explicitly defined as
"this" so that the do-expression can access members before they're
defined: *)
type MyOtherClass(name) as this =
    let MyFieldA = "Hello" // private member
    do printfn "%s, %s!" this.MyFieldB name
    
    member this.MyFieldB = "yo" // public member
    member this.MyMethod () = printfn "%s!!" MyFieldA

let myOtherObj = new MyOtherClass("Louie") // cmd: yo, Louie!
myOtherObj.MyMethod() // cmd: Hello!!
