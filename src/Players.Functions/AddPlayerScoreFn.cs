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
using Players.Dto.Commands;
using Players.Infrastructure.Handlers;

namespace Players.Functions
{
    public class AddPlayerScoreFn
    {
        private readonly PlayersDb db;

        public AddPlayerScoreFn(PlayersDb db)
        {
            this.db = db;
        }
        [FunctionName("AddPlayerScoreFn")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var command = JsonConvert.DeserializeObject<AddPlayerScoreCommand>(requestBody);
            var handler = new AddPlayerScoreCommandHandler(db);
            var id = await handler.HandleAsync(command);
            return new OkResult();
        }
    }
}
