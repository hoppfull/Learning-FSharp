
#load "Models.fs"
#load "DataAccessLayer.fs"
#load "AppLogic.fs"
open BankApp.Kernel

DataAccessLayer.userAccounts <- [
    { User={ Username="Tripp"; Password="abc" }; Data={ Balance=0 } }
    { User={ Username="Trapp"; Password="xyz" }; Data={ Balance=13 } }
    { User={ Username="Trull"; Password="uvw" }; Data={ Balance=42 } }
]

for o in DataAccessLayer.userAccounts do
    printfn "Name: %s, pw: %s, b: %i" o.User.Username o.User.Password o.Data.Balance

match DataAccessLayer.ChangeBalance { Username="Trapp"; Password="xyz_" } 5 with
| Some account -> printfn "Success: %i" account.Balance
| None         -> printfn "Failure!"

for o in DataAccessLayer.userAccounts do
    printfn "Name: %s, pw: %s, b: %i" o.User.Username o.User.Password o.Data.Balance

