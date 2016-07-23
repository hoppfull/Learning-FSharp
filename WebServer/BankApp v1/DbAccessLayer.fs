// https://msdn.microsoft.com/visualfsharpdocs/conceptual/query-expressions-%5bfsharp%5d
namespace BankApp
module DbAccessLayer =
    open System
    open System.Data
    open System.Data.Linq
    open Microsoft.FSharp.Data.TypeProviders
    open Microsoft.FSharp.Linq

    open Models

    let private connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=BankApp"

    type private BankAppSchema = DbmlFile<"BankApp.dbml">
    let private db = new BankAppSchema.BankApp(connectionString)

    let CreateDbIfNotExists() =
        do if db.DatabaseExists() then () else printf "Setting up database... "
                                               db.CreateDatabase()
                                               printfn "Done"
    
    let AccountExists user =
        query { for a in db.Accounts do
                select (a.Username, a.Password)
                contains (user.Username, user.Password) }

    let private nullCheck<'t> (result:'t):'t Option =
        if obj.ReferenceEquals(result, null) then None else Some result

    let private getAccountEntity user =
        query { for a in db.Accounts do
                where (a.Username = user.Username && a.Password = user.Password)
                select a
                headOrDefault } |> nullCheck

    let private toRecord (account:BankAppSchema.Account) = {
        Balance=account.Balance
    }

    let GetAccount user =
        match getAccountEntity user with
        | Some account -> Some <| toRecord account
        | None -> None

    let Deposit amount user =
        match getAccountEntity user with
        | Some account -> account.Balance <- account.Balance + amount
                          db.SubmitChanges()
                          true
        | None         -> false

    let Withdraw amount =
        Deposit (-amount)

    let CreateAccount user =
        if AccountExists user
        then false
        else new BankAppSchema.Account(Username=user.Username,
                                       Password=user.Password,
                                       Balance=0)
             |> db.Accounts.InsertOnSubmit
             db.SubmitChanges()
             true
