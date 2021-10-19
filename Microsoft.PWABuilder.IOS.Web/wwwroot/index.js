const codeArea = document.querySelector("textarea");
const submitBtn = document.querySelector("#submitBtn");
const resultsDiv = document.querySelector("#results");
const spinner = document.querySelector(".spinner-border");

submitBtn.addEventListener("click", () => submit());

setCode(getDefaultJson());
codeArea.scrollTop = 0;

function setCode(options) {
    const code = JSON.stringify(options, undefined, 4);
    codeArea.value = code;
    codeArea.scrollTop = 1000000;
}

function getDefaultJson() {
    // This creates an unsigned package. Should be considered the bare minimum.
    return {
        name: "Sad Chonks",
        bundleId: "com.sadchonks",
        url: "https://sadchonks.com",
        imageUrl: "https://sadchonks.com/kitteh-512.png",
        splashColor: "#f5f5f5",
        progressBarColor: "#3f51b5",
        statusBarColor: "#f5f5f5",
        permittedUrls: [],
        manifestUrl: "https://sadchonks.com/manifest.json",
        manifest: getManifest()
    };
}

function getManifest() {
    return {
        "short_name": "Chonks",
        "name": "Sad Chonks",
        "description": "Your daily source for Sad Chonks",
        "categories": ["cats", "memes"],
        "screenshots": [
            {
                "src": "/chonkscreenshot1.jpeg",
                "type": "image/jpeg",
                "sizes": "728x409",
                "label": "App on homescreen with shortcuts",
                "platform": "play"
            },
            {
                "src": "/chonkscreenshot2.jpg",
                "type": "image/jpeg",
                "sizes": "551x541",
                "label": "Really long text describing the screenshot above which is basically a picture showing the app being long pressed on Android and the WebShortcuts popping out",
                "platform": "xbox"
            }
        ],
        "icons": [
            {
                "src": "/favicon.png",
                "type": "image/png",
                "sizes": "128x128"
            },
            {
                "src": "/kitteh-192.png",
                "type": "image/png",
                "sizes": "192x192"
            },
            {
                "src": "/kitteh-512.png",
                "type": "image/png",
                "sizes": "512x512"
            }
        ],
        "start_url": "/saved",
        "background_color": "#3f51b5",
        "display": "standalone",
        "scope": "/",
        "theme_color": "#3f51b5",
        "shortcuts": [
            {
                "name": "New Chonks",
                "short_name": "New",
                "url": "/?shortcut",
                "icons": [{ "src": "/favicon.png", "sizes": "128x128" }]
            },
            {
                "name": "Saved Chonks",
                "short_name": "Saved",
                "url": "/saved?shortcut",
                "icons": [{ "src": "/favicon.png", "sizes": "128x128" }]
            }
        ]
    }
}

async function submit() {
    resultsDiv.textContent = "";

    setLoading(true);
    try {
        // Convert the JSON to an object and back to a string to ensure proper formatting.
        const options = JSON.stringify(JSON.parse(codeArea.value));
        const response = await fetch("/packages/create", {
            method: "POST",
            body: options,
            headers: new Headers({ 'content-type': 'application/json' }),
        });
        if (response.status === 200) {
            const data = await response.blob();
            const url = window.URL.createObjectURL(data);
            window.location.assign(url);

            resultsDiv.textContent = "Success, download started 😎";
        } else {
            const responseText = await response.text();
            resultsDiv.textContent = `Failed. Status code ${response.status}, Error: ${response.statusText}, Details: ${responseText}`;
        }
    } catch (err) {
        resultsDiv.textContent = "Failed. Error: " + err;
    }
    finally {
        setLoading(false);
    }
}

function setLoading(state) {
    submitBtn.disabled = state;
    if (state) {
        spinner.classList.remove("d-none");
    } else {
        spinner.classList.add("d-none");
    }
}