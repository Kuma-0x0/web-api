using System;
using System.Text.Json.Serialization;

namespace WebAPI.Functions.Models
{
    public class User
    {
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyOrder(1)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("birthDay")]
        public DateTime BirthDay { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
