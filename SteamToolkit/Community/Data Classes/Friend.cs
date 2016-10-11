using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    public class Friend
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("friend_since")]
        public int FriendSince { get; set; }
    }
}