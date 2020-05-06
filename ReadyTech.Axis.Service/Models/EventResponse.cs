using Newtonsoft.Json;
using System;

namespace ReadyTech.Axis.Service.Models
{
    public class EventResponse
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("template")]
        public Guid Template { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("providerRegion")]
        public ProviderRegion ProviderRegion { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("leaders")]
        public Owner[] Leaders { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("schedule")]
        public Schedule[] Schedule { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("seatCount")]
        public long SeatCount { get; set; }

        [JsonProperty("ondemandMinutes")]
        public long OndemandMinutes { get; set; }

        [JsonProperty("ondemandAccessType")]
        public string OndemandAccessType { get; set; }

        [JsonProperty("seats")]
        public Seat[] Seats { get; set; }
    }
}
