using MeraStore.Services.Order.Api.Middlewares.Extensions;
using MeraStore.Services.Order.Common;
using MeraStore.Services.Order.Infrastructure;
using MeraStore.Shared.Kernel.WebApi;
using MeraStore.Shared.Kernel.WebApi.Extensions;

namespace MeraStore.Services.Order.Api;

/// <summary>
/// 
/// </summary>
public class Program
{
  public static void Main(string[] args)
  {
    var builder = CreateWebApplicationBuilder(args);
    var app = BuildWebApplication(builder);
    app.Run();
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="args"></param>
  /// <returns></returns>
  public static WebApplicationBuilder CreateWebApplicationBuilder(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddAuthorization();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddOpenApi();

    builder.AddApiServices(KeyStore.ServiceName, defaultLogging: true);
    builder.Services.AddInfrastructureServices(builder.Configuration);

    return builder;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="builder"></param>
  /// <returns></returns>
  public static WebApplication BuildWebApplication(WebApplicationBuilder builder)
  {
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseMeraStoreTracing();
    app.UseMeraStoreErrorHandling();
    app.UseCustomSwagger(KeyStore.ServiceName);
    app.UseMeraStoreLogging();
    app.UseHttpsRedirection();

    app.MapEndpoints();
    app.MapControllers();

    return app;
  }
}