open MyModule
(* Cyclic dependencies are not allowed in F#. This is a feature to enforce
clean code architecture. Since this file is dependent on MyModule, MyModule
can't access anything in this file. In order to set correct compilation
order, set file order of appearance in solution explorer.*)

printfn "%i" (f 4) // cmd: 6
