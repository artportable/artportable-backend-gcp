﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Artportable.API.Entities;
using Artportable.API.Handlers;
using Artportable.API.Interfaces.Services;
using Artportable.API.Model;
using Artportable.API.Options;
using Artportable.API.Services;
using AutoMapper;
using Azure.Storage.Blobs;
using Mandrill;
using Mandrill.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Services;
using Stripe;
using Swagger;

namespace Artportable.API
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private IConfiguration _configuration { get; }
        private IHostEnvironment _env { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;
            _env = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.PropertyNamingPolicy = null;
                    opts.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    );
                });

            services.AddHttpContextAccessor();

            // secOpts available for use in ConfigureServices
            var blobClientOptions = _configuration
                .GetSection("BlobContainer")
                .Get<BlobContainerClientOptions>();
            var startDeliverOptions = _configuration
                .GetSection("StartDeliver")
                .Get<StartDeliverOptions>();
            var upsalesOptions = _configuration.GetSection("Upsales").Get<UpsalesOptions>();
            services.Configure<MandrillOptions>(_configuration.GetSection("Mandrill"));
            services.Configure<ProductCodes>(_configuration.GetSection("Stripe:Products"));
            services.Configure<StripeOptions>(_configuration.GetSection("Stripe"));
            services.Configure<StreamOptions>(_configuration.GetSection("Stream"));
            services.Configure<StartDeliverOptions>(_configuration.GetSection("StartDeliver"));
            services.Configure<UpsalesOptions>(_configuration.GetSection("Upsales"));

            // Registered services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IStripeService, StripeService>();
            services.AddScoped<IArtworkService, ArtworkService>();
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUploadService, BlobService>();
            services.AddScoped<IDiscoverService, DiscoverService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IStartService, StartService>();
            services.AddScoped<IStartDeliverService, StartDeliverService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddHostedService<TimedHostedService>();
            services.AddHttpClient<IStartDeliverApiService, StartDeliverApiService>(c =>
            {
                c.BaseAddress = new Uri(startDeliverOptions.BaseUrl);
                c.DefaultRequestHeaders.TryAddWithoutValidation(
                    HeaderNames.ContentType,
                    "application/json"
                );
                c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            services.AddTransient<UpsalesMessageHandler>(s => new UpsalesMessageHandler(
                upsalesOptions.ApiKey
            ));
            services
                .AddHttpClient<ICrmService, UpsalesService>(c =>
                {
                    c.BaseAddress = new Uri(upsalesOptions.BaseUrl);
                })
                .AddHttpMessageHandler<UpsalesMessageHandler>();
            services.AddScoped<BlobContainerClient>(factory =>
            {
                return new BlobContainerClient(
                    blobClientOptions.ConnectionString,
                    blobClientOptions.ContainerName
                );
            });
            services.AddSingleton<IActivityService, ActivityService>();

            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                    "MustOwnImage",
                    policyBuilder =>
                    {
                        policyBuilder.RequireAuthenticatedUser();
                    }
                );
            });

            var authSettings = _configuration.GetSection("Auth").Get<Auth>();
            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.Authority = authSettings.Issuer;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authSettings.Issuer,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = authSettings.Audience,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1),
                    };
                    opt.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();

                            c.Response.StatusCode = 401;
                            c.Response.ContentType = "text/plain";

                            if (_env.IsDevelopment())
                            {
                                return c.Response.WriteAsync(c.Exception.ToString());
                            }

                            return c.Response.WriteAsync("Authentication failed.");
                        },
                    };
                    opt.RequireHttpsMetadata = false;
                });

            // Database
            services.AddDbContextPool<APContext>(dbContextOptions =>
                dbContextOptions
                    .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention()
                    // Everything from this point on is optional but helps with debugging.
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            // Stripe
            StripeConfiguration.ApiKey = _configuration.GetValue<string>("Stripe:ApiKey");

            // register AutoMapper-related services
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ArtPortable API",
                        Description = "A backend for ArtPortable",
                    }
                );

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<ImageSwaggerFilter>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });

            services.AddMandrill(options =>
            {
                options.ApiKey = _configuration.GetValue<string>("Mandrill:ApiKey");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Forwarded HTTP headers
            var forwardedHeaderOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders =
                    Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor
                    | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto,
            };
            forwardedHeaderOptions.KnownNetworks.Clear();
            forwardedHeaderOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(forwardedHeaderOptions);

            // Exception handling
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        // ensure generic 500 status code on fault.
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        ;

                        await context.Response.WriteAsync(
                            "An unexpected fault happened. Try again later."
                        );
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArtPortable API");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
