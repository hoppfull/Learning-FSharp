namespace BankApp.Nucleus

module AppLogic =
    type LoginOptions () = class end
    type RegisterOptions () = class end
    type AccountOptions (userAccount:Models.UserAccount) =
        member this.UserAccount = userAccount

    type States =
        | LoginScreen of LoginOptions
        | RegisterScreen of RegisterOptions
        | AccountScreen of AccountOptions

    type LoginOptions with
        member this.Login user =
            match DataAccessLayer.GetAccount user with
            | Some account -> Some (new AccountOptions { User=user; Data=account })
            | None         -> None
        member this.NavRegister () = new RegisterOptions ()

    type RegisterOptions with
        member this.Register user =
            if DataAccessLayer.CreateAccount user
            then Some( new LoginOptions())
            else None
        member this.Cancel () = new LoginOptions()

    type AccountOptions with
        member private this.changeBalance op amount =
            if amount > 0
            then DataAccessLayer.ChangeBalance this.UserAccount.User (op 0 amount)
            else None
        member this.Deposit amount = this.changeBalance (+) amount
        member this.Withdraw amount = this.changeBalance (-) amount
        member this.Logout () = new LoginOptions()
