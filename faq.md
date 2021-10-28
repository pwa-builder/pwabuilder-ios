# PWABuilder iOS platform Frequently Asked Questions (FAQs)

### How can I tell if my PWA was launched from the iOS app?

At runtime, your PWA will have a `app-platform` cookie. This cookie's value will be set to `iOS App Store`.

### Can I publish to the App Store without a Mac?

No, not currently. You'll need Xcode to build your project, which is only available on Mac.

In the near future, the PWABuilder team may automate the build process for you, in which case you'll be able to submit the package to the App Store without a Mac. If this is important to you, please [let us know](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=enhancement%20%3Asparkles%3A,ios-platform&body=I%20would%20like%20to%20see%20PWABuilder%20iOS%20platform%20produce%20builds%20for%20me%20so%20that%20I%20do%20not%20need%20a%20Mac%20to%20build.&title=ios%20-%20build%20for%20me).

In the meantime, there are 3rd party build services, such as [AppVeyor](https://www.appveyor.com/pricing/) or [GitHub Actions with Xcode Archive](https://github.com/marketplace/actions/xcode-archive), that can build Xcode projects as part of your continuous integration (CI) pipeline. 

Additionally, there are inexpesive services, such as [Macincloud](https://www.macincloud.com/), which let you remote into a Mac with Xcode already installed. You can use those services to build your PWA iOS app package.

### What PWA features can I use on iOS?

Unlike Google Play and Microsoft Store, Apple's App Store doesn't natively support PWAs.

To bridge this gap, your PWA runs in a [WKWebView](https://developer.apple.com/documentation/webkit/wkwebview) hosted inside a native Swift app. Generally, features that work in iOS Safari will work in your PWA.

This includes [service worker support](https://love2dev.com/blog/apple-ships-service-workers/).

Our PWA template currently does not support some PWA features like push notifications and app shortcuts.

We'd be glad to accept PRs to add PWA functionality. Our goal is to make this template as close to a full-featured PWA as possible.

To get a glimpse of general PWA support on iOS, we recommend [Maximiliano Firtman's posts on the subject](https://firt.dev/tags/ios/).

### Can I use Push Notifications?

We currently don't support push notifications. We have partial support in the platform for enabling push notifications via Firebase, but the code is currently commented out, and PWABuilder has no UI for letting you input your push notification details.

If Push Notification support is important to you, [upvote this issue](https://github.com/pwa-builder/pwabuilder-ios/issues/6).

### How do updates work?

Since your PWA is being loaded in a web view, pushing changes to your web app will automatically be reflected in your iOS app. No App Store resubmission required.

If you need to make changes to the iOS app itself -- for example, adding new iOS-specific capabilities, or otherwise modifying your app template -- only then you'll need to submit an update to your App Store listing.

### Can I get my PWA in the *Mac* Store?

Yes. While this template is designed for the iOS App Store, you can additionally publish to the Mac App Store.

In [Apple App Store Connect](https://appstoreconnect.apple.com/apps), choose your app. Then under `Pricing & Availability`, enable `Make this app available for MacOS App Store`:

![image](https://user-images.githubusercontent.com/312936/138754831-17de3a87-5a8a-47c3-8137-331125ced1e0.png)

### Can I debug my PWA app on an iOS device?

You can open Safari Dev Tools while your PWA is running in your iPhone simulator.

1. Open your .xcworkspace file in Xcode.
2. Click ▶ to run your PWA inside the iPhone simulator.
3. Open Safari
4. In the top menu bar, choose `Develop` -> `Simulator [device name]` -> `[Your PWA's URL]`
![image](https://user-images.githubusercontent.com/312936/138755619-c7a0cb7a-c96d-4640-a808-3aae24e9b1ef.png)
5. Safari's dev tools will open, allowing you to debug your PWA, execute arbitrary JS, set breakpoints, etc.

### Can I customize my source code?

Yes, certainly. Open your project in Xcode and make your changes as usual.

### Can I use iOS capability X?

Yes. To use iOS capabilities, such as `Sign In with Apple`, `Apple Wallet`, `HealthKit`, or other iOS-specific capabilities, you should specify those capabilities while creating your Bundle ID.

Then, make changes to the code to make use of that ability.

### Are Push Notifications supported?

Not currently. We have plans to enable that in a future release if enough developers want this. If this issue is important to you, please [let us know](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=enhancement%20%3Asparkles%3A,ios-platform&body=I%20would%20like%20to%20see%20PWABuilder%20iOS%20platform%20support%20push%20notifications.&title=ios%20push%20notifications).

### Need more help?

If you're stuck, the PWABuilder team would be glad to point you in the right direction. [Open an issue](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=ios-platform,question%20%3Agrey_question%3A&body=Type%20your%20question%20here.%20Please%20include%20the%20URL%20to%20your%20PWA.%0A%0A%3E%20If%20my%20answer%20was%20in%20the%20docs%20all%20along%2C%20I%20promise%20to%20give%20%245%20USD%20to%20charity.) and we'll help walk you through it.
