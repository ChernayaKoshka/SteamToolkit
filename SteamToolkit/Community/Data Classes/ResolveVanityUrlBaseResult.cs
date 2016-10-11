using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class ResolveVanityUrlBaseResult
    {
        [JsonProperty("response")]
        public ResolveVanityUrlResult Response { get; set; }
    }
}