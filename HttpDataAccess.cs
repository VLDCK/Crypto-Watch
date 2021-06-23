using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;


namespace Crypt_Watch
{
    class HttpDataAccess
    {
        static string url = "https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,XRP,LTC,SHIB,DOGE,MATIC,ADA&tsyms=USD,UAH";
        static string apiKey = "&apiid=2a3c02010221fb4e38022638bcb92d2da58d75fe871b3d3074ed53a9d292ebd0";
        static HttpWebRequest httpWebRequest; 
        static HttpWebResponse httpWebResponce;
        public static string Responce { get; set; }

        public HttpDataAccess()
        {
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url+apiKey);
                httpWebResponce = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpWebResponce.GetResponseStream()))
                {
                    Responce = streamReader.ReadToEnd();
                }
            }
            catch (WebException exp) { }
            
        }
        public string GetResponce()
        {
            string result=null;
            try
            {
                NameCrypt parcerResponce = JsonConvert.DeserializeObject<NameCrypt>(Responce);
                result = "BTC\t\tBitcoin\t\t\t" + parcerResponce.BTC.RoundPriceUSD() + " USD / " + parcerResponce.BTC.RoundPriceUAH() + " UAH\n"+
                  "ETH\t\tEthereum\t\t" + parcerResponce.ETH.RoundPriceUSD() + " USD / " + parcerResponce.ETH.RoundPriceUAH() + " UAH\n" +
                  "DOGE\t\tDogecoin\t\t" + parcerResponce.DOGE.RoundPriceUSD() + " USD / " + parcerResponce.DOGE.RoundPriceUAH() + " UAH\n" +

                "SHIB\t\tShiba Inu\t\t" + parcerResponce.SHIB.RoundPriceUSD() + " USD / " + parcerResponce.SHIB.RoundPriceUAH() + " UAH\n" +
                "LTC\t\tLitecoin\t\t\t" + parcerResponce.LTC.RoundPriceUSD() + " USD / " + parcerResponce.LTC.RoundPriceUAH() + " UAH\n" +
                "XPR\t\tExprivia\t\t\t" + parcerResponce.XRP.RoundPriceUSD()  + " USD / " + parcerResponce.XRP.RoundPriceUAH() + " UAH\n"+
                "MATIC\t\tPolygon\t\t\t" + parcerResponce.MATIC.RoundPriceUSD() + " USD / " + parcerResponce.MATIC.RoundPriceUAH() + " UAH\n" +
                "ADA\t\tCardano\t\t\t" + parcerResponce.ADA.RoundPriceUSD() + " USD / " + parcerResponce.ADA.RoundPriceUAH() + " UAH\n"; 

            }
            catch (ArgumentNullException exp) { }
           
            return result;
           
        }

       
       


    }
}
