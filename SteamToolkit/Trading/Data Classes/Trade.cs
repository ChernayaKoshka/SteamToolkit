using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    [JsonObject(Title = "RootObject")]
    public class Trade
    {
        [JsonProperty("tradeid")]
        public ulong TradeId { get; set; }
    }
}