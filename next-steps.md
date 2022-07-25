# Next steps for getting your PWA into the Apple iOS Store
You've successfully generated an iOS app package for your PWA. 😎

Your next steps:
1. **Build your project** in Xcode
2. **Test your app**: Run your project in Xcode to try out your PWA on an iPhone simulator or physical iOS device.
3. **Submit your app to the iOS App Store**

What you'll need:

- A **Mac with Xcode installed** (For details, see [our FAQ](/faq.md#can-i-publish-to-the-app-store-without-a-mac).)
- An **[Apple Developer Account](/submit-to-app-store.md#1-sign-into-your-apple-developer-account)** to publish your app to the App Store.

Each step is explained below.

## 1. Build your project in Xcode

Your zip file contains a `src` folder containing the source code for your iOS app. You'll [need a Mac with Xcode installed](/faq.md#can-i-publish-to-the-app-store-without-a-mac) to build this project.

Unzip the `src` folder and open a terminal in `src` and execute the following command:

`pod install`

> 💁‍♂️ *Heads up*: 
> 
> If you get an error running `pod install`, you'll need to first run this command: 
>- Intel Macs: `sudo gem install cocoapods`. Once completed, you can run `pod install`.
>- M1 Macs: `sudo gem uninstall cocoapods` followed by `brew install cocoapods`. Once completed, you can run `pod install`.

Then, open the `src/[your PWA name].xcworkspace` file.

This will open the project in Xcode. In Xcode, click `Product` > `Build` to build your project.

## 2. Test your app an iPhone simulator

With the project opened in Xcode, click ▶️ to run your PWA in an iPhone simulator. You may also choose other iOS simulators to try our your app on those devices.

## 3. Upload your app to the iOS App Store

Once you've built and tested your app, it's ready to be uploaded to the iOS App Store.

See [Submit your PWA to the iOS App Store](/submit-to-app-store.md) for a step-by-step guide to publishing your PWA iOS package to the iOS App Store.

### Disclaimer: Preview

PWABuilder's iOS platform is in preview stage. While the PWABuilder team has tested this platform, including building and publishing real PWAs with it, there may be bugs or unexplored edge cases or missing features. 

If you encounter bugs or missing features, you can submit a PR to our [iOS code](https://github.com/pwa-builder/pwabuilder-ios/tree/main/Microsoft.PWABuilder.IOS.Web/Resources). Additionally, you can [open an issue](https://github.com/pwa-builder/pwabuilder/issues) to let us know about it.

### Disclaimer: Apple's ambiguous stance on PWAs

Caveat emptor: PWABuilder doesn't guarantee that your app will be accepted into Apple's App Store.

In 2019, Apple released new [guidelines for HTML5 apps in the App Store](https://developer.apple.com/news/?id=09062019b). The new guidelines appear to state that certain kinds of web apps (gambling, lotteries, etc.) may not be accepted into the App Store.

The PWABuilder team attempted to clarify with Apple their stance on PWAs in their App Store. Despite several meetings, we were unable to receive an official answer from Apple.

Since that time, a few members of the PWABuilder open source community successfully published PWAs in the iOS app store. Thus, we are releasing our new iOS platform with the knowledge that Apple may not approve some PWAs, especially if they are little more than traditional websites in an app frame.

**Our recommendation is to build a great PWA.** PWAs that provide real value to users, PWAs that are more than just websites, PWAs that look and feel like real apps. These are more likely to pass certification and get into the app store. Provide value to your users, and app stores will _want_ your PWA. 

## Need more help?

Check out our [PWABuilder iOS FAQs](/faq.md) for answers to frequently asked questions about PWABuilder's iOS platform.

If you're stuck, we're here to help. You can [open an issue](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=ios-platform,question%20%3Agrey_question%3A&body=Type%20your%20question%20here.%20Please%20include%20the%20URL%20to%20your%20PWA.%0A%0A%3E%20If%20my%20answer%20was%20in%20the%20docs%20all%20along%2C%20I%20promise%20to%20give%20%245%20USD%20to%20charity.) and we'll help walk you through it.
