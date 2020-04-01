using GOSTechnology.Core.Archives.Domain.Interfaces;
using GOSTechnology.Core.Archives.Domain.Services;
using GOSTechnology.Core.Archives.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GOSTechnology.Core.Archives.Api.Infra
{
    /// <summary>
    /// DependencyInjectionConfiguration.
    /// </summary>
    public static class DependencyInjectionConfiguration
    {
        /// <summary>
        /// AddServices.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection builder)
        {
            builder.AddScoped<IArchiveService, ArchiveService>();
            builder.AddScoped<IArchiveRepository, ArchiveRepository>();
            return builder;
        }
    }
}
