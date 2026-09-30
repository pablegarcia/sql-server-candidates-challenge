using System.ComponentModel.DataAnnotations;

namespace SyncAgent.Infrastructure.Options
{
    public class PlatformOptions
    {
        public const string SectionName = "Platform";

        [Required, Url]
        public string BaseUrl { get; init; } = string.Empty;

        [Required, MinLength(8)]
        public string ApiKey { get; init; } = string.Empty;

        [Range(1, 3600)]
        public int PollingIntervalSeconds { get; init; } = 5;

        [Range(1, 300)]
        public int RequestTimeoutSeconds { get; init; } = 30;

        [Range(1, 3600)]
        public int MaxBackoffSeconds { get; init; } = 60;
    }
}