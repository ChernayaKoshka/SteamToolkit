﻿using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class AddFriendResponse
    {
        [JsonProperty("invited")]
        public string[] Invited { get; set; }
        [JsonProperty("success")]
        public int Success { get; set; }
    }

}
