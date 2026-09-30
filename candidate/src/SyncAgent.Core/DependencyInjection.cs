using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using SyncAgent.Core.Abstractions;
using SyncAgent.Core.Platform;
using SyncAgent.Core.Validation;
using SyncAgent.Infrastructure.Options;

namespace SyncAgent.Core
{
    public static class DependencyInjection
    {
        private const long MaxResponseBytes = 1 * 1024 * 1024;

        public static IServiceCollection AddSyncAgent(this IServiceCollection services)
        {
            services.AddSingleton(TimeProvider.System);
            services.AddSingleton<ISyncTaskValidator, SyncTaskValidator>();

            services.AddTransient<ApiKeyHandler>();
            services.AddHttpClient<IPlatformClient, PlatformClient>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<PlatformOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(options.RequestTimeoutSeconds);
                client.MaxResponseContentBufferSize = MaxResponseBytes;
            }).ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan)
            .AddHttpMessageHandler<ApiKeyHandler>();

            return services;
        }
    }
}