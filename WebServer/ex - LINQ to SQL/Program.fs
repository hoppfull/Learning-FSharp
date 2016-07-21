open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq

let connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=exdb"
(* look for sqlmetal.exe in C:\Program Files (x86)\Microsoft SDKs\Windows
to automatically generate a dbml file from database *)

type schema = DbmlFile<"exdb.dbml">
let db = new schema.exdb(connectionString)

if db.DatabaseExists() then printfn "Database already exists!" else db.CreateDatabase()

let user1 = new schema.Account(Name="Huey", Password="abc", Balance=3)
let user2 = new schema.Account(Name="Dewey", Password="xyz", Balance=7)
let user3 = new schema.Account(Name="Louie", Password="uvw", Balance=(-2))

printfn "ID before insert: %i" user1.ID

db.Accounts.InsertOnSubmit user1
db.Accounts.InsertOnSubmit user2

db.Accounts.InsertAllOnSubmit [ user2; user3 ]

printfn "ID after insert before submit: %i" user1.ID

db.SubmitChanges()

printfn "ID after submit: %i" user1.ID

let debtees = query {
    for row in db.Accounts do
    where (row.Balance < 0)
    select row.Name
}

printfn "Calling query:"
Seq.iter (printfn "%s") debtees

db.Accounts.InsertOnSubmit <| new schema.Account(Name="John Crichton", Password="Scorpius", Balance=(-5))
db.SubmitChanges()

printfn "Calling same query again after new insert:"
Seq.iter (printfn "%s") debtees

query {
    for row in db.Accounts do
    where (row.Balance < (-3))
    select row
} |> db.Accounts.DeleteAllOnSubmit

db.SubmitChanges()

printfn "Calling same query again after delete:"
Seq.iter (printfn "%s") debtees

let richPeople = query {
    for row in db.Accounts do
    where (row.Balance > 0)
    select row
}

for richPerson in richPeople do
    richPerson.Balance <- 100

db.SubmitChanges()

Seq.iter (fun (richPerson:schema.Account) -> printfn "%i" richPerson.Balance) richPeople
