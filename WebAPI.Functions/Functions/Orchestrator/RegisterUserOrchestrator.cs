using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;
using WebAPI.Functions.Functions.Activity;
using WebAPI.Functions.Models;

namespace WebAPI.Functions.Functions.Orchestrator
{
    public class RegisterUserOrchestrator
    {
        [FunctionName(nameof(RunRegisterUserOrchestrator))]
        public async Task<User> RunRegisterUserOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var input = context.GetInput<User>();
            var output =  await context.CallActivityAsync<User>(nameof(RegisterUserActivity.RunRegisterUserActivity), input);
            return output;
        }
    }
}
