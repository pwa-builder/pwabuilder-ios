## PWABuilder iOS platform Frequently Asked Questions (FAQs)

## How can I tell if my PWA was launched from the iOS app?

At runtime, your PWA will have a `app-platform` cookie. This cookie's value will be set to `iOS App Store`.

## What PWA features can I use on iOS?

Unlike Google Play and Microsoft Store, iOS App Store doesn't natively support PWAs.

To bridge this gap, your PWA runs in a [WKWebView](https://developer.apple.com/documentation/webkit/wkwebview). Generally, features that work in iOS Safari will work in your PWA.

This includes [service worker support](https://love2dev.com/blog/apple-ships-service-workers/). Currently, we do not support push notifications, but plan to in the future.

To get a glimpse of PWA support on iOS, we recommend [Maximiliano Firtman's posts on the subject](https://firt.dev/tags/ios/).

## How can I debug my PWA?

You can open Safari Dev Tools while your PWA is running in your iPhone simulator.

1. Open your pwa-shell.xcworkspace file in Xcode.
2. Click ▶ to run your PWA inside the iPhone simulator.
3. Open Safari
4. In the top menu bar, choose `Develop` -> `Simulator [device name]` -> `[Your PWA's URL]`
5. Safari's dev tools will open, allowing you to debug your PWA, execute arbitrary JS, etc.

## Can I customize my source code?

Yes, certainly. Open your project in Xcode and make your changes as usual.

## Can I use iOS capability X?

Yes. To use iOS capabilities, such as `Sign In with Apple`, `Apple Wallet`, `HealthKit`, or other iOS-specific capabilities, you should specify those capabilities while creating your Bundle ID.

Then, make changes to the code to make use of that ability.

## Are Push Notifications supported?

Not currently. We have plans to enable that in a future release if demand is there. If this issue is important to you, please [let us know](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=enhancement%20%3Asparkles%3A,ios-platform&body=I%20would%20like%20to%20see%20PWABuilder%20iOS%20platform%20support%20push%20notifications.&title=ios%20push%20notifications)

## Need more help?

If you're stuck, the PWABuilder team would be glad to point you in the right direction. [Open an issue](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=ios-platform&body=Type%20your%20question%20here.%20Please%20include%20the%20URL%20to%20your%20PWA.%0A%0A%3E%20If%20my%20answer%20was%20in%20the%20docs%20all%20along%2C%20I%20promise%20to%20give%20%245%20USD%20to%20charity.) and we'll help walk you through it.