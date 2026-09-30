using Microsoft.Extensions.DependencyInjection;

using SyncAgent.Core.Abstractions;
using SyncAgent.Core.Dispatching;
using SyncAgent.Core.Validation;

namespace SyncAgent.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSyncAgent(this IServiceCollection services)
        {
            services.AddSingleton(TimeProvider.System);
            services.AddSingleton<ISyncTaskValidator, SyncTaskValidator>();

            return services;
        }
    }
}