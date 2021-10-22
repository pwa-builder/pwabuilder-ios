using Microsoft.Extensions.Options;
using Microsoft.PWABuilder.IOS.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Services
{
    /// <summary>
    /// Unzips the ios-project-src.zip file containing the iOS app template, then updates the placeholder values
    /// with all the app name and details.
    /// </summary>
    public class SourceCodeUpdater
    {
        private readonly AppSettings appSettings;

        public SourceCodeUpdater(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        public async Task Update(IOSAppPackageOptions.Validated options, string sourceDir)
        {
            await UpdateAppColors(sourceDir, options);
            await UpdateAppNameAndUrls(sourceDir, options);
            await UpdateAppBundleId(sourceDir, options);
        }

        private async Task UpdateAppColors(string sourceDir, IOSAppPackageOptions.Validated options)
        {            
            var launchScreenPath = GetExistingFile(sourceDir, "LaunchScreen.storyboard");
            var mainStoryboardPath = GetExistingFile(sourceDir, "Main.storyboard");

            // Set the splash color.
            var existingSplashColorLine = "<color key=\"backgroundColor\" red=\"0.0\" green=\"0.0\" blue=\"1\" alpha=\"1\" colorSpace=\"custom\" customColorSpace=\"sRGB\"/>";
            var desiredSplashColorLine = $"<color key=\"backgroundColor\" {options.SplashColor.ToStoryboardColorString()} alpha=\"1\" colorSpace=\"custom\" customColorSpace=\"sRGB\"/>";
            await ReplaceText(launchScreenPath, existingSplashColorLine, desiredSplashColorLine);
            await ReplaceText(mainStoryboardPath, existingSplashColorLine, desiredSplashColorLine);

            // Set the status bar color
            var existingStatusBarColorLine = "<color key=\"backgroundColor\" red=\"0.0\" green=\"1\" blue=\"0.0\" alpha=\"1\" colorSpace=\"custom\" customColorSpace=\"sRGB\"/>";
            var desiredStatusBarColorLine = $"<color key=\"backgroundColor\" {options.StatusBarColor.ToStoryboardColorString()} alpha=\"1\" colorSpace=\"custom\" customColorSpace=\"sRGB\"/>";
            await ReplaceText(mainStoryboardPath, existingStatusBarColorLine, desiredStatusBarColorLine);

            // Set the progress var color
            var existingProgressBarColorLine = "<color key=\"tintColor\" red=\"0.0\" green=\"0.0\" blue=\"1\" alpha=\"1\" colorSpace=\"custom\" customColorSpace=\"sRGB\"/>";
            var desiredProgressBarColorLine = $"<color key=\"tintColor\" {options.ProgressBarColor.ToStoryboardColorString()} alpha=\"1\" colorSpace=\"custom\" customColorSpace=\"sRGB\"/>";
            await ReplaceText(mainStoryboardPath, existingProgressBarColorLine, desiredProgressBarColorLine);
        }

        private async Task UpdateAppNameAndUrls(string sourceDir, IOSAppPackageOptions.Validated options)
        {
            var infoPlistFilePath = GetExistingFile(sourceDir, "Info.plist");
            var settingsFilePath = GetExistingFile(sourceDir, "Settings.swift");
            var entitlementsFilePath = GetExistingFile(sourceDir, "Entitlements.plist");

            // Update app name
            var appNameExisting = "<string>PWAShellz</string>";
            var appNameDesired = $"<string>{options.Name}</string>";
            await ReplaceText(infoPlistFilePath, appNameExisting, appNameDesired);

            // Add URL and permitted URLs to app bound domains (used for service worker) in Info.plist
            var urlExisting = "<string>webboard.app/?pwashellz</string>";
            var urlDesiredBuilder = new System.Text.StringBuilder();
            urlDesiredBuilder.Append($"<string>{options.Url.ToString().Replace("https://", string.Empty).TrimEnd('/')}</string>"); // Append the URL of the PWA
            options.PermittedUrls.ForEach(permittedUrl => urlDesiredBuilder.Append($"\r<string>{permittedUrl.ToString().Replace("https://", string.Empty).Replace("http://", string.Empty)}</string>"));
            await ReplaceText(infoPlistFilePath, urlExisting, urlDesiredBuilder.ToString());

            // Update app URL in Settings.swift
            var settingsUrlExisting = "let rootUrl = URL(string: \"https://webboard.app/?pwashellz\")!";
            var settingsUrlDesired = $"let rootUrl = URL(string: \"{options.Url.ToString().TrimEnd('/')}\")!";
            await ReplaceText(settingsFilePath, settingsUrlExisting, settingsUrlDesired);

            // Update allowed origin in Settings.swift
            var allowedOriginExisting = "let allowedOrigin = \"webboard.app\"";
            var allowedOriginDesired = $"let allowedOrigin = \"{options.Url.ToString().Replace("https://", string.Empty).TrimEnd('/')}\"";
            await ReplaceText(settingsFilePath, allowedOriginExisting, allowedOriginDesired);

            // Update authOrigins in Settings.swift
            var authOriginsExisting = "let authOrigins: [String] = [\"login.microsoftonline.com\"]";
            var authOriginsPermittedUrls = options.PermittedUrls
                .Select(url => url.ToString().Replace(url.Scheme + "://", string.Empty))
                .Select(url => $"\"{url}\"");
            var authOriginsDesired = $"let authOrigins: [String] = [{string.Join(',', authOriginsPermittedUrls)}]";
            await ReplaceText(settingsFilePath, authOriginsExisting, authOriginsDesired);

            // Update app URL in Entitlements.plist. This lets the PWA app handle links to the domain.
            // Note: value here must be the host only. Apple says, "Make sure to only include the desired subdomain and the top-level domain. Don’t include path and query components or a trailing slash (/)."
            // See https://developer.apple.com/documentation/xcode/supporting-associated-domains
            var entitlementsAppUrlExisting = "<string>applinks:pwashellz.com</string>";
            var entitlementsAppUrlDesired = $"<string>applinks:{options.Url.Host}</string>"; // Trim ending slash. See 
            await ReplaceText(entitlementsFilePath, entitlementsAppUrlExisting, entitlementsAppUrlDesired);
        }

        private Task UpdateAppBundleId(string sourceDir, IOSAppPackageOptions.Validated options)
        {
            var projFile = GetExistingFile(sourceDir, "project.pbxproj");
            var existingBundleText = "PRODUCT_BUNDLE_IDENTIFIER = com.pwa.shell;";
            var desiredBundleText = $"PRODUCT_BUNDLE_IDENTIFIER = {options.BundleId};";
            return ReplaceText(projFile, existingBundleText, desiredBundleText);
        }

        private void UpdatePushSubscription(string sourceDir)
        {
            // TODO: Can we leave this? What happens if we just leave the code in, but don't supply any push notifications? will the app still work?
            //
            // \pwa-shell\PushNotifications.swift
            // \pwa-shell\AppDelegate.swift
            // \pwa-shell\WebView.swift
            // \pwa-shell\Settings.swift has gcmMessageIDKey - 
        }

        private async Task ReplaceText(string filePath, string existing, string desired)
        {
            var text = await File.ReadAllTextAsync(filePath);
            if (!text.Contains(existing))
            {
                throw new ArgumentException($"Expected {filePath} to contain {existing}, but it was missing");
            }

            await File.WriteAllTextAsync(filePath, text.Replace(existing, desired));
        }

        private string GetExistingFile(string sourceDir, string fileName)
        {
            var match = Directory.EnumerateFiles(sourceDir, fileName, new EnumerationOptions { RecurseSubdirectories = true }).SingleOrDefault();
            if (match == null)
            {
                throw new Exception("Unable to find required filed " + fileName);
            }
            return match;
        }
    }
}
