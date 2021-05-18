using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Artportable.API.Entities;
using Artportable.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Stripe;
using System.Text.Json.Serialization;
using System.Text.Json;
using Swagger;

namespace Artportable.API
{
  public class Startup
  {
    private IConfiguration _configuration { get; }

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers()
        .AddJsonOptions(opts =>
        {
          opts.JsonSerializerOptions.PropertyNamingPolicy = null;
          opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });

      services.AddHttpContextAccessor();

      // Registered services
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IPaymentService, PaymentService>();
      services.AddScoped<IStripeService, StripeService>();
      services.AddScoped<IArtworkService, ArtworkService>();
      services.AddScoped<IFeedService, FeedService>();
      services.AddScoped<IConnectionService, ConnectionService>();
      services.AddScoped<IImageService, ImageService>();
      services.AddScoped<IAwsS3Service, AwsS3Service>();
      services.AddScoped<IDiscoverService, DiscoverService>();
      services.AddScoped<IStartService, StartService>();

      services.AddAuthorization(authorizationOptions =>
      {
        authorizationOptions.AddPolicy(
          "MustOwnImage",
          policyBuilder =>
          {
            policyBuilder.RequireAuthenticatedUser();
          });
      });

      services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
        .AddIdentityServerAuthentication(options =>
        {
          options.Authority = "https://artportable.idp.com:44395/";
          options.ApiName = "Artportableapi";
          options.RequireHttpsMetadata = false;
          options.ApiSecret = "apisecret";
        });

      // Database
      services.AddDbContextPool<APContext>(
        dbContextOptions => dbContextOptions
          .UseMySql(
            _configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21)),
            mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
          )
          .UseSnakeCaseNamingConvention()
          // Everything from this point on is optional but helps with debugging.
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors()
      );

      // Stripe
      // This is a sample test API key
      StripeConfiguration.ApiKey = "sk_test_51IRGljA3UXZjjLWxv4sO6lHEF0mNBqAfXWn9wpsWgOK3bS2zy2UYglHeMe6P3IZ2SSGKcrMxYrrftyVq4xwi6MZJ00mOgmNvxW";


      // register AutoMapper-related services
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      // Swagger
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "ArtPortable API",
          Description = "A backend for ArtPortable",
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
        c.OperationFilter<ImageSwaggerFilter>();
      });

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
          builder =>
          {
            builder.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
          }
        );
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // Forwarded HTTP headers
      var forwardedHeaderOptions = new ForwardedHeadersOptions
      {
        ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
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
            context.Response.StatusCode = StatusCodes.Status500InternalServerError; ;
            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
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

      app.UseCors();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
