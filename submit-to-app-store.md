# Submitting your PWA to the iOS App Store

Once you've packaged your PWA with PWABuilder and [followed the steps to build your package](/next-steps.md), you can submit your app to the iOS App Store.

The process looks like this:

1. Sign into your Apple Developer account
2. Create your Bundle ID
3. Create your app reservation
4. Upload your app package

Each step is described below.

## 1. Sign into your Apple Developer account

To submit to the App Store, [sign-in to your Apple Developer Account](https://developer.apple.com/account/).

If you don't have an Apple Developer account, [enroll here](https://developer.apple.com/programs/enroll). Enrollment costs $99 USD/year, though [non-profits can have this fee waived](https://developer.apple.com/support/membership-fee-waiver/).

## 2. Create your Bundle ID

Once you're signed in, you'll need to create a Bundle ID for your app. 

> 💁‍♀️ What's a Bundle ID?
> 
> A Bundle ID is a string (e.g. com.myawesomepwa) that uniquely identifies your app in the App Store.> 
> Apple recommends using a reverse-domain style string, such as com.domainname.appname.
>
> This string must be the same string you used in PWABuilder when packaging your iOS app. By default, PWABuilder uses the reverse-domain of your PWA as your Bundle ID.
>
> If you're unsure what value you should use as your Bundle ID, go back to PWABuilder, package for iOS, and take note of the Bundle ID in the iOS options dialog. This value is also available inside your `project.pbxproj` file, next to the `PRODUCT_BUNDLE_IDENTIFIER` string.

Choose `Certificates, Identifiers & Profiles` to create your Bundle ID.

![image](https://user-images.githubusercontent.com/312936/138008456-bc72e5c5-1314-4844-8065-8a9c2f1a231b.png)

Then choose `Identifiers` and click `+` to add a new identifier.

![image](https://user-images.githubusercontent.com/312936/138008541-9ae86cac-05e2-4b50-a0e9-1f6297638bd3.png)

Choose `App IDs`, then choose `App` as the type. You'll be prompted for a `Description` and `Bundle ID`.

Add any `Description` you like, then paste in your Bundle ID into the `Identifier` text box:

![image](https://user-images.githubusercontent.com/312936/138008584-7aaf1b12-2423-4a1d-9de2-d473d4fe6330.png)

> 💁‍♂️ Remember, **`Bundle ID` must be set to the same value you used when generating your package in PWABuilder.**
> 
> If you're unsure what your Bundle ID is, go back to PWABuilder, package for iOS, and take note of your `Bundle ID`.
> 
> Alternately, you can find your Bundle ID inside your `project.pbxproj` file, next to the `PRODUCT_BUNDLE_IDENTIFIER` string.

You may leave all `Capabilities` and `App Services` unchecked.

Click `Continue` and then `Register` to finish creating your Bundle ID.

## 3. Create your app reservation

Go back to [developer.apple.com/account](https://developer.apple.com/account/) and choose `App Store Connect`:

![image](https://user-images.githubusercontent.com/312936/138008617-5205be9e-a750-40fa-a35c-13a43fda8d48.png)

Once you're in [App Store Connect](https://appstoreconnect.apple.com), choose `My Apps`

![image](https://user-images.githubusercontent.com/312936/138008636-9871da39-34f5-433a-817c-cafd76daf4bd.png)

Your existing apps will be listed. If you want to update an existing app, choose that app. Otherwise, click `+` -> `New App`:

![image](https://user-images.githubusercontent.com/312936/138008660-842d5edb-a4bd-4875-b997-0df931a4f3dd.png)

You'll be asked for details about your new app. For platform, choose `iOS`. For `Bundle ID`, choose the Bundle ID you created in the previous step. For `SKU`, you can use any string you like. For `User Access`, specify `Full Access`:

![image](https://user-images.githubusercontent.com/312936/138008701-ee5e070d-6569-42d3-9b0b-c5ad9fcbc04d.png)

Click `Create` to complete your app reservation.

## 4. Upload your app package

After creating your app reservation in the last step, you'll be redirected to your app details page where you'll upload your app package, add screenshots, description of your app, and more.

TODO: continue here
