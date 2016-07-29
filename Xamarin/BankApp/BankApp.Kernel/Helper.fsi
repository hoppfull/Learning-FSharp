namespace BankApp.Nucleus

module Helper =
    open System

    val MatchOption : 't Option -> Action<'t> -> Action -> unit
