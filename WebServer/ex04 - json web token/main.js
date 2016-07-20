const data1 = { name: "Louie", pw: "uvw" }
const data2 = { name: "Huey", pw: "xyz" }
const data3 = { email: "Dewey", pw: "xyz" }

let session;

function LoginRequest(data) {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4) {
            switch (req.status) {
                case 200:
                    console.log("Http request successful!")
                    console.log(req.responseText)
                    session = JSON.parse(req.responseText)
                    console.log("token:", session.token)
                    break
                default:
                    console.log(req.responseText)
            }
        }
    }

    req.open('POST', "login", true)
    req.setRequestHeader('Content-Type', 'application/json;charset=utf-8')
    req.send(JSON.stringify(data))
    console.log("Sent http request. Waiting for response...")
}

function BalanceRequest(session) {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4) {
            switch (req.status) {
                case 200:
                    console.log("Http request successful!")
                    console.log(req.responseText)
                    break
                default:
                    console.log(req.responseText)
            }
        }
    }

    req.open('POST', "balance", true)
    req.setRequestHeader('Content-Type', 'application/json;charset=utf-8')
    req.send(JSON.stringify(session))
    console.log("Sent http request. Waiting for response...")
}

function NameRequest(session) {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4) {
            switch (req.status) {
                case 200:
                    console.log("Http request successful!")
                    console.log(req.responseText)
                    break
                default:
                    console.log(req.responseText)
            }
        }
    }

    req.open('POST', "name", true)
    req.setRequestHeader('Content-Type', 'application/json;charset=utf-8')
    req.send(JSON.stringify(session))
    console.log("Sent http request. Waiting for response...")
}