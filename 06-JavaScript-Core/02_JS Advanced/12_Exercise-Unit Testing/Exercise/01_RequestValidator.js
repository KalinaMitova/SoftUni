function validateRequest(httpRequest) {
    let validKeys = ["method", "uri", "version", "message"];
    let invalidKeys = {
        "method": "Method",
        "uri": "URI",
        "version": "Version",
        "message": "Message"
    };

    // check for invalid keys
    let objectKeys = Object.keys(httpRequest);
    validKeys.forEach((key) => {
        if(!objectKeys.includes(key)) {
            throw new Error(`Invalid request header: Invalid ${invalidKeys[key]}`);
        }
    });

    // check for invalid method
    let method = httpRequest.method;
    if(method !== "GET" && method !== "POST" && method !== "DELETE" && method !== "CONNECT") {
        throw new Error(`Invalid request header: Invalid ${invalidKeys["method"]}`);
    }

    // check for invalid uri
    let uri = httpRequest.uri;
    let uriPattern = /^(\*|[A-Z+a-z+0-9.]+)$/;
    if(!uri.match(uriPattern)) {
        throw new Error(`Invalid request header: Invalid ${invalidKeys["uri"]}`);
    }

    // check for invalid version
    let version = httpRequest.version;
    if(version !== "HTTP/0.9" && version !== "HTTP/1.0" && version !== "HTTP/1.1" && version !== "HTTP/2.0") {
        throw new Error(`Invalid request header: Invalid ${invalidKeys["version"]}`);
    }

    // check for invalid message
    let messagePattern =  /^[^<>\\&'"]*$/;
    if(!httpRequest.message.match(messagePattern)) {
        throw new Error(`Invalid request header: Invalid ${invalidKeys["message"]}`);
    }

    return httpRequest;
}