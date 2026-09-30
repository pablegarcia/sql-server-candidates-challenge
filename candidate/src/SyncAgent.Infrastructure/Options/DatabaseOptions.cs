using System.ComponentModel.DataAnnotations;

namespace SyncAgent.Infrastructure.Options
{
    public class DatabaseOptions
    {
        public const string ConnectionStringName = "AdventureWorks";

        [Required(ErrorMessage = "Missing connection string 'ConnectionStrings:AdventureWorks'. " +
                                 "Set it with dotnet user-secrets or the ConnectionStrings__AdventureWorks environment variable.")]
        public string ConnectionString { get; set; } = string.Empty;
    }
}