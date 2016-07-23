function Get(url, cb) {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4)
            cb(req)
    }

    req.open('GET', url, true)
    req.setRequestHeader('Content-Type', 'text/plain; charset=utf-8')
    req.send()
    console.log("Sent http request. Waiting for response...")
}

function Post(url, data, cb) {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4)
            cb(req)
    }
    
    req.open('POST', url, true)
    req.setRequestHeader('Content-Type', 'application/json; charset=utf-8')
    req.send(JSON.stringify(data))
    console.log("Sent http request. Waiting for response...")
}
