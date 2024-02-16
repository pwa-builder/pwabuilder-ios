# PWABuilder iOS Platform
Hey folks! Just wanted give the community an update on iOS support on PWABuilder and support within the communication channels. Due to the fact that iOS has very limited support for PWAs we will be supporting the iOS in a community driven fashion. This means that there will not be devs from the PWABuilder team maintaining and building out iOS functionality on the site or Discord. Responses will be 100% community driven. If you are interested in being an iOS champion DM me, would be happy to chat 🙂

This is PWABuilder's iOS platform that generates an iOS app that loads your PWA in a WKWebView. The platform generates a zip file containing an Xcode project that you can compile on your Mac and publish to the App Store.

# Documentation
If you're looking for more info on how to use PWABuilder to package for iOS, check out the documentation [here.](https://docs.pwabuilder.com/#/builder/app-store)

There is also an [iOS FAQ](https://docs.pwabuilder.com/#/builder/faq?id=ios) available.
# Architecture

This is a C# web app that listens for requests to generate a PWA.

When a request comes in, it creates a copy of the iOS PWA template code, modifies the template with the desired PWA values and zips up the result.

The iOS PWA template code is located in [/Microsoft.PWABuilder.IOS.Web/Resources](https://github.com/pwa-builder/pwabuilder-ios/tree/main/Microsoft.PWABuilder.IOS.Web/Resources).

The code is a fork of https://github.com/khmyznikov/ios-pwa-wrap, licensed under [The Unlicense](https://unlicense.org/). A big thanks to Gleb for permitting PWABuilder to use, fork, and improve on his PWA template.

# Running Locally

You will need [Docker](https://www.docker.com/products/docker-desktop/) and the [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) to run this service locally.

Steps:

1. Run `az acr login -n pwabuilder` to authenticate with our Azure Container Registry.

2. Run `docker-compose up` to start the service.

3. Visit `localhost:5000` to see the iOS packaging testing interface.

Alternately, you can POST to `/packages/create` with the following JSON body:

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

For more information about the JSON arguments, see [IOSPackageOptions](https://github.com/pwa-builder/pwabuilder-ios/blob/main/Microsoft.PWABuilder.IOS.Web/Models/IOSAppPackageOptions.cs).

The response will be a zip file containing the generated app solution, which can be compiled in Xcode.
