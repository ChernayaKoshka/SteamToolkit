namespace SteamAuth
{
    public static class APIEndpoints
    {
        public const string SteamToolkit_BASE = "https://api.steampowered.com";
        public const string COMMUNITY_BASE = "https://steamcommunity.com";
        public const string MOBILEAUTH_BASE = SteamToolkit_BASE + "/IMobileAuthService/%s/v0001";
        public static string MOBILEAUTH_GETWGTOKEN = MOBILEAUTH_BASE.Replace("%s", "GetWGToken");
        public const string TWO_FACTOR_BASE = SteamToolkit_BASE + "/ITwoFactorService/%s/v0001";
        public static string TWO_FACTOR_TIME_QUERY = TWO_FACTOR_BASE.Replace("%s", "QueryTime");
    }
}
