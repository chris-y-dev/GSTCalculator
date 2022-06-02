using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class TaxRate
    {
        private decimal percentage;
        private string countryCode;

        public TaxRate(string countryCode) //construct taxRate type using country code 
        {
            TaxRateDirectory taxRateDirectory = new TaxRateDirectory(); //initialise directory

            Dictionary<string, decimal> taxRate = new Dictionary<string, decimal>();

            decimal rate = taxRateDirectory.getRateWithCountryCode(countryCode); //
            this.percentage = rate;
            this.countryCode = countryCode;
        }

        public decimal Percentage { get { return this.percentage; } }

        public string CountryCode { get { return this.countryCode; } }
    }
}
