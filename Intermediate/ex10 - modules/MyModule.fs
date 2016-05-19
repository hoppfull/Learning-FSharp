// A module is basically a static class and can be treated like one
module MyModule

// all members are public unless explicitly defined otherwise:
let private g x = x - 2
let f x = x * 2 |> g

