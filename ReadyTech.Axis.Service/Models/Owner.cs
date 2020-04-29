using Newtonsoft.Json;
using System;

namespace ReadyTech.Axis.Service.Models
{
    public class Owner
    {
        [JsonProperty("uuid")]
        public Guid? Uuid { get; set; }

        [JsonProperty("externalId")]
        public object ExternalId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("seatUuid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? SeatUuid { get; set; }
    }
}
