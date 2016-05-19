open System
open System.Threading

let agent name (inbox:MailboxProcessor<string>) =
    let rec loop count = async {
        let! msg = inbox.Receive()

        printfn "msg #%i to %s: %s" count name msg

        return! loop (count + 1)
    }
    loop 1

let smith = MailboxProcessor.Start(agent "smith")
let bond = MailboxProcessor.Start(agent "bond")

smith.Post "Huey"
smith.Post "Dewey"
smith.Post "Louie"
bond.Post "007"

Console.ReadLine() |> ignore
(* These actors are apparently lightweight and can spawn
in the thousands without much issues. No idea if this is
running on several cores. I wonder if I can test that.*)