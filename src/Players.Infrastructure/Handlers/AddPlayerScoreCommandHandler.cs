using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Players.Dto;
using Players.Dto.Commands;
using Players.Infrastructure.Database;
using Players.Infrastructure.Domain;

namespace Players.Infrastructure.Handlers
{
    public class AddPlayerScoreCommandHandler
    {
        private readonly PlayersDb db;

        public AddPlayerScoreCommandHandler(PlayersDb db)
        {
            this.db = db;
        }

        public async Task<int> HandleAsync(AddPlayerScoreCommand command)
        {
            var entity = await db.Set<PlayerScoreEntity>().AsQueryable()
                .FirstOrDefaultAsync(w => w.Login == command.Login);

            if (entity == null)
            {
                entity = PlayerScoreEntity.Create(
                    login: command.Login,
                    score: command.Score
                );
                db.Set<PlayerScoreEntity>().Add(entity);
            }
            else
            {
                if (command.Score > entity.Score)
                {
                    entity.Update(command.Score);
                }
            }

            await db.SaveChangesAsync();
            return entity.Id;
        }
    }
}