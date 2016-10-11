using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    public class MarketValue
    {
        public bool Success { get; set; }

        public decimal LowestPrice { get; set; }
             
        public int Volume { get; set; }
            
        public decimal MedianPrice { get; set; }

        [JsonIgnore]
        public MarketValueResponse BaseResponse { get; set; }
    }
}