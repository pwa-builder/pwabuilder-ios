using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Models
{
    public class AppSettings
    {
        public string IOSSourceCodePath { get; set; } = string.Empty;
        public string NextStepsPath { get; set; } = string.Empty;
        public string ImageGeneratorApiUrl { get; set; } = string.Empty;
        public string AnalyticsUrl { get; set; } = string.Empty;
        public string ApplicationInsightsConnectionString { get; set; } = string.Empty;
    }
}
