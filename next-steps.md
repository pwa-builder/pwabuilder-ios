# Next steps for getting your PWA into the Apple iOS Store
You've successfully generated an iOS App Store app package for your PWA. 😎

Your next steps:
1. **Build your project** in Xcode
2. **Test your app**: Run your project in Xcode to try out your PWA on an iPhone emulator.
3. **Submit your app to Apple iOS App Store**

Each step is explained below.

## 1. Build your project in Xcode

Your zip file contains a `src` folder containing the source code for your iOS app. You'll need a Mac to build this project.

Unzip the `src` folder and open a terminal in `src` and execute the following command:

`pod install`

> 💁‍♂️ *Heads up*: 
> 
> If you get an error running `pod install`, you'll need to first run this command: `sudo gem install cocoapods`. Once completed, you can run `pod install`.

Then, open `src/pwa-shell.xcworkspace`

This will open the project in Xcode. In Xcode, click the `Product` > `Build` to build your project.

## 2. Test your app an iPhone simulator

With the project opened in Xcode, click ▶️ to run your PWA in an iPhone simulator. 

## 3. Upload your app to the iOS App Store

Your app is ready to be uploaded to the iOS App Store.

Follow [Apple's instructions](https://developer.apple.com/ios/submit/) for submitting your app to the Store.

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

## Disclaimer: Preview

PWABuilder's iOS platform is in preview stage. While the PWABuilder team has tested this platform, including building and publishing real PWAs with it, there may be bugs or unexplored edge cases or missing features. 

If you encount bugs or missing features, you can submit a PR to the [iOS template code here](https://github.com/pwa-builder/pwabuilder-ios/tree/main/Microsoft.PWABuilder.IOS.Web/Resources). Additional, you can [open an issue](https://github.com/pwa-builder/pwabuilder/issues) to let us know about it.

## Disclaimer: Apple's ambiguous support for PWAs

Caveat emptor: Apple may or may not accept your PWA in their app store.

In 2019, Apple released new [guidelines for HTML5 apps in the App Store](https://developer.apple.com/news/?id=09062019b). The new guidelines appear to state that PWAs may not be accepted into the App Store.

The PWABuilder team has attempted to clarify with Apple their stance on PWA support. However, after several meetings with Apple and over months of trying, we never received a clear answer about whether Apple would disallow PWAs in their app store.

Since that time, a few members of the PWABuilder open source community successfully published PWAs in the iOS app store. Thus, we are releasing our new iOS platform with the knowledge that Apple may not approve some PWAs. Additionally, in 2021's Apple v. Epis lawsuit, Apple lawyers [cited PWAs on iOS](https://www.accc.gov.au/system/files/Apple%20Pty%20Limited%20%2810%20February%202021%29.pdf) as evidence against App Store monopoly. This suggests Apple intends to continue allowing PWAs on iOS.

Our recommendation is to build a great PWA. PWAs that provide real value to users, PWAs that are more than just websites, PWAs that look and feel like real apps. These are more likely to pass certification and get into the app store. Provide value to your users, and app stores will want your PWA. 

## Need more help?

If you're stuck, we're here to help. You can [open an issue](https://github.com/pwa-builder/pwabuilder/issues) and we'll help walk you through it.