using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.PWABuilder.IOS.Web.Models;
using Microsoft.PWABuilder.IOS.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> logger;
        private readonly IOSPackageCreator packageCreator;
        private readonly AnalyticsService analytics;

        public PackagesController(
            IOSPackageCreator packageCreator,
            AnalyticsService analytics,
            ILogger<PackagesController> logger)
        {
            this.packageCreator = packageCreator;
            this.analytics = analytics;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<FileResult> Create(IOSAppPackageOptions options)
        {
            try
            {
                var optionsValidated = ValidateOptions(options);
                var packageBytes = await packageCreator.Create(optionsValidated);
                analytics.Record(optionsValidated.Url.ToString(), success: true, error: null);
                return File(packageBytes, "application/zip", $"{options.Name}-ios-app-package.zip");
            }
            catch (Exception error)
            {
                analytics.Record(options.Url ?? "https://EMPTY_URL", success: false, error: error.ToString());
                throw;
            }
        }

        private IOSAppPackageOptions.Validated ValidateOptions(IOSAppPackageOptions options)
        {
            try
            {
                return options.Validate();
            }
            catch (Exception error)
            {
                logger.LogError(error, "Invalid package options");
                throw;
            }
        }
    }
}
