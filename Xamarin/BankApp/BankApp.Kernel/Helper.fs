namespace BankApp.Nucleus

module Helper =
    open System

    let MatchOption (option: 't Option) (onSuccess:Action<'t>) (onFailure:Action) =
        match option with
        | Some value -> onSuccess.Invoke value
        | None       -> onFailure.Invoke ()
