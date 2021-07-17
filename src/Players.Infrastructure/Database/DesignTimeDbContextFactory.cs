using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Players.Infrastructure.Database
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PlayersDb>
    {
        public PlayersDb CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PlayersDb>();
            var connectionString = configuration.GetConnectionString("PlayersDb");
            builder.UseSqlServer(connectionString);
            return new PlayersDb(builder.Options);
        }
    }
}