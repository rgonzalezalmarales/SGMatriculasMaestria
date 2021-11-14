#region OLD
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using SocialMedia.Core.Interfaces;
//using SocialMedia.Infrastructure.Data;
//using SocialMedia.Infrastructure.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
#endregion
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Services;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Filters;
using SocialMedia.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SocialMedia.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var ksCultureInfo = new CultureInfo("sq");
            //    var enCultureInfo = new CultureInfo("en");
            //    var srCultureInfo = new CultureInfo("sr");

            //    ksCultureInfo.NumberFormat.NumberDecimalSeparator = ".";

            //    var supportedCultures = new[]
            //    {
            //        ksCultureInfo,
            //        enCultureInfo,
            //        srCultureInfo
            //    };

            //    options.DefaultRequestCulture = new RequestCulture(culture: enCultureInfo, uiCulture: ksCultureInfo);
            //    options.SupportedCultures = supportedCultures;
            //    options.SupportedUICultures = supportedCultures;
            //    options.RequestCultureProviders = new List<IRequestCultureProvider>
            //    {
            //        new QueryStringRequestCultureProvider(),
            //        new CookieRequestCultureProvider()
            //    };
            //});


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                .AddNewtonsoftJson(options => //
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .ConfigureApiBehaviorOptions(options => {
                    //options.SuppressModelStateInvalidFilter = true; // Suspemder la validacion con [ApiController]
                });

            services.AddDbContext<SocialMediaContext>(options => //
            {
                options.UseSqlServer(Configuration.GetConnectionString("SocialMediaDb"));
            });
            //services.AddTransient<IPostRepository, ExampleRepository>(); //
            services.AddTransient<IPostRepository, PostRepository>(); //
            services.AddTransient<IPostService, PostService>(); //
            services.AddTransient<IUserRepository, UserRepository>(); //

            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //services.AddLocalization(o => {
            //    var a = o.GetType();
            //});

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
