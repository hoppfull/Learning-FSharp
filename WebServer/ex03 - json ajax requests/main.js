
function SendRequest() {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4) {
            switch (req.status) {
                case 200:
                    console.log("Http request successful!")
                    break
                case 404:
                    break
                default:
                    console.log("Unknown response status")
            }
        }
    }
    
    req.open('GET', "tjosan", true)
    //req.setRequestHeader('Content-Type', 'application/json;charset=utf-8')
    req.setRequestHeader('Content-Type', 'text/plain;charset=utf-8')
    req.send()
    console.log("Sent http request. Waiting for response...")
}