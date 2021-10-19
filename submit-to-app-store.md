# Submitting your PWA to the iOS App Store

Once you've packaged your PWA with PWABuilder and compiled the [source code with Xcode](next-steps.md), you can submit your app to the iOS App Store.

The process looks like this:

1. Sign into your Apple Developer account
2. Create your Bundle ID
3. Create your app reservation
4. Upload your app package

Each step is described below.

## 1. Sign into your Apple Developer account

To submit to the App Store, [sign-in to your Apple Developer Account](https://developer.apple.com/account/).

If you don't have an Apple Developer account, [enroll](https://developer.apple.com/programs/enroll). Enrollment cost is $99 USD/year, though [non-profits can have this fee waived](https://developer.apple.com/support/membership-fee-waiver/).)

## 2. Create your Bundle ID

Once you're signed in, you'll need to create a Bundle ID for your app. 

> 💁‍♀️ What's a Bundle ID? 
> A Bundle ID is a string (e.g. com.myawesomepwa) that uniquely identifies your app in the App Store.
> Apple recommends using a reverse-domain style string, such as com.domainname.appname.
> This string must be the same string you used in PWABuilder when packaging your iOS app. By default, PWABuilder uses the reverse-domain of your PWA as your Bundle ID. 
> If you're unsure what value you should use as your Bundle ID, go back to PWABuilder, package for iOS, and take note of the Bundle ID in the iOS options dialog. This value is also available inside your `project.pbxproj` file, next to the `PRODUCT_BUNDLE_IDENTIFIER` string.

Choose `Certificates, Identifiers & Profiles` to create your Bundle ID.

(TODO certs & identifiers image here)

Then choose `Identifiers` and click `+` to add a new identifier.

(TODO new identifier image here)

Choose `App IDs`, then choose `App` as the type. You'll be prompted for a `Description` and `Bundle ID`.

Add any `Description` you like, then paste in your Bundle ID into the `Identifier` text box:

(TODO: bundle ID and description image here)

💁‍♂️ Remember, **`Bundle ID` must be set to the same value you used when generating your package in PWABuilder.** If you're unsure what your Bundle ID is, go back to PWABuilder, package for iOS, and take note of your `Bundle ID`. Alternately, you can find your Bundle ID inside your `project.pbxproj` file, next to the `PRODUCT_BUNDLE_IDENTIFIER` string.

You may leave all `Capabilities` and `App Services` unchecked.

Click `Continue` and then `Register` to finish creating your Bundle ID.

## 3. Create your app reservation

Go back to [developer.apple.com/account](https://developer.apple.com/account/) and choose `App Store Connect`:

(TODO app store connect image here)

Once you're in [App Store Connect](https://appstoreconnect.apple.com), choose `My Apps`

(TODO my apps image here)

Your apps will be listed. If you want to update an existing app, choose that app. Otherwise, click `+` -> `New App`:

(TODO new app image here)

You'll be asked for details about your new app. For platform, choose `iOS`. For `Bundle ID`, choose the Bundle ID you created in the previous step. For `SKU`, you can use any string you like. For `User Access`, specify `Full Access`:

(TODO new app details image here)

## 4. Upload your app package

After creating your app reservation in the last step, you'll be redirected to your app details page where you'll upload your app package, add screenshots, description of your app, and more.

TODO: continue here