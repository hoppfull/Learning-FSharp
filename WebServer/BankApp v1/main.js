"use strict";
let session = "" // global state manager for session token
let name = "" // global state manager for username

const getEl = id => document.getElementById(id)

const btn_logout = getEl('btn_logout')
const btn_login = getEl('btn_login')
const btn_navRegister = getEl('btn_navRegister')
const btn_register = getEl('btn_register')
const btn_navLogin = getEl('btn_navLogin')
const btn_deposit = getEl('btn_deposit')
const btn_withdraw = getEl('btn_withdraw')

const scr_login = getEl('scr_login')
const scr_register = getEl('scr_register')
const scr_account = getEl('scr_account')

const msg_login = getEl('msg_login')
const msg_register = getEl('msg_register')
const msg_account = getEl('msg_account')

const ibx_loginUsername = getEl('ibx_loginUsername')
const ibx_loginPassword = getEl('ibx_loginPassword')
const ibx_registerUsername = getEl('ibx_registerUsername')
const ibx_registerPassword = getEl('ibx_registerPassword')
const ibx_registerConfirmPassword = getEl('ibx_registerConfirmPassword')
const ibx_depositAmount = getEl('ibx_depositAmount')
const ibx_withdrawAmount = getEl('ibx_withdrawAmount')

const lbl_accountTitleName = getEl('lbl_accountTitleName')
const lbl_balance = getEl('lbl_balance')

const NavigateTo = (function () {
    const screens = document.getElementsByClassName('screens')
    return function (screen) {
        for (let i = 0; i < screens.length; i++)
            screens[i].style.display = 'none'
        screen.style.display = 'initial'
    }
} ())

function Logout() {
    session = ""
    name = ""
    btn_logout.style.display = 'none'
}

function Login(username, jwt) {
    session = jwt
    name = username
    btn_logout.style.display = 'initial'
}

function ResetLoginScreen() {
    msg_login.innerText = ""
    ibx_loginUsername.value = ""
    ibx_loginPassword.value = ""
}

function ResetRegisterScreen() {
    msg_register.innerText = ""
    ibx_registerUsername.value = ""
    ibx_registerPassword.value = ""
    ibx_registerConfirmPassword.value = ""
}

function ResetAccountScreen() {
    msg_account.innerText = ""
    lbl_accountTitleName.innerText = ""
    lbl_balance.innerText = ""
    ibx_depositAmount.value = null
    ibx_withdrawAmount.value = null
}

function NavigateToLogin() {
    NavigateTo(scr_login)
    ResetRegisterScreen()
    ResetAccountScreen()
}

function NavigateToRegister() {
    NavigateTo(scr_register)
    ResetLoginScreen()
}

function NavigateToAccount(jwt) {
    NavigateTo(scr_account)
    ResetLoginScreen()
    ShowAccountData(jwt)
}

function ShowAccountData(jwt) {
    Get('/account?session=' + jwt, req => {
        switch (req.status) {
            case 200:
                ibx_depositAmount.value = null
                ibx_withdrawAmount.value = null
                const account = JSON.parse(req.responseText)
                lbl_accountTitleName.innerText = name
                lbl_balance.innerText = `${account.Balance}:- SEK`
                break
            case 400:
                ResetAccountScreen()
                ErrorMsg(msg_account, `Server: ${req.statusText}`)
                break
            case 403:
                ResetAccountScreen()
                ErrorMsg(msg_account, `Server: ${req.statusText}`)
                break
        }
    })
}

function ErrorMsg(lbl, msg) {
    lbl.style.color = 'orangered'
    lbl.innerText = msg
}

function InfoMsg(lbl, msg) {
    lbl.style.color = 'gray'
    lbl.innerText = msg
}

btn_logout.onclick = e => {
    NavigateToLogin()
    Logout()
}

btn_login.onclick = e => {
    const Username = ibx_loginUsername.value
    const Password = ibx_loginPassword.value
    const { usernameIsValid, passwordIsValid } = validateCredentials(Username, Password)

    msg_login.innerText =
        !usernameIsValid && !passwordIsValid ? "Invalid username and password format" :
            !usernameIsValid ? "Invalid username format" :
                !passwordIsValid ? "Invalid password format" :
                    ""

    if (usernameIsValid && passwordIsValid)
        Post('/login', { Username, Password }, req => {
            switch (req.status) {
                case 200: // success
                    const jwt = req.responseText
                    NavigateToAccount(jwt)
                    Login(Username, jwt)
                    break
                case 401: // user does not exist or wrong password
                    ErrorMsg(msg_login, `Server: ${req.statusText}`)
                    break
                case 403: // server refuses credentials
                    ErrorMsg(msg_login, `Server: ${req.statusText}`)
                    break
            }
        })
}

btn_navRegister.onclick = e => {
    NavigateToRegister()
}

btn_register.onclick = e => {
    const Username = ibx_registerUsername.value
    const Password = ibx_registerPassword.value
    const ConfirmPassword = ibx_registerConfirmPassword.value
    const { usernameIsValid, passwordIsValid } = validateCredentials(Username, Password)
    msg_register.innerText =
        Password !== ConfirmPassword ? "Repeated password could not be confirmed" :
            !usernameIsValid && !passwordIsValid ? "Invalid username and password format" :
                !usernameIsValid ? "Invalid username format" :
                    !passwordIsValid ? "Invalid password format" :
                        ""

    if (usernameIsValid && passwordIsValid && Password === ConfirmPassword)
        Post('/register', { Username, Password }, req => {
            switch (req.status) {
                case 200:
                    ResetRegisterScreen()
                    NavigateToLogin()
                    InfoMsg(msg_login, `Server: ${req.responseText}`)
                    break
                case 409:
                    ErrorMsg(msg_register, `Server: ${req.statusText}`)
                    break
                case 403:
                    ErrorMsg(msg_register, `Server: ${req.statusText}`)
                    break
            }
        })
}

btn_navLogin.onclick = e => {
    NavigateToLogin()
}

btn_deposit.onclick = e => {
    const Amount = ibx_depositAmount.valueAsNumber
    if (Amount > 0)
        Post('/deposit?session=' + session, { Amount }, req => {
            switch (req.status) {
                case 200:
                    ShowAccountData(session)
                    InfoMsg(msg_account, `Server: ${req.responseText}`)
                    break
                case 400:
                    ErrorMsg(msg_account, `Server: ${req.statusText}`)
                    break
                case 403:
                    ErrorMsg(msg_account, `Server: ${req.statusText}`)
                    break
            }
        })
    else ErrorMsg(msg_account, "Deposition amount must be a number bigger than 0")
}

btn_withdraw.onclick = e => {
    const Amount = ibx_withdrawAmount.valueAsNumber
    if (Amount > 0)
        Post('/withdraw?session=' + session, { Amount }, req => {
            switch (req.status) {
                case 200:
                    ShowAccountData(session)
                    InfoMsg(msg_account, `Server: ${req.responseText}`)
                    break
                case 400:
                    ErrorMsg(msg_account, `Server: ${req.statusText}`)
                    break
                case 403:
                    ErrorMsg(msg_account, `Server: ${req.statusText}`)
                    break
            }
        })
    else ErrorMsg(msg_account, "Withdrawal amount must be a number bigger than 0")
}
