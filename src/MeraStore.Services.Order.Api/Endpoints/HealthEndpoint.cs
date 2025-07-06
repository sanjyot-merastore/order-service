using MediatR;

using MeraStore.Services.Order.Application.Features.Health;
using MeraStore.Services.Order.Common;
using MeraStore.Shared.Kernel.WebApi.Interfaces;

namespace MeraStore.Services.Order.Api.Endpoints;

/// <summary>
/// Provides a health check endpoint for the Auth Service.
/// </summary>
public class HealthEndpoint : IEndpoint
{
  /// <summary>
  /// Maps the health check endpoint to the application.
  /// </summary>
  /// <param name="app">The endpoint route builder.</param>
  public void MapEndpoints(IEndpointRouteBuilder app)
  {
    app.MapGet("/health", async (IMediator mediator) =>
      {
        var result = await mediator.Send(new GetHealthQuery());

        return Results.Ok(result);
      })
      .WithName("Health")
      .WithTags("Health")
      .WithSummary("Returns health status of " + KeyStore.ServiceName + ".")
      .WithDescription("This endpoint can be used by monitoring systems or load balancers to verify the Service is running and healthy.")
      .WithOpenApi()
      .AllowAnonymous(); 
  }
}