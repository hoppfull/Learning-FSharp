﻿namespace BankApp.Kernel

module Models =
    type Credentials = { Username:string; Password:string }

    type Account = { Balance:int }

    type UserAccount = { User:Credentials; Data:Account }
