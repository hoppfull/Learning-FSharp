function Get(url) {
    const req = new XMLHttpRequest()
    req.onreadystatechange = () => {
        if (req.readyState === 4)
            console.log("Response recieved:", req.responseText)
    }

    req.open('GET', url, true)
    req.setRequestHeader('Content-Type', 'text/plain; charset=utf-8')
    req.send()
    console.log("Sent http request. Waiting for response...")
}
