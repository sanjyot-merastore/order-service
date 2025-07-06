using MeraStore.Services.Order.Application;
using MeraStore.Services.Order.Common;
using MeraStore.Services.Order.Common.Filters;
using MeraStore.Services.Order.Domain.Entities;

using System.Reflection;

namespace MeraStore.Services.OrderArchitectureTests;

public class BaseTests
{
  protected static readonly Assembly DomainAssembly = typeof(SampleEntity).Assembly;
  protected static readonly Assembly CommonAssembly = typeof(KeyStore).Assembly;
  protected static readonly Assembly ApplicationAssembly = typeof(ServiceRegistrations).Assembly;
  protected static readonly Assembly InfrastructureAssembly = typeof(MeraStore.Services.Order.Infrastructure.ServiceRegistrations).Assembly;
  protected static readonly Assembly PersistenceAssembly = typeof(MeraStore.Services.Order.Persistence.ServiceRegistrations).Assembly;
  protected static readonly Assembly ApiAssembly = typeof(MaskingFilterFactory).Assembly;


  protected static readonly string? DomainAssemblyName = "MeraStore.Services.Order.Domain";
  protected static readonly string? CommonAssemblyName = CommonAssembly.GetName().Name;
  protected static readonly string? ApplicationAssemblyName = "MeraStore.Services.Order.Application";
  protected static readonly string? InfrastructureAssemblyName = InfrastructureAssembly.GetName().Name;
  protected static readonly string? PersistenceAssemblyName = PersistenceAssembly.GetName().Name;
  protected static readonly string? ApiAssemblyName = ApiAssembly.GetName().Name;
}