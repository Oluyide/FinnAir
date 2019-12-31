using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinnAir.DataLayer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using FinnAir.Api.Options;
using Swashbuckle.AspNetCore.Swagger;
using SwaggerOptions = FinnAir.Api.Options.SwaggerOptions;
using FinnAir.BusinessLogic.Interfaces;
using FinnAir.BusinessLogic.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;

namespace FinnAir.Api
{
    public class Startup
    {
        private readonly string _apiVersion;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _apiVersion = $"v{Assembly.GetEntryAssembly().GetName().Version}";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
         {
            var jwtSettings = new JwtSettings();

            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FinnAirContext>(options => options.UseNpgsql(connectionString));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<FinnAirContext>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IFlightDetailsService, FlightDetailsService>();
            

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(_apiVersion, new Info { Title = "FinnAir API", Version = _apiVersion });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new String[0] }
                };

                x.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description ="JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = "header",
                    Type= "apiKey"
                });
                x.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FinnAirContext context, IOptions<WebServerUrl> webServerSettings, ILoggerFactory loggerFactory, UserManager<IdentityUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            //var swaggerOptions = new SwaggerOptions();
            //Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger();
            //app.UseSwaggerUI(option => {
            //    option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            //});
            var virtualDir = "";
            if (!env.IsDevelopment())
            {
                var webServerUrl = webServerSettings.Value;
                virtualDir = webServerUrl.AppVirtualDir;
            }

            app.UseSwaggerUI(option =>
            {
                option.DocumentTitle = $"FinnAir API ({_apiVersion}) documentation";
                option.SwaggerEndpoint(virtualDir + $"/swagger/{_apiVersion}/swagger.json", $"FinnAir API ({_apiVersion})");
            });

            DbSeeder.SeedDb(userManager);
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
            app.UseMvc();
        }
    }
}
