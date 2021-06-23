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

        public AnalyticsService(
            IOptions<AppSettings> settings,
            IHttpClientFactory httpClientFactory,
            ILogger<AnalyticsService> logger)
        {
            this.settings = settings;
            this.http = httpClientFactory.CreateClient();
            this.logger = logger;
        }

        public void Record(string url, bool success, string? error)
        {
            if (string.IsNullOrEmpty(this.settings.Value.AnalyticsUrl))
            {
                this.logger.LogWarning("Skipping analytics recording due to empty analytics URL");
                return;
            }

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
