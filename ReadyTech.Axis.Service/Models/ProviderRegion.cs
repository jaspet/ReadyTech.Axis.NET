using Newtonsoft.Json;
using System;

namespace ReadyTech.Axis.Service.Models
{
    public partial class ProviderRegion
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
