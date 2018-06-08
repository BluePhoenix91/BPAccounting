using BPAccounting.Core;
using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BPAccounting.Relational
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction UseServerDataStore(this FrameworkConstruction construction)
        {
            // Inject our SQLite EF data store
            construction.Services.AddDbContext<ServerDataStoreDbContext>(options =>
            {
                // Setup connection string
                options.UseSqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection"));
            });

            // Add client data store for easy access/use of the backing data store
            // Make it scoped so we can inject the scoped DbContext
            construction.Services.AddScoped<IServerDataStore>(
                provider => new ServerDataStore(provider.GetService<ServerDataStoreDbContext>()));

            // Return framework for chaining
            return construction;
        }
    }
}
