using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class TaxCalculator
    {

        public Dictionary<TaxRate, decimal> CalculateGST (List<Invoice> orders)
        {
            var result = new Dictionary<TaxRate, decimal>(); //dictionary to be returned

            foreach (Invoice invoice in orders)  //calculator logic
            {
                decimal gst = invoice.Amount * (invoice.GetTaxRate/100); //Amount * Rate

                result.Add(invoice.TaxRate, gst); //Add to result dictionary
            }

           
            foreach (KeyValuePair<TaxRate, decimal> item in result)  //print results
            {
                Console.WriteLine(item.Key.CountryCode + " rate: " + item.Key.Percentage + "%, " + "GST total: " + item.Value);
            }

            return result;
        }
    }
}
