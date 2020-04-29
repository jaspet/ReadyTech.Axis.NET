using Newtonsoft.Json;
using System;

namespace ReadyTech.Axis.Service.Models
{
    public class SearchEvent
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("entities")]
        public object[] Entities { get; set; }

        [JsonProperty("subentities")]
        public bool SubEntities { get; set; }

        [JsonProperty("template")]
        public Guid Template { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("leaders")]
        public Owner[] Leaders { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; } = null;

        [JsonProperty("endDate")]
        public string EndDate { get; set; } = null;

        [JsonProperty("providerRegion")]
        public ProviderRegion ProviderRegion { get; set; }
    }
}
