# Submitting your PWA to the iOS App Store

Once you've packaged your PWA with PWABuilder and [followed the steps to build your package](/next-steps.md), you can submit your app to the iOS App Store.

The process looks like this:

1. Sign into your Apple Developer account
2. Create a Bundle ID
3. Create a Certificate Signing Request (CSR)
4. Create a Provisioning Profile
5. Create an app reservation
6. Upload your app package

Each step is described below.

## 1. Sign into your Apple Developer account

To submit to the App Store, [sign-in to your Apple Developer Account](https://developer.apple.com/account/).

If you don't have an Apple Developer account, [enroll here](https://developer.apple.com/programs/enroll). Enrollment costs $99 USD/year, though [non-profits can have this fee waived](https://developer.apple.com/support/membership-fee-waiver/).

## 2. Create your Bundle ID

Once you're signed in, you'll need to create a Bundle ID for your app. 

> 💁‍♀️ What's a Bundle ID?
> 
> A Bundle ID is a string (e.g. com.myawesomepwa) that uniquely identifies your app in the App Store.
> Apple recommends using a reverse-domain style string, such as com.domainname.appname.
>
> This string must be the same string you used in PWABuilder when packaging your iOS app. By default, PWABuilder uses the reverse-domain of your PWA as your Bundle ID.
>
> If you're unsure what value you should use as your Bundle ID, go back to PWABuilder, package for iOS, and take note of the Bundle ID in PWABuilder's iOS options dialog.

Go to your [Apple Developer account page](https://developer.apple.com/account/) and choose `Certificates, Identifiers & Profiles` to create your Bundle ID.

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

Under `Capabilities`, **enable** the following capabilities:

- Associated Domains
- Push Notifications

Click `Continue` and then `Register` to finish creating your Bundle ID.

## 3. Create a Certificate Signing Request (CSR)

On your Mac, launch `Keychain Access` app. From the top menu bar, choose `Keychain Access` -> `Certificate Assistant` -> `Request a Certificate from a Certificate Authority`

![image](https://user-images.githubusercontent.com/312936/138376813-73100ac3-832a-4fda-8f9d-583b0517a398.png)

Add your email address and your name. You may leave `CA Email Address` empty. Choose `Saved to disk`, then click `Continue`:

![image](https://user-images.githubusercontent.com/312936/138376830-23a307d3-19be-44db-bf66-18d5186afc96.png)

With your CSR file saved, go to your [Apple Developer Account page](https://developer.apple.com/account) and choose `Certificates, Identifiers & Profiles` -> `Certificates`. Click `+` to add a new certificate:

![image](https://user-images.githubusercontent.com/312936/138376850-de8b9d84-2ee1-4906-a3f7-7dc2ebbd8d06.png)

Choose `Apple Distribution` and click `Continue`:

(TODO: Apple distribution image)

You'll be prompted to upload a Certificate Signing Request (CSR) file. Choose the file you created in the previous step and click `Continue`:

(TODO: CSR file chosen)

On the final certificate screen, choose `Download` to save your `.cer` certificate file to disk.

## 4. Create a Provisioning Profile

Go back to your [Apple Developer Account page](https://developer.apple.com/account) and choose `Certificates, Identifiers & Profiles` -> `Profiles`. Then click `+` to create a new Provisioning Provile:

![image](https://user-images.githubusercontent.com/312936/138376889-6f87cd34-f416-4b19-8efb-8514375e2978.png)

On the New Provisioning Profile page, choose `App Store`, and click `Continue`:

![image](https://user-images.githubusercontent.com/312936/138376946-84c4cae2-d85e-4e29-8b48-e5eec81e4815.png)

On the next screen, choose your desired app ID -- the Bundle ID you created in step 1 -- then click `Continue`:

![image](https://user-images.githubusercontent.com/312936/138376988-9536f349-8b7a-48b2-8d1e-7b03ae9ba267.png)

On the next page, you'll be asked to choose an existing certificate. Choose the certificate you created in the previous step, then click `Continue`:

(TODO: Generate Provisioning Profile -> Choose Cert)

On the final page, provide a `Provisioning Profile Name`, such as My PWA Publishing, then click `Generate`:

(TODO: name provisioning profile)

On the final page, choose `Download` to download you `.mobileprovision` Provisioning Profile file.

## 5. Create your app reservation

Go back to [developer.apple.com/account](https://developer.apple.com/account/) and choose `App Store Connect`:

![image](https://user-images.githubusercontent.com/312936/138008617-5205be9e-a750-40fa-a35c-13a43fda8d48.png)

Once you're in [App Store Connect](https://appstoreconnect.apple.com), choose `My Apps`

![image](https://user-images.githubusercontent.com/312936/138008636-9871da39-34f5-433a-817c-cafd76daf4bd.png)

Your existing apps will be listed. If you want to update an existing app, choose that app. Otherwise, click `+` -> `New App`:

![image](https://user-images.githubusercontent.com/312936/138008660-842d5edb-a4bd-4875-b997-0df931a4f3dd.png)

You'll be asked for details about your new app. For platform, choose `iOS`. For `Bundle ID`, choose the Bundle ID you created in the previous step. For `SKU`, you can use any string you like. For `User Access`, specify `Full Access`:

![image](https://user-images.githubusercontent.com/312936/138008701-ee5e070d-6569-42d3-9b0b-c5ad9fcbc04d.png)

Click `Create` to complete your app reservation.

## 6. Upload your app package

After creating your app reservation in the last step, you'll be redirected to your app details page where you'll upload your app package, add screenshots, description of your app, and more.

(TODO: image of app details page)

On this page, fill our the information about your app, such as `Version`, `Description`, `Keywords`, Support URL, screenshots, and other metadata.

When you're ready to upload your PWA app package, you'll submit your package by signing into Xcode, assigning your project to your Apple Developer account, then creating an archive.

Each step is described below.

### Sign into Xcode

Go to `Xcode` menu -> `Preferences`:

(TODO: image of Xcode preferences menu)

In the Preferences dialog, choose `Accounts`. If your Apple Developer account isn't listed, click the `+` button to add it to Xcode.

Once you've signed into your Apple Developer account in Xcode, dismiss the Preferences dialog.

### Assign your project to your account

In Xcode, choose choose `Project Navigator (📁)` -> `pwa-shell` -> `Signing & Capabilities` -> Team. Choose a team

> 💁🏽‍♀️ Heads up
>
> If you receive an error saying, "Failed to create provisioning profile. There are no devices registered in your account...", then you'll need to register an iOS device to your account. To do that, go to https://developer.apple.com/account/resources/devices/list and register a device.

Create an archive in Xcode

Open `pwa-shell.xcworkspace` file in Xcode. With your PWA project opened in Xcode, choose `pwa-shell` -> `pwa-shell` -> `Any iOS Device (arm64)`:

(TODO: image of Any iOS Device)

Then from the Xcode menu bar, choose `Product` -> `Archive`:

(TODO: image of Product->Archive)



