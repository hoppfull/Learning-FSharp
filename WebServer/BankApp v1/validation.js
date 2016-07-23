function validateCredentials(username, password) {
    const usernamePattern = /^[a-zA-Z0-9-_.@]{4,}$/
    const passwordPattern = /^[a-zA-Z0-9-_ .]{8,}$/
    const usernameIsValid = username.match(usernamePattern) !== null
    const passwordIsValid = password.match(passwordPattern) !== null
    return { usernameIsValid, passwordIsValid }
}
