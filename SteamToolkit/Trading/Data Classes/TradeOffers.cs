using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    [JsonObject(Title = "RootObject")]
    public class TradeOffers
    {
        [JsonProperty("response")]
        public TradeOffersList Response { get; set; }
    }
}