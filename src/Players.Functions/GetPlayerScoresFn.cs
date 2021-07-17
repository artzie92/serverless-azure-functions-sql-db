using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Players.Infrastructure.Database;
using Players.Infrastructure.Handlers;
using Players.Dto.Queries;

namespace Players.Functions
{
    public class GetPlayerScoresFn
    {
        private readonly PlayersDb db;

        public GetPlayerScoresFn(PlayersDb db)
        {
            this.db = db;
        }

        [FunctionName("GetPlayerScoresFn")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var query = new GetPlayerScoresQuery();
            var handler = new GetPlayerScoresQueryHandler(db);
            var result = await handler.HandleAsync(query);
            return new OkObjectResult(result);
        }
    }
}
