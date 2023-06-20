using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SpawnConverter;

public class OriginalSpawn
{
    public Spawns spawns { get; set; }
    
    public class Spawn
    {
        [JsonProperty("centerx")]
        public string centerx { get; set; }

        [JsonProperty("centery")]
        public string centery { get; set; }

        [JsonProperty("centerz")]
        public string centerz { get; set; }

        [JsonProperty("radius")]
        public string radius { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object monster { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object npc { get; set; }
    }

    public class Spawns
    {
        public List<Spawn> spawn { get; set; }
    }
}

