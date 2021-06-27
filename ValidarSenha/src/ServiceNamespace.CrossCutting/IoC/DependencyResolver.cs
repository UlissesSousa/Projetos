using Microsoft.Extensions.DependencyInjection;
using ServiceNamespace.Application;
using ServiceNamespace.Application.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ServiceNamespace.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {            
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            
        }
    }
}