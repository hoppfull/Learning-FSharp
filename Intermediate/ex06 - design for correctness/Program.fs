//=============================================
// Code designed for correctness:
type Item = int

type StartState  = Nothing
type ActiveState = { Item: Item }
type EndState    = { Item: Item; Message: string }

type App =
    | Start  of StartState
    | Active of ActiveState
    | End    of EndState

type StartState with
    member this.f i = App.Active { Item = i }

type ActiveState with
    member this.f i = App.Active { this with Item = this.Item + i }
    member this.g s = App.End { Item = this.Item; Message = s }

type EndState with
    member this.h() = printfn "%s number: %i" this.Message this.Item

type App with
    static member NewApp = App.Start Nothing
    member this.f =
        match this with
        | Start state  -> state.f
        | Active state -> state.f
        | End _        -> failwith "invalid in StartState!"
    member this.g =
        match this with
        | Start _      -> failwith "invalid in ActiveState!"
        | Active state -> state.g
        | End _        -> failwith "invalid in ActiveState!"
    member this.h =
        match this with
        | Start _   -> failwith "invalid in EndState"
        | Active _  -> failwith "invalid in EndState"
        | End state -> state.h
//=============================================
// Client code:
let appState0 = App.NewApp
//appState0.h() // expected crash
//let appstate1 = appState0.g "tjosan" // expected crash
let appState1 = ((appState0.f 10).f 15).f 2
//appState1.h() // expected crash
let appState2 = appState1.g "we are done!"
//let appState3 = appState2.f 20 // expected crash
//let appState3 = appState2.g "done again!" // expected crash
appState2.h() // cmd: we are done! number: 27
