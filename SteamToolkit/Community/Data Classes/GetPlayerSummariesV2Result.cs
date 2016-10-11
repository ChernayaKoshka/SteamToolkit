using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    public class PlayerSummary
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }

        [JsonProperty("communityvisibilitystate")]
        public int CommunityVisibilityState { get; set; }

        [JsonProperty("profilestate")]
        public int ProfileState { get; set; }

        [JsonProperty("personaname")]
        public string PersonaName { get; set; }

        [JsonProperty("lastlogoff")]
        public int LastLogoff { get; set; }

        [JsonProperty("commentpermission")]
        public int CommentPermission { get; set; }

        [JsonProperty("profileurl")]
        public string ProfileUrl { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("avatarmedium")]
        public string AvatarMedium { get; set; }

        [JsonProperty("avatarfull")]
        public string AvatarFull { get; set; }

        [JsonProperty("personastate")]
        public int PersonaState { get; set; }

        [JsonProperty("primaryclanid")]
        public string PrimaryClanId { get; set; }

        [JsonProperty("timecreated")]
        public int TimeCreated { get; set; }

        [JsonProperty("personastateflags")]
        public int PersonaStateFlags { get; set; }

        [JsonProperty("realname")]
        public string RealName { get; set; }

        [JsonProperty("loccountrycode")]
        public string LocCountryCode { get; set; }
    }

    [JsonObject(Title = "response")]
    public class Response
    {
        [JsonProperty("players")]
        public List<PlayerSummary> PlayerSummaries { get; set; }
    }

    [JsonObject(Title = "RootObject")]
    public class GetPlayerSummariesV2BaseResult
    {
        public Response Response { get; set; }
    }
}