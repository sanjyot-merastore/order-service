using MeraStore.Services.Order.Application;
using MeraStore.Services.Order.Persistence;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeraStore.Services.Order.Infrastructure;

public static class ServiceRegistrations
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {

    services.AddApplicationServices(configuration);
    services.AddPersistenceServices(configuration);
    return services;
  }
}