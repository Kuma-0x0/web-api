using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WebAPI.Functions.Models;

namespace WebAPI.Functions.Functions.Activity
{
    internal class RegisterUserActivity
    {
        private readonly ILogger _logger;

        public RegisterUserActivity(ILogger<RegisterUserActivity> logger)
        {
            _logger = logger;
        }

        [FunctionName(nameof(RunRegisterUserActivity))]
        public User RunRegisterUserActivity([ActivityTrigger] User user)
        {
            _logger.LogInformation($"Input = '{JsonSerializer.Serialize(user)}'");
            return user;
        }
    }
}
