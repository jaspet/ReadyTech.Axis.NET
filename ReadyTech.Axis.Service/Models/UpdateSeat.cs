using Newtonsoft.Json;

namespace ReadyTech.Axis.Service.Models
{
    public class UpdateSeat
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }
    }
}
