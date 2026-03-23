using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sophia.Domain.Lily;
using Sophia.Infrastructure.Lily;
using Sophia.Infrastructure.Lily.Generated;

namespace Sophia.Infrastructure;

public static class ClientExtensions
{
    public static void AddClients(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpClient<ILilyGeneratedClient, LilyGeneratedClient>(client =>
        {
            client.BaseAddress = new Uri(config["Lily:BaseUrl"]!);
        });

        services.AddScoped<ILilyClient, LilyClientAdapter>();
    }
}
