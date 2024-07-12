using Application.Attributes.Services;
using Application.Contracts.Services.ExternalApiServices;
using Application.Models.ExternalApi.Common;
using Application.Statics.Enums;
using Application.Statics.Externals;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services.ExternalApiServices
{
    [RegisterExternalService(ServiceLifetime.Scoped)]
    public class PokemonService(IHttpClientFactory httpClientFactory)
        : BaseApiService(httpClientFactory), IPokemonService
    {
        public async Task<T?> GetPokemonByName<T>(string name, string? accessToken = null)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiRequestType = ApiRequestType.Get,
                Url = $"{ExternalApiUrl.PokemonApiUrl}/{name}",
                AccessToken = accessToken
            });
        }
    }
}
