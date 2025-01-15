using Core.Application.Services;
using Core.Domain.Interfaces.Services;
using Infrastructure.ApiDocumentation;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;

namespace GitHubAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddConfiguration(configuration) 
                .AddEnvironmentVariables(prefix: "LSLAPI_");

            Configuration = builder.Build();

            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddControllersAsServices();

            var assembly = AppDomain.CurrentDomain.Load("Core.Application");
            services.AddMediatR(assembly);

            services.AddHttpClient();

            services.AddSwaggerFramework(Environment);

            services.AddServices();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment() 
                || Environment.EnvironmentName.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerFramework();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
