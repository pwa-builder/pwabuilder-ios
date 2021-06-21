using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Models
{
    public class IOSAppPackageOptions
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }
        public string? SplashColor { get; set; }
        public string? ProgressBarColor { get; set; }
        public string? StatusBarColor { get; set; }
        public List<string>? PermittedUrls { get; set; }
        public WebAppManifest? Manifest { get; set; }
        public string? ManifestUrl { get; set; }

        public Validated Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(nameof(Name));
            }
            if (string.IsNullOrWhiteSpace(Url))
            {
                throw new ArgumentNullException(nameof(Url));
            }
            if (!Uri.TryCreate(Url, UriKind.Absolute, out var uri))
            {
                throw new ArgumentException("Url must be a valid, absolute URI");
            }
            if (string.IsNullOrWhiteSpace(ImageUrl))
            {
                throw new ArgumentNullException(nameof(ImageUrl));
            }
            if (!Uri.TryCreate(ImageUrl, UriKind.Absolute, out var imageUri))
            {
                throw new ArgumentException("Image url must be a valid, absolute URI");
            }
            if (Manifest == null)
            {
                throw new ArgumentNullException(nameof(Manifest));
            }
            Uri.TryCreate(ManifestUrl, UriKind.Absolute, out var manifestUri);
            if (manifestUri == null)
            {
                throw new ArgumentException("Manifest url must a valid, absolute URI");
            }

            var validSplashColor = GetValidColor(this.SplashColor, this.Manifest.Background_color, "#ffffff");
            var validProgressColor = GetValidColor(this.ProgressBarColor, this.Manifest.Theme_color, "#000000");
            var validStatusBarColor = GetValidColor(this.StatusBarColor, this.Manifest.Background_color, "#ffffff");
            var permittedUris = (PermittedUrls ?? new List<string>(0))
                .Select(url => GetUriFromWithProtocol(url))
                .Where(url => url != null)
                .Select(url => url!)
                .ToList();
            return new Validated(
                Name, 
                uri, 
                imageUri, 
                validSplashColor, 
                validProgressColor, 
                validStatusBarColor, 
                permittedUris, 
                Manifest,
                manifestUri);
        }
   
        private static Color GetValidColor(string? desiredColor, string? manifestColor, string fallbackColor)
        {
            var colors = new[] { desiredColor, manifestColor, fallbackColor };
            foreach (var color in colors)
            {
                if (Color.TryParseHexColor(color, out var validColor))
                {
                    return validColor;
                }
            }

            throw new ArgumentException("None of the potential colors were valid hex colors");
        }

        private static Uri? GetUriFromWithProtocol(string input)
        {
            if (Uri.TryCreate(input, UriKind.Absolute, out var uri))
            {
                return uri;
            }

            if (Uri.TryCreate("https://" + input, UriKind.Absolute, out var httpsUri))
            {
                return httpsUri;
            }

            return null;
        }

        public record Validated(
            string Name, 
            Uri Url, 
            Uri ImageUri, 
            Color SplashColor, 
            Color ProgressBarColor, 
            Color StatusBarColor, 
            List<Uri> PermittedUrls, 
            WebAppManifest Manifest, 
            Uri ManifestUri);
    }
}
