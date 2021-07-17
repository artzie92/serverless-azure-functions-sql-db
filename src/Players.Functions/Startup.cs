using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Players.Infrastructure.Database;

[assembly: FunctionsStartup(typeof(Players.Functions.Startup))]

namespace Players.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<PlayersDb>(options =>
            {
                var connectionString = System.Environment.GetEnvironmentVariable("PlayersDb");
                options.UseSqlServer(connectionString);
            });
        }
    }
}