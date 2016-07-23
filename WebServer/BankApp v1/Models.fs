namespace BankApp
module Models =
    open JsonUtilities

    type Credentials = { Username:string; Password:string }
    let credentialsSchema = GenerateSchema typeof<Credentials>

    type Account = { Balance:int }

    type BalanceUpdate = { Amount:int }
    let balanceupdateSchema = GenerateSchema typeof<BalanceUpdate>
