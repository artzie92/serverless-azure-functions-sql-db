using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Players.Dto.Models;
using Players.Dto.Queries;
using Players.Infrastructure.Database;
using Players.Infrastructure.Domain;

namespace Players.Infrastructure.Handlers
{
    public class GetPlayerScoresQueryHandler
    {
        private readonly PlayersDb db;

        public GetPlayerScoresQueryHandler(PlayersDb db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<PlayerScoreDto>> HandleAsync(GetPlayerScoresQuery query)
        {
            var entities = await db.Set<PlayerScoreEntity>()
                .AsNoTracking()
                .Select(s => new PlayerScoreDto
                {
                    CreatedOn = s.CreatedOn,
                    Login = s.Login,
                    ModifiedOn = s.ModifiedOn,
                    Score = s.Score
                })
                .OrderByDescending(by => by.Score)
                .ToListAsync();

            return entities;
        }
    }
}