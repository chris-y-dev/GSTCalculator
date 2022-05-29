using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class TaxCalculator
    {
        //private field
        

        //constructor
        public TaxCalculator()
        {
            //initialise TaxRate object as field
        }
        
        //calculator function
        public Dictionary<TaxRate, decimal> CalculateGST(List<Invoice> orders)
        {

            var result = new Dictionary<TaxRate, decimal>(); //dictionary to be returned

            //calculate tax here
            //foreach item in List, (Invoice.price) - TaxRate * price = GST
            foreach (Invoice invoice in orders)
            {
                //sum of each invoice
                decimal invoiceAmount = invoice.getInvoiceAmount();

                //rate to calculate for each invoice
                decimal rate = invoice.taxRate.getRate();

                //calculate GST
                decimal gst = invoiceAmount * rate;

                //add to dictionary
                result.Add(invoice.taxRate, gst);

                //if existing, update amount
            }

            //print results
            foreach (KeyValuePair<TaxRate, decimal> item in result)
            {
                Console.WriteLine(item.Key.countryCode + " rate: " + item.Key.taxRate * 100 + "%, " + "Taxed Amount: " + item.Value);
            }



            return result;
        }


    }

    //Datatype TaxRate (each TaxCalculator will have their own 'TaxRate' values)
    public class TaxRate
    {
        public decimal taxRate;
        public string countryCode;

        public TaxRate(string countryCode) //construct taxRate type using country code 
        {
            TaxRateDirectory taxRateDirectory = new TaxRateDirectory(); //initialise directory

            Dictionary<string, decimal> taxRate = new Dictionary<string, decimal>();

            decimal rate = taxRateDirectory.getRateWithCountryCode(countryCode); //
            this.taxRate = rate;
            this.countryCode = countryCode;
        }

        public decimal getRate()
        {
            return this.taxRate;
        }

    }

    //Stores rates of countries Xero is operating in
    public class TaxRateDirectory { 

        public Dictionary<string, decimal> rates;

        //constructor
        public TaxRateDirectory()
        {
            rates = new Dictionary<string, decimal>()
            {
                {"NZ", 0.15m},
                {"AU", 0.10m},
                {"CA", 0.05m},
                {"HK", 0m},
                {"ID", 0.11m} //indonesia
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
                Console.WriteLine("Found value for " + countryCode);
                return value;
            } else
            {
                Console.WriteLine("The provided country code: " + countryCode + " is not available on Xero's GST calculator");
                return -1;
            }
        }
    }

    public class Invoice
    {
        public decimal amount;
        public TaxRate taxRate;
        

        //constructor
        public Invoice(decimal amount, string countryCode) //amount
        {
            //initialise TaxRate 
            TaxRate taxRate = new TaxRate(countryCode);

            //use TaxRate method to retrieve tax rate

            this.amount = amount;
            this.taxRate = taxRate;
           
        }
       
        //methods
        public decimal updateInvoiceSum(decimal amount) //add to invoice
        {
            return this.amount += amount;
        }

        public decimal getInvoiceAmount()
        {
            Console.WriteLine(this.amount);
            return this.amount;
        }

    }

}
