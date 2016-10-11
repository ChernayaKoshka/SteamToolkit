using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    [JsonObject(Title = "RootObject")]
    public class GetUserGroupListBaseResult
    {
        public GetUserGroupListResult Result { get; set; }
    }
}