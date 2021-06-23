using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.PWABuilder.IOS.Web.Models;
using Microsoft.PWABuilder.IOS.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Services
{
    public class IOSPackageCreator
    {
        private readonly SourceCodeUpdater sourceUpdater;
        private readonly ImageGenerator imageGenerator;
        private readonly TempDirectory temp;
        private readonly AppSettings appSettings;
        private readonly ILogger<IOSPackageCreator> logger;

        public IOSPackageCreator(
            SourceCodeUpdater sourceUpdater, 
            ImageGenerator imageGenerator,
            IOptions<AppSettings> appSettings,
            TempDirectory temp,
            ILogger<IOSPackageCreator> logger)
        {
            this.sourceUpdater = sourceUpdater;
            this.imageGenerator = imageGenerator;
            this.appSettings = appSettings.Value;
            this.temp = temp;
            this.logger = logger;
        }

        /// <summary>
        /// Generates an iOS package.
        /// </summary>
        /// <param name="options">The package creation options.</param>
        /// <returns>The path to a zip file.</returns>
        public async Task<byte[]> Create(IOSAppPackageOptions.Validated options)
        {
            try
            {
                var outputDir = temp.CreateDirectory($"ios-package-{Guid.NewGuid()}");

                // Unzip the project template.
                ZipFile.ExtractToDirectory(appSettings.SourceCodeZipPath, outputDir);

                // Update the source files.
                await this.sourceUpdater.Update(options, outputDir);

                // Create any missing images for the iOS template.
                await this.imageGenerator.Generate(options, WebAppManifestContext.From(options.Manifest, options.ManifestUri), outputDir);

                // Zip it all up.
                var zipFile = CreateZip(outputDir);
                return await File.ReadAllBytesAsync(zipFile);
            }
            catch (Exception error)
            {
                logger.LogError(error, "Error generating iOS package");
                throw;
            }
            finally
            {
                temp.CleanUp();
            }
        }

        private string CreateZip(string outputDir)
        {
            var zipFilePath = temp.CreateFile();
            using var zipFile = File.Create(zipFilePath);
            using var zipArchive = new ZipArchive(zipFile, ZipArchiveMode.Create);
            zipArchive.CreateEntryFromFile(appSettings.NextStepsPath, "next-steps.html");
            zipArchive.CreateEntryFromDirectory(outputDir, "src");
            return zipFilePath;
        }
    }
}
