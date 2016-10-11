using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    [JsonObject(Title = "RootObject")]
    public class GetTradeOffersSummaryBaseResponse
    {
        [JsonProperty("response")]
        public GetTradeOffersSummaryResponse Response { get; set; }
    }
}