using System.Net;
using ApiHost1;
using Domain.Interfaces;
using FluentAssertions;
using Infrastructure.Web.Api.Common.Extensions;
using Infrastructure.Web.Api.Operations.Shared.Identities;
using Infrastructure.Web.Api.Operations.Shared.TestingOnly;
using IntegrationTesting.WebApi.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IdentityInfrastructure.IntegrationTests;

[Trait("Category", "Integration.Web")]
[Collection("API")]
public class MachineCredentialsApiSpec : WebApiSpec<Program>
{
    public MachineCredentialsApiSpec(WebApiSetup<Program> setup) : base(setup, OverrideDependencies)
    {
        EmptyAllRepositories(setup);
    }

    [Fact]
    public async Task WhenRegisterMachineByAnonymous_ThenRegisters()
    {
        var result = await Api.PostAsync(new RegisterMachineRequest
        {
            Name = "amachinename"
        });

        result.Content.Value.Machine!.Id.Should().NotBeEmpty();
        result.Content.Value.Machine.Description.Should().Be("amachinename");
        result.Content.Value.Machine.ApiKey.Should().StartWith("apk_");
        result.Content.Value.Machine.CreatedById.Should().Be(CallerConstants.AnonymousUserId);
        result.Content.Value.Machine.ExpiresOnUtc.Should().BeNull();
    }

    [Fact]
    public async Task WhenRegisterMachineByUser_ThenRegisters()
    {
        var user = await LoginUserAsync();

        var result = await Api.PostAsync(new RegisterMachineRequest
        {
            Name = "amachinename"
        }, req => req.SetJWTBearerToken(user.AccessToken));

        result.Content.Value.Machine!.Id.Should().NotBeEmpty();
        result.Content.Value.Machine.Description.Should().Be("amachinename");
        result.Content.Value.Machine.ApiKey.Should().StartWith("apk_");
        result.Content.Value.Machine.CreatedById.Should().Be(user.User.Id);
        result.Content.Value.Machine.ExpiresOnUtc.Should().BeNull();
    }

    [Fact]
    public async Task WhenCallingSecureApiWithMachineApiKey_ThenReturnsResponse()
    {
        var machine = await Api.PostAsync(new RegisterMachineRequest
        {
            Name = "amachinename"
        });

#if TESTINGONLY
        var apiKey = machine.Content.Value.Machine!.ApiKey;
        var result = await Api.GetAsync(new GetCallerWithTokenOrAPIKeyTestingOnlyRequest(),
            req => req.SetAPIKey(apiKey));

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Content.Value.CallerId.Should().Be(machine.Content.Value.Machine.Id);
#endif
    }

    private static void OverrideDependencies(IServiceCollection services)
    {
    }
}