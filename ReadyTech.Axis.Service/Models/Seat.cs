using Newtonsoft.Json;
using System;

namespace ReadyTech.Axis.Service.Models
{
    public class Seat
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; } = string.Empty;

        [JsonProperty("seatId")]
        public long SeatId { get; set; }

        [JsonProperty("accessCode")]
        public string AccessCode { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("assignedFirstName")]
        public string AssignedFirstName { get; set; }

        [JsonProperty("assignedLastName")]
        public string AssignedLastName { get; set; }

        [JsonProperty("assignedEmail")]
        public string AssignedEmail { get; set; }

        [JsonProperty("activatedTs")]
        public string ActivatedTs { get; set; }

        [JsonProperty("activatedFirstName")]
        public string ActivatedFirstName { get; set; }

        [JsonProperty("activatedLastName")]
        public string ActivatedLastName { get; set; }

        [JsonProperty("seatUrl")]
        public Uri SeatUrl { get; set; }

        [JsonProperty("notified")]
        public bool Notified { get; set; }
    }
}
