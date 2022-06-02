using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class TaxRateDirectory
    {
        private Dictionary<string, decimal> rates;

        public TaxRateDirectory()
        {
            rates = new Dictionary<string, decimal>()
            {
                {"NZ", 15m},
                {"AU", 10m},
                {"CA", 5m},
                {"HK", 0m},
                {"SG", 7m},
                {"UK", 20m}
            };
        }

        //method to visualise all Codes + Rates
        public void getSavedCountriesAndRates()
        {
            foreach (KeyValuePair<string, decimal> pair in rates)
            {
                Console.WriteLine("Country Code (Key): " + pair.Key + ", GST rate: " + pair.Value);
            }
        }

        //method to retrieve the rate using Code.
        public decimal getRateWithCountryCode(String countryCode)
        {
            decimal value;
            if (rates.TryGetValue(countryCode, out value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("The provided country code: " + countryCode + " is not available on Xero's GST calculator");
                return -1;
            }
        }
    }
}
