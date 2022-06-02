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

            //calculate tax here
            foreach (Invoice invoice in orders)
            {
                //calculate GST
                decimal gst = invoice.Amount * (invoice.GetTaxRate/100);

                //add to dictionary
                result.Add(invoice.TaxRate, gst);
            }

            //print results
            foreach (KeyValuePair<TaxRate, decimal> item in result)
            {
                Console.WriteLine(item.Key.CountryCode + " rate: " + item.Key.Percentage + "%, " + "Taxed Amount: " + item.Value);
            }

            return result;
        }
    }
}
