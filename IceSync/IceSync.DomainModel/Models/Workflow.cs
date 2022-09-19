using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IceSync.DomainModel
{
    public class Workflow
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int WorkflowId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string WorkflowName { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "isRunning")]
        public bool IsRunning { get; set; }

        [JsonProperty(PropertyName = "multiExecBehavior")]
        public string MultiExecBehaviour { get; set; }
    }
}
