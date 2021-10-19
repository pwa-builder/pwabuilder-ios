# pwabuilder-ios

This is PWABuilder's iOS platform that generates an iOS app that loads your PWA in a WKWebView.

# Architecture

This is a C# web app that listens for requests to generate a PWA.

When a request comes in, it creates a copy of the iOS PWA template code, modifies the template with the desired PWA values and zips up the result.

The iOS PWA template code is located in [/Microsoft.PWABuilder.IOS.Web/Resources](https://github.com/pwa-builder/pwabuilder-ios/tree/main/Microsoft.PWABuilder.IOS.Web/Resources).

The code is a fork of https://github.com/khmyznikov/pwa-install/, licensed under [The Unlicense](https://unlicense.org/). A big thanks to Gleb for permitting PWABuilder to to use, fork, and improve on his PWA template.

# Running locally

Open the solution in Visual Studio and hit F5 to run. https://localhost:44314 will open with a page allowing you to test the service.

You may also generate a package manually by POSTing to `/packages/create` with the following JSON body:

```json
{
    "name": "Sad Chonks",
    "bundleId": "com.sadchonks",
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
        "categories": [ "entertainment" ],
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
