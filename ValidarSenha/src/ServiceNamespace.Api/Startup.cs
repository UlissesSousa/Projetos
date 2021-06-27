using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceNamespace.Api.Filters;
using ServiceNamespace.Api.Logging;
using ServiceNamespace.CrossCutting.Assemblies;
using ServiceNamespace.CrossCutting.IoC;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ServiceNamespace.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddMvc(options => options.Filters.Add(new DefaultExceptionFilterAttribute()));

            services.AddLoggingSerilog();

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            services.AddDependencyResolver();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ServiceNamespace",
                    Description = "API - ServiceNamespace",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "ServiceNamespace.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "ServiceNamespace.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/ServiceNamespace");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/ServiceNamespace/swagger/v1/swagger.json", "API ServiceNamespace");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
