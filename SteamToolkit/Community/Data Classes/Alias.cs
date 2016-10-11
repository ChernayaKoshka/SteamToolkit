using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamToolkit.Community
{
    public class Alias
    {
        [JsonProperty("newname")]
        public string NewName { get; set; }
        [JsonProperty("timechanged")]
        public string TimeChanged { get; set; }
    }
}
