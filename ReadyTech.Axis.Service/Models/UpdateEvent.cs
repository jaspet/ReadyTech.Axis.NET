using Newtonsoft.Json;
using System;

namespace ReadyTech.Axis.Service.Models
{
    public class UpdateEvent
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("providerRegion")]
        public ProviderRegion ProviderRegion { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("schedule")]
        public Schedule[] Schedule { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("template")]
        public Guid Template { get; set; }
    }
}
