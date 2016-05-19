open MyNamespace

let g:MyType = fun x y -> x + y

printfn "%i" (MyModule.f 55) // cmd: 110s

let union = MyUnion.Huey

match union with
| Huey  -> g 5 12
| Dewey -> g 7 6
| Louie -> g 9 0
|> printfn "%i" // cmd: 17

{ x = 7; y = 42 }
|> printfn "%A" // cmd: { x = 7; y = 42 }