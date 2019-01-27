function solve(obj, arr) {
    let browser = {};

    Object.keys(obj)
            .forEach(key => {
                let replaced = key.replace(" ", "");
                let newKey = replaced[0].toLowerCase() + replaced.slice(1);
                browser[newKey] = obj[key];
            });

    arr.forEach((inputLine) => {
        let tokens = inputLine.split(" ");
        let command = tokens.shift();
        let website = tokens.join(" ");

        if (command === "Open") {
            // if(!browser.openTabs.includes(website)) {
                browser.openTabs.push(website);
                browser.browserLogs.push(`Open ${website}`);
            // }
        } else if (command === "Close") {
            if(browser.openTabs.includes(website)) {
                browser.openTabs = browser.openTabs.filter((closedWebsite) => closedWebsite !== website);                                
                browser.recentlyClosed.push(website);
                browser.browserLogs.push(`Close ${website}`);
            }
        }
        else if (command === 'Clear') {
            browser.openTabs = browser.openTabs.filter(е => false);
            browser.recentlyClosed = browser.recentlyClosed.filter(е => false);
            browser.browserLogs = browser.browserLogs.filter(е => false);
        }
    });

    console.log(browser.browserName);
    console.log(`Open Tabs: ${browser.openTabs.join(", ")}`);
    console.log(`Recently Closed: ${browser.recentlyClosed.join(", ")}`);
    console.log(`Browser Logs: ${browser.browserLogs.join(", ")}`);
}

solve({"Browser Name":"Google Chrome",
          "Open Tabs":["Facebook","YouTube","Google Translate"],
    "Recently Closed":["Yahoo","Gmail"],
       "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
    ['Close Facebook', 'Open StackOverFlow', 'Open Google']);