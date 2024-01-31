using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Commons.Mapping;

public class AutheticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}