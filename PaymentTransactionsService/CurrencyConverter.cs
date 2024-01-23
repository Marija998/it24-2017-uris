using System.Globalization;

namespace TransactionServiceAPI
{
    public class CurrencyConverter
    {
        private const string endpoint = @"http://currencies.apps.grandtrunk.net/getlatest/{0}/{1}";
        private static HttpClient httpClient = new HttpClient();
        public static decimal Convert(decimal amount, string from, string to)
        {
            return amount * GetExchangeRate(from, to);
        }
        public static decimal GetExchangeRate(string from, string to)
        {
            string url = string.Format(endpoint, from, to);
            return decimal.Parse(httpClient.GetStringAsync(url).GetAwaiter().GetResult(), NumberFormatInfo.InvariantInfo);
        }
    }
}


