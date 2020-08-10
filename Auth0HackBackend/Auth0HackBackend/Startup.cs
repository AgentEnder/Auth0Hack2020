using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth0HackBackend.Model;
using Auth0HackBackend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Auth0HackBackend.DTO;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Auth0HackBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddConfiguration(configuration)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.secrets.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            IdentityModelEventSource.ShowPII = true;
            //CORS
            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Authentication & Authorization

            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.Audience = Configuration["Auth0:Audience"];
                opts.Authority = Configuration["Auth0:Authority"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("LoggedIn", policy);
            });


            // Misc
            services.AddOData();
            services.AddControllers(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                }
            }).AddNewtonsoftJson(opts => opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Covid OfficeSpace Api",
                    Description = "Covid OfficeSpace Api ASP.NET Core 3.1",
                });

                // Fix for similar class names in diff. places (NS)
                options.CustomSchemaIds(x => x.FullName);

                // Adding to Swagger the Authorize button so that user can enter the Bearer token from Auth0 to get authenticated calls
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"  \r\n\r\n  JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Adding to Swagger the Authorize button so that user can enter the Bearer token from Auth0 to get authenticated calls
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new string[0]
                    }
                });
            });


            // Dependency Injection
            services.AddDbContext<HackEntities>(
                options => options.UseSqlServer(Configuration.GetConnectionString("HackEntities"), 
                x => x.UseNetTopologySuite()
            ));

            services.AddScoped(typeof(OfficesRepository));
            services.AddScoped(typeof(EmployeesRepository));
            services.AddScoped(typeof(WorkRequestsRepository));
            services.AddSingleton(typeof(IConfiguration), Configuration);
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

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Tasks.Api v1 on ASP.NET Core 3.1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("LoggedIn");
                endpoints.Expand().Select().Filter().OrderBy().Count().MaxTop(100);
                endpoints.EnableDependencyInjection();
                //endpoints.MapODataRoute("odata", "odata", GetEdmModel());
                endpoints.MapSwagger();
            });
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<WorkRequestMetadataDTO>("WorkRequests");
            var fnWorkRequests = odataBuilder.Function("RetreiveRequests");
            fnWorkRequests.ReturnsCollectionFromEntitySet<WorkRequestMetadataDTO>("OdataWorkRequests");

            return odataBuilder.GetEdmModel();

        }
    }
}
