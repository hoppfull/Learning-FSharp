namespace BankApp.Kernel

module DataAccessLayer =
    let NullCheck<'t> (result:'t) =
        if obj.ReferenceEquals(result, null) then None else Some result

    let mutable userAccounts: Models.UserAccount List = []

    let GetAccount user =
        query { for userAccount in userAccounts do
                where (userAccount.User = user)
                select userAccount.Data
                headOrDefault }
        |> NullCheck

    let CreateAccount (user:Models.Credentials) =
        query { for userAccount in userAccounts do
                where (userAccount.User.Username = user.Username)
                select userAccount.Data
                headOrDefault }
        |> NullCheck
        |> function
        | Some _ -> false
        | None   -> userAccounts <- { User=user; Data={ Balance=0 } }::userAccounts
                    true

    let ChangeBalance user amount =
        let mutable isDone = false
        userAccounts <- userAccounts |> List.map (fun u ->
                if u.User = user && not isDone
                then isDone <- true
                     { u with Data={ Balance = u.Data.Balance + amount } }
                else u)
        if isDone then GetAccount user else None
