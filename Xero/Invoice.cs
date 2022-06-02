using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class Invoice
    {
        //fields
        private decimal amount;
        private TaxRate taxRate;

        //constructor
        public Invoice(decimal amount, string countryCode) //amount
        {
            //initialise TaxRate + retrieve country rate
            TaxRate taxRate = new TaxRate(countryCode);

            this.amount = amount; 
            this.taxRate = taxRate; 
        }

        public decimal Amount { get { return amount; } }

        public TaxRate TaxRate { get { return taxRate; } }

        public decimal GetTaxRate { get { return taxRate.Percentage; } }
    }
}
