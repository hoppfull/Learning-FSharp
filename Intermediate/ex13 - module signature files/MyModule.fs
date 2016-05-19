module MyModule
    // since g isn't in the type signature, g is private:
    let g x = x - 2
    let f x = x * 2 |> g