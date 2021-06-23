using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.PWABuilder.IOS.Web.Models;
using Microsoft.PWABuilder.IOS.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web
{
    public class Startup
    {
        private readonly string AllowedOriginsPolicyName = "allowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOriginsPolicyName, builder => builder
                    .SetIsOriginAllowed(CheckAllowedOriginCors)
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddTransient<TempDirectory>();
            services.AddTransient<ImageGenerator>();
            services.AddTransient<SourceCodeUpdater>();
            services.AddTransient<IOSPackageCreator>();
            services.AddHttpClient();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microsoft.PWABuilder.IOS.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microsoft.PWABuilder.IOS.Web v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private bool CheckAllowedOriginCors(string origin)
        {
            var allowedOrigins = new[]
            {
                "https://www.pwabuilder.com",
                "https://pwabuilder.com",
                "https://preview.pwabuilder.com",
                "https://localhost:3333",
                "https://localhost:3000",
                "http://localhost:3333",
                "http://localhost:3000",
                "https://localhost:8000",
                "http://localhost:8000",
                "https://nice-field-047c1420f.azurestaticapps.net"
            };
            return allowedOrigins.Any(o => origin.Contains(o, StringComparison.OrdinalIgnoreCase));
        }
    }
}
