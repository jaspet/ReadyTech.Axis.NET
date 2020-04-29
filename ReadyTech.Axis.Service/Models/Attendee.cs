using Newtonsoft.Json;

namespace ReadyTech.Axis.Service.Models
{
    public class Attendee
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
