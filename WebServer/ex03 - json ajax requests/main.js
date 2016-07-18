const data1 = { x: 5, y: 7 }
const data2 = { a: 3, b: 8 }
const data3 = 7
const data4 = [1, 2, 3, 4]
const data5 = [1, 2, 3]
const data6 = { x: 5, y: 7, z: 0 }
const data7 = { name: "tjena" }

function SendRequest(data) {
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

    req.open('POST', "myrequest", true)
    req.setRequestHeader('Content-Type', 'application/json;charset=utf-8')
    //req.setRequestHeader('Content-Type', 'text/plain;charset=utf-8')
    req.send(JSON.stringify(data))
    console.log("Sent http request. Waiting for response...")
}
