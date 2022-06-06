using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class TaxRateDirectory
    {
        private Dictionary<string, int> rates;

        public TaxRateDirectory()
        {
            rates = new Dictionary<string, int>()
            {
                {"NZ", 15},
                {"AU", 10},
                {"CA", 5},
                {"HK", 0},
                {"SG", 7},
                {"UK", 20}
            };
        }

        public int getRateWithCountryCode(String countryCode) //Method to get % with CountryCode
        {
            int value;
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
