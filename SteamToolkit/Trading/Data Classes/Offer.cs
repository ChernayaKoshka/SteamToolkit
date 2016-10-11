using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    public class Offer //ToDo: NEEDS a better name
    {
        [JsonProperty("assets")]
        public List<CEconAsset> Assets { get; set; } = new List<CEconAsset>();

        [JsonProperty("currency")]
        public List<object> Currency { get; } = new List<object>();

        [JsonProperty("ready")]
        public bool Ready { get; } = false;
    }
}