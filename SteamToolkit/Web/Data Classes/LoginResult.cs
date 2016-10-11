﻿using Newtonsoft.Json;

namespace SteamToolkit.Web
{
    [JsonObject(Title = "RootObject")]
    public class LoginResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("requires_twofactor")]
        public bool RequiresTwofactor { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("captcha_needed")]
        public bool CaptchaNeeded { get; set; }
        [JsonProperty("captcha_gid")]
        public string CaptchaGid { get; set; }
        [JsonProperty("emailauth_needed")]
        public bool EmailAuthNeeded { get; set; }
        [JsonProperty("emaildomain")]
        public string EmailDomain { get; set; }
        [JsonProperty("emailsteamid")]
        public string EmailSteamId { get; set; }
        [JsonProperty("login_complete")]
        public bool LoginComplete { get; set; }
        [JsonProperty("transfer_url")]
        public string TransferUrl { get; set; }
        [JsonProperty("transfer_parameters")]
        public TransferParameters TransferParameters { get; set; }
    }
}
