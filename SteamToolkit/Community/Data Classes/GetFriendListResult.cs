using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class GetFriendListResult
    {
        [JsonProperty("friendslist")]
        public Friendslist Friendslist { get; set; }
    }
}