using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPI.Functions.Functions.Orchestrator;
using WebAPI.Functions.Models;

namespace WebAPI.Functions.Functions.Client
{
    public class RegisterUserClient
    {
        private readonly ILogger _logger;

        public RegisterUserClient(ILogger<RegisterUserClient> logger)
        {
            _logger = logger;
        }

        [FunctionName(nameof(RunRegisterUserClient))]
        public async Task<HttpResponseMessage> RunRegisterUserClient(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestMessage request,
            [DurableClient] IDurableOrchestrationClient starter)
        {
            var content = await request.Content.ReadFromJsonAsync<User>();
            var instanceId = await starter.StartNewAsync(nameof(RegisterUserOrchestrator.RunRegisterUserOrchestrator), null, content);

            _logger.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(request, instanceId);
        }
    }
}
