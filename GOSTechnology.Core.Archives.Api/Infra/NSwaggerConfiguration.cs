using GOSTechnology.Core.Archives.Domain.Configurations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema.Generation;
using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;

namespace GOSTechnology.Core.Archives.Api.Infra
{
    /// <summary>
    /// NSwaggerConfiguration.
    /// </summary>
    public static class NSwaggerConfiguration
    {
        /// <summary>
        /// AddNSwagger.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddNSwagger(this IServiceCollection builder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(ConstantsConfiguration.APP_SETTINGS, optional: false, reloadOnChange: true).Build();

            builder
            .AddApiVersioning(builder =>
            {
                builder.AssumeDefaultVersionWhenUnspecified = true;
                builder.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddVersionedApiExplorer(builder =>
            {
                builder.GroupNameFormat = ConstantsConfiguration.GROUP_NAME_FORMAT;
                builder.SubstituteApiVersionInUrl = true;
            })
            .AddSwaggerDocument(builder =>
            {
                builder.DocumentName = ConstantsConfiguration.DOCUMENT_NAME;
                builder.ApiGroupNames = new[] { "1" };
                builder.DefaultDictionaryValueReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                builder.PostProcess = x =>
                {
                    x.Info.Title = ConstantsConfiguration.API_NAME;
                    x.Info.Description = ConstantsConfiguration.API_VERSION;
                };

                AddSecurity(builder, configuration);
            });

            return builder;
        }

        /// <summary>
        /// AddSecurity.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="configuration"></param>
        private static void AddSecurity(AspNetCoreOpenApiDocumentGeneratorSettings document, IConfigurationRoot configuration)
        {
            var scope = new Dictionary<string, string>
            {
                { configuration[ConstantsConfiguration.KEY_HANDLER], configuration[ConstantsConfiguration.KEY_VALUE] }
            };
            var globalScopeNames = new List<string>
            {
                configuration[ConstantsConfiguration.KEY_HANDLER]
            };

            document.DocumentProcessors.Add(new SecurityDefinitionAppender(configuration[ConstantsConfiguration.KEY_HANDLER], new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = configuration[ConstantsConfiguration.KEY_HANDLER],
                Description = configuration[ConstantsConfiguration.KEY_VALUE],
                In = OpenApiSecurityApiKeyLocation.Header,
                Scopes = scope
            }));

            document.AddSecurity(configuration[ConstantsConfiguration.KEY_HANDLER], globalScopeNames, new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = configuration[ConstantsConfiguration.KEY_HANDLER],
                Description = configuration[ConstantsConfiguration.KEY_VALUE],
                In = OpenApiSecurityApiKeyLocation.Header,
                Scopes = scope
            });
        }

        //public static IServiceCollection AddApiKeyAuthentication(this IServiceCollection builder)
        //{
        //    builder.AddAuthentication("ApiKeyAuthenticationHandler")
        //           .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthenticationHandler", null);

        //    return builder;
        //}
    }
}
