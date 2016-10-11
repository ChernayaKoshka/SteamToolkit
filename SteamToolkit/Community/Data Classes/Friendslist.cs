using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    public class Friendslist
    {
        [JsonProperty("friends")]
        public List<Friend> Friends { get; set; }
    }
}