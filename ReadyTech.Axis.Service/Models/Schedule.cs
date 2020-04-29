using Newtonsoft.Json;

namespace ReadyTech.Axis.Service.Models
{
    public class Schedule
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }
    }
}
