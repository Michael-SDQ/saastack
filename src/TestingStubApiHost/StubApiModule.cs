#if TESTINGONLY
using System.Reflection;
using Infrastructure.Web.Hosting.Common;
using TestingStubApiHost.Api;

namespace TestingStubApiHost;

public class StubApiModule : ISubDomainModule
{
    public Assembly ApiAssembly => typeof(StubHelloApi).Assembly;

    public Assembly DomainAssembly => typeof(StubHelloApi).Assembly;

    public Dictionary<Type, string> AggregatePrefixes => new();

    public Action<ConfigurationManager, IServiceCollection> RegisterServices
    {
        get
        {
            return (configuration, services) =>
            {
                services.AddLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddConfiguration(configuration.GetSection("Logging"));
                    builder.AddSimpleConsole(options =>
                    {
                        options.TimestampFormat = "hh:mm:ss ";
                        options.SingleLine = true;
                        options.IncludeScopes = false;
                    });
                    builder.AddDebug();
                    builder.AddEventSourceLogger();
                });
            };
        }
    }

    public Action<WebApplication> ConfigureMiddleware
    {
        get { return app => app.RegisterRoutes(); }
    }
}
#endif