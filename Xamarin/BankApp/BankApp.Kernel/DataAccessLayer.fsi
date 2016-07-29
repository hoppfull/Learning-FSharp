namespace BankApp.Nucleus

module private DataAccessLayer =
    open System.Collections.Generic

    val CreateAccount : Models.Credentials -> bool

    val ChangeBalance : Models.Credentials -> int -> Option<Models.Account>

    val GetAccount : Models.Credentials -> Option<Models.Account>
