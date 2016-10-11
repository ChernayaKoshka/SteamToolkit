using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class ChatLogoffResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
