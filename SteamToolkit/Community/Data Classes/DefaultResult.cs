using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class DefaultResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
