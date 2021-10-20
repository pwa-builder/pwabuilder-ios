# Next steps for getting your PWA into the Apple iOS Store
You've successfully generated an iOS app package for your PWA. 😎

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

If you're new to the app submission process, see [Submit your PWA to iOS App Store](/submit-to-app-store.md) for a visual explainer that will walk you through publishing your PWA to the iOS App Store.

## Disclaimer: Preview

PWABuilder's iOS platform is in preview stage. While the PWABuilder team has tested this platform, including building and publishing real PWAs with it, there may be bugs or unexplored edge cases or missing features. 

If you encount bugs or missing features, you can submit a PR to our [iOS template code here](https://github.com/pwa-builder/pwabuilder-ios/tree/main/Microsoft.PWABuilder.IOS.Web/Resources). Additionally, you can [open an issue](https://github.com/pwa-builder/pwabuilder/issues) to let us know about it.

## Disclaimer: Apple's ambiguous stance on PWAs

Caveat emptor: Apple may or may not accept your PWA in their app store.

In 2019, Apple released new [guidelines for HTML5 apps in the App Store](https://developer.apple.com/news/?id=09062019b). The new guidelines appear to state that PWAs may not be accepted into the App Store.

The PWABuilder team has attempted to clarify with Apple their stance on PWA support. Despite several meetings, we were unable to get an official answer on whether Apple would outright reject an app simply because it's a PWA.'

Since that time, a few members of the PWABuilder open source community successfully published PWAs in the iOS app store. Thus, we are releasing our new iOS platform with the knowledge that Apple may not approve some PWAs. Additionally, in 2021's Apple v. Epis lawsuit, Apple lawyers [cited PWAs on iOS](https://www.accc.gov.au/system/files/Apple%20Pty%20Limited%20%2810%20February%202021%29.pdf) as evidence against App Store monopoly. This suggests Apple intends to continue allowing PWAs on iOS.

**Our recommendation is to build a great PWA.** PWAs that provide real value to users, PWAs that are more than just websites, PWAs that look and feel like real apps. These are more likely to pass certification and get into the app store. Provide value to your users, and app stores will _want_ your PWA. 

## Need more help?

Check out our [PWABuilder iOS FAQs](/faq.md).

If you're stuck, we're here to help. You can [open an issue](https://github.com/pwa-builder/PWABuilder/issues/new?assignees=&labels=ios-platform&body=Type%20your%20question%20here.%20Please%20include%20the%20URL%20to%20your%20PWA.%0A%0A%3E%20If%20my%20answer%20was%20in%20the%20docs%20all%20along%2C%20I%20promise%20to%20give%20%245%20USD%20to%20charity.) and we'll help walk you through it.