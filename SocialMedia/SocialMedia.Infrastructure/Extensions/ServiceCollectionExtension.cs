using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Options;
using SocialMedia.Core.Services;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Interfaces;
using SocialMedia.Infrastructure.Options;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialMediaContext>(options => //
            {
                options.UseSqlServer(configuration.GetConnectionString("SocialMediaDb"));
                //options.UseSqlServer(Configuration.GetConnectionString("SocialMediaDbIIS"));
            });

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //Microsoft.Extensions.Options.ConfigurationExtensions, Version=3.1.0.0,
            //services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            //services.Configure<PasswordOptions>(configuration.GetSection(nameof(PasswordOptions).ToString()));

            //Microsoft.Extensions.Options.ConfigurationExtensions, Version = 3.1.0.0, y superior(3.1.4.0)
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection(nameof(PasswordOptions).ToString()).Bind(options));


            //Idea mia aplicar patron UnitOfWork, objetivo evitar las dependecias (Microsoft.Extensions.Options) en el core
            services.AddSingleton<IAppSettings, AppSettings>();

            return services;
        }

        public static IServiceCollection AddOptionsOtherWait(this IServiceCollection services, IConfiguration configuration)
        {
            //Esta es otra forma que encontre en internet
            var name = nameof(TestConfigOptions).ToString();
            var section = configuration.GetSection(name);
            var testConfigOptions = section.Get<TestConfigOptions>();
            services.AddSingleton(testConfigOptions);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>(); //
            services.AddTransient<ISecurityService, SecurityService>(); //
            services.AddTransient<IPasswordService, PasswordService>(); //
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); //
            services.AddTransient<IUnitOfWork, UnitOfWork>(); //
            services.AddSingleton<IUriService>(provider => {
                //using Microsoft.AspNetCore.Http; -> IHttpContextAccessor
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string  xmlFileName)
        {
            //Los puse con el using para saber a cual pertenecn cada uno.
            services.AddSwaggerGen(doc => {
                doc.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "social Media Api", Version = "v1" });                
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
