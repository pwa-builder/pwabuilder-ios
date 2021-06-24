# pwabuilder-ios

This is PWABuilder's iOS platform that generates an iOS app that loads your PWA in a WKWebView.

# Running locally

Open the solution in Visual Studio and hit F5 to run. https://localhost:44314 will open with a page allowing you to test the service.

You may also generate a package manually by POSTing to `/packages/create` with the following JSON body:

```json
{
    "name": "Sad Chonks",
    "url": "https://sadchonks.com",
    "imageUrl": "https://sadchonks.com/kitteh-512.png",
    "splashColor": "#f5f5f5",
    "progressBarColor": "#3f51b5",
    "statusBarColor": "#f5f5f5",
    "permittedUrls": [],
    "manifestUrl": "https://sadchonks.com/manifest.json",
    "manifest": {
        "short_name": "Chonks",
        "name": "Sad Chonks",
        "description": "Your daily source for Sad Chonks",
        "categories": [
            "cats",
            "memes"
        ],
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
                "icons": [
                    {
                        "src": "/favicon.png",
                        "sizes": "128x128"
                    }
                ]
            },
            {
                "name": "Saved Chonks",
                "short_name": "Saved",
                "url": "/saved?shortcut",
                "icons": [
                    {
                        "src": "/favicon.png",
                        "sizes": "128x128"
                    }
                ]
            }
        ]
    }
}
```

For more information about the JSON arguments, see [IOSPackageOptions](https://github.com/pwa-builder/pwabuilder-ios/blob/main/Microsoft.PWABuilder.IOS.Web/Models/IOSAppPackageOptions.cs#L101).

The response will be a zip file containing the generated app solution, which can be compiled in Xcode.
