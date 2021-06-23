using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Crypt_Watch
{
    class NameCrypt
    {
        public NameCurrencies BTC { get; set; }
        public NameCurrencies ETH { get; set; }
        public NameCurrencies DOGE { get; set; }
        public NameCurrencies LTC { get; set; }
        public NameCurrencies SHIB { get; set; }
        public NameCurrencies XRP { get; set; }
        public NameCurrencies MATIC { get; set; }
        public NameCurrencies ADA { get; set; }
    }

    class NameCurrencies
    {
        public double USD { get; set; }
        public double UAH { get; set; }
        public string RoundPriceUSD()
        {
            if (USD < 0.10 || Convert.ToString(USD).Length > 8)
            {
                USD = Math.Round(Convert.ToDouble(USD), 6);
            }
            return Convert.ToString(USD);
        }
        public string RoundPriceUAH()
        {
            if (UAH < 0.10 || Convert.ToString(UAH).Length > 8)
            {
                UAH = Math.Round(Convert.ToDouble(UAH), 6);
            }
            return Convert.ToString(UAH);
        }
    }
  

}
    
   
