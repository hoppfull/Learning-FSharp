namespace BankApp.Kernel

module AppLogic =
    type LoginOptions =
        new : unit -> LoginOptions

    type RegisterOptions =
        new : unit -> RegisterOptions

    type AccountOptions =
        new : Models.UserAccount -> AccountOptions

    type States =
        | LoginScreen of LoginOptions
        | RegisterScreen of RegisterOptions
        | AccountScreen of AccountOptions

    type LoginOptions with
        member Login : Models.Credentials -> Option<AccountOptions>
        member NavRegister : unit -> RegisterOptions

    type RegisterOptions with
        member Register : Models.Credentials -> Option<LoginOptions>
        member Cancel : unit -> LoginOptions

    type AccountOptions with
        member UserAccount : Models.UserAccount
        member Deposit : int -> Option<Models.Account>
        member Withdraw : int -> Option<Models.Account>
        member Logout : unit -> LoginOptions
