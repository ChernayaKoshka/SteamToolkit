using Newtonsoft.Json;

namespace SteamToolkit.Community
{
    public class Group
    {
        [JsonProperty("gid")]
        public ulong GroupId { get; set; } // ToDo: GroupID correct? 
    }
}