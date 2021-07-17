using Microsoft.EntityFrameworkCore;
using Players.Infrastructure.Domain;

namespace Players.Infrastructure.Database
{
    public class PlayersDb : DbContext
    {
        public PlayersDb(DbContextOptions<PlayersDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entity = modelBuilder.Entity<PlayerScoreEntity>();
            entity.ToTable("PlayerScore");
            entity.Property(p => p.Login).HasMaxLength(250).IsRequired();
            entity.HasIndex(i => i.Login);
        }
    }
}