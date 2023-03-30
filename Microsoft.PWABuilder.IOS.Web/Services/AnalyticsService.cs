using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.PWABuilder.IOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Services
{
    /// <summary>
    /// Reports iOS package generation to the PWABuilder analytics backend service.
    /// </summary>
    public class AnalyticsService
    {
        private readonly IOptions<AppSettings> settings;
        private readonly ILogger<AnalyticsService> logger;
        private readonly HttpClient http;
        private readonly TelemetryClient telemetryClient;
        private readonly bool isAppInsightsEnabled;

        public AnalyticsService(
            IOptions<AppSettings> settings,
            IHttpClientFactory httpClientFactory,
            ILogger<AnalyticsService> logger,
            TelemetryClient telemetryClient)
        {
            this.settings = settings;
            this.http = httpClientFactory.CreateClient();
            this.logger = logger;
            this.telemetryClient = telemetryClient;
            if (!string.IsNullOrEmpty(this.settings.Value.ApplicationInsightsConnectionString))
            {
                this.isAppInsightsEnabled = true;
            }
            else
            {
                this.isAppInsightsEnabled = false;
            }
        }

        public void Record(string url, bool success, IOSAppPackageOptions.Validated? packageOptions, AnalyticsInfo? analyticsInfo, string? error)
        {
            //Code to remove starts here  (in the future when we don't need RavenDB)
            if (!string.IsNullOrEmpty(this.settings.Value.AnalyticsUrl))
            {
                LogToRavenDB(url, success, error);
            }
            else
            {
                this.logger.LogWarning("Skipping analytics event recording in RavenDB due to no analytics URL in app settings. For development, this should be expected.");
            }
            //Code to remove ends here

            if (!this.isAppInsightsEnabled)
            {
                this.logger.LogWarning("Skipping analytics event recording in App insights due to no connection string. For development, this should be expected.");
                return;
            }

            this.telemetryClient.Context.Operation.Id = analyticsInfo?.correlationId != null ? analyticsInfo.correlationId : System.Guid.NewGuid().ToString();

            Dictionary<string, string> record;
            var name = "";
            if (success && packageOptions != null)
            {
                record = new() { { "URL", url.ToString() }, { "IOSBundleID", packageOptions.BundleId ?? "" }, { "IOSAppName", packageOptions.Name ?? ""} };
                name = "IOSPackageEvent";
            }
            else
            {
                record = new() { { "URL", url.ToString() }, { "IOSPackageError", error ?? "" } };
                name = "IOSPackageFailureEvent";
            }
            if (analyticsInfo?.platformId != null)
            {
                record.Add("PlatformId", analyticsInfo.platformId);
                if (analyticsInfo?.platformIdVersion != null)
                {
                    record.Add("PlatformVersion", analyticsInfo.platformIdVersion);
                }
            }
            telemetryClient.TrackEvent(name, record);
            ;
        }

        private void LogToRavenDB(string url, bool success, string? error)
        {
            var args = System.Text.Json.JsonSerializer.Serialize(new
            {
                Url = url,
                IOSPackage = success,
                IOSPackageError = error
            });
            this.http.PostAsync(this.settings.Value.AnalyticsUrl, new StringContent(args))
                .ContinueWith(_ => logger.LogInformation("Successfully sent {url} to URL logging service. Success = {success}, Error = {error}", url, success, error), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task => logger.LogError(task.Exception ?? new Exception("Unable to send URL to logging service"), "Unable to send {url} to logging service due to an error", url), TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
