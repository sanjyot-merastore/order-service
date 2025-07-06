﻿using MeraStore.Services.Order.Api;

using Microsoft.AspNetCore.Mvc.Testing;

namespace MeraStore.Services.Order.IntegrationTests.Base;

/// <summary>
/// Base class for integration tests. Provides reusable HttpClient and factory access.
/// </summary>
public abstract class BaseIntegrationTest(WebApplicationFactory<Program> factory)
  : IClassFixture<WebApplicationFactory<Program>>
{
  protected readonly HttpClient Client = factory.CreateClient();
  protected readonly WebApplicationFactory<Program> Factory = factory;
}