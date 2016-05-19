namespace MyNamespace

type MyType = int -> int -> int

type MyUnion =
    | Huey
    | Dewey
    | Louie

type MyRecordType = { x: int; y: int }

module MyModule =
    let f x = x * 2

// namespaces can only contain modules and types