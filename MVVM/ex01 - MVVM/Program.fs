open System
open System.Windows
open System.Windows.Markup

let ReadXaml filename =
    IO.File.ReadLines filename
        |> String.concat "\n"
        |> XamlReader.Parse
        :?> Window

type Model = { Message: string }

type ViewModel() =
    member this.Model = { Message = "Hello MVVM!" }
    member this.Message = this.Model.Message

let View =
    let w = ReadXaml "View.xaml"
    w.DataContext <- new ViewModel()
    w

[<EntryPoint; STAThread>]
let main args = (new Application()).Run View