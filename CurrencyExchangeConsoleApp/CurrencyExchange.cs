using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeConsoleApp
{
    internal class CurrencyExchange
    {
        private const string endpoint = @"http://currencies.apps.grandtrunk.net/getlatest/{0}/{1}";
        private static HttpClient httpClient = new HttpClient();
        public static decimal Convert(decimal amount, String from, String to)
        {
            return amount * GetExchangeRate(from, to);
        }
        public static decimal GetExchangeRate(String from, String to)
        {
            string url = string.Format(endpoint, from, to);
            return decimal.Parse(httpClient.GetStringAsync(url).GetAwaiter().GetResult(), NumberFormatInfo.InvariantInfo);
        }
    }
}