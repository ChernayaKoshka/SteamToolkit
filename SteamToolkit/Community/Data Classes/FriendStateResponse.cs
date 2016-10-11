﻿using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class FriendStateResponse
    {
        [JsonProperty("m_unAccountID")]
        public int AccountId { get; set; }

        [JsonProperty("m_ulSteamID")]
        public string SteamId { get; set; }

        [JsonProperty("m_strName")]
        public string Name { get; set; }

        [JsonProperty("m_ePersonaState")]
        public EPersonaState PersonaState { get; set; }

        [JsonProperty("m_nPersonaStateFlags")]
        public object PersonaStateFlags { get; set; }

        [JsonProperty("m_strAvatarHash")]
        public string AvatarHash { get; set; }

        [JsonProperty("m_tsLastMessage")]
        public int LastMessage { get; set; }

        [JsonProperty("m_tsLastView")]
        public int LastView { get; set; }

        [JsonProperty("m_bInGame")]
        public bool InGame { get; set; }

        [JsonProperty("m_nInGameAppID")]
        public string InGameAppId { get; set; }

        [JsonProperty("m_strInGameName")]
        public string InGameName { get; set; }
    }

}
