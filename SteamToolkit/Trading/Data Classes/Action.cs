using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    public class Action
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}