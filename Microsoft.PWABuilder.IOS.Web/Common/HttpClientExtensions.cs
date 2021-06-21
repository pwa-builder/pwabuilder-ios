using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Common
{
    public static class HttpClientExtensions
    {
        public static void AddLatestEdgeUserAgent(this HttpClient http)
        {
            var userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36 Edg/91.0.864.41";
            http.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }
    }
}
