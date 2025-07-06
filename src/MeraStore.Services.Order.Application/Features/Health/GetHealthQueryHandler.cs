﻿using MediatR;

using MeraStore.Services.Order.Common;

namespace MeraStore.Services.Order.Application.Features.Health;

public class GetHealthQueryHandler : IRequestHandler<GetHealthQuery, HealthResponse>
{
  public Task<HealthResponse> Handle(GetHealthQuery request, CancellationToken cancellationToken)
  {
    var response = new HealthResponse
    {
      Status = "Healthy",
      Service = KeyStore.ServiceName,
      Timestamp = DateTime.UtcNow
    };

    return Task.FromResult(response);
  }
}