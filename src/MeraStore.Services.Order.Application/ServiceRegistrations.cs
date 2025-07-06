using MediatR;
using MeraStore.Services.Order.Application.Behaviours;
using MeraStore.Services.Order.Application.Features.Health;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeraStore.Services.Order.Application;

public static class ServiceRegistrations
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
  {

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetHealthQuery).Assembly));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    return services;
  }
}