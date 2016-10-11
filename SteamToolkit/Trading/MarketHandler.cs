﻿using System.Collections.Generic;
using System.Globalization;
using System.Net;
using SteamToolkit.Web;
using Newtonsoft.Json;

namespace SteamToolkit.Trading
{
    /// <summary>
    /// Handles market related tasks.
    /// </summary>
    public class MarketHandler
    {
        private const string BaseUrl = "https://steamcommunity.com/market/";

        private readonly Web.Web _web = new Web.Web(new SteamWebRequestHandler());

        /// <summary>
        /// Sets the container to contain a MarketEligibility cookie. Required before trading.
        /// </summary>
        /// <param name="steamId">The SteamId of the bot.</param>
        /// <param name="container">The bot CookieContainer</param>
        public void EligibilityCheck(ulong steamId, CookieContainer container)
        {
            const string url = BaseUrl + "eligibilitycheck/";
            var data = new Dictionary<string, string> { { "goto", "/profiles/" + steamId + "/tradeoffers/" } };
            _web.Fetch(url, "GET", data, container, false);
        }

        /// <summary>
        /// Gets the price overview of an item.
        /// </summary>
        /// <param name="appId">The appId of the item.</param>
        /// <param name="marketHashName">The market_hash_name of the item</param>
        /// <param name="country">Country to check in. (ISO)</param>
        /// <param name="currency">Currency code, I forget what. 1 = US $</param>
        /// <returns>A MarketValue object containing the data.</returns>
        public MarketValue GetPriceOverview(uint appId, string marketHashName, CultureInfo culture, string country = "US", string currency = "1")
        {
            const string url = BaseUrl + "priceoverview/";
            var data = new Dictionary<string, string>
            {
                {"country", country},
                {"currency", currency},
                {"appid", appId.ToString()},
                {"market_hash_name", marketHashName}
            };

            var marketValueResponse = _web.Fetch(url, "GET", data, null, false).DeserializeJson<MarketValueResponse>();

            if (marketValueResponse == null) return null;

            var mv = new MarketValue { Success = marketValueResponse.Success, BaseResponse = marketValueResponse };

            if (!marketValueResponse.Success)
                return mv;

            if (!string.IsNullOrEmpty(marketValueResponse.LowestPrice))
                mv.LowestPrice = decimal.Parse(marketValueResponse.LowestPrice, NumberStyles.Currency, culture);
            else mv.LowestPrice = -1.0m;

            if (!string.IsNullOrEmpty(marketValueResponse.MedianPrice))
                mv.MedianPrice = decimal.Parse(marketValueResponse.MedianPrice, NumberStyles.Currency, culture);
            else
                mv.LowestPrice = -1.0m;

            if (!string.IsNullOrEmpty(marketValueResponse.Volume))
                mv.Volume = int.Parse(marketValueResponse.Volume, NumberStyles.AllowThousands, culture);
            else
                mv.Volume = -1;

            return mv;
        }
    }
}