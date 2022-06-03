using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero
{
    public class Invoice
    {
        private decimal amount;
        private TaxRate taxRate;

        ///constructor
        public Invoice(decimal amount, string countryCode) //amount
        {
            TaxRate taxRate = new TaxRate(countryCode); //Each invoice has one TaxRate object

            this.amount = amount; 
            this.taxRate = taxRate; 
        }

        //////Getters
        public decimal Amount { get { return amount; } }

        public TaxRate TaxRate { get { return taxRate; } }

        public decimal GetTaxRate { get { return taxRate.Percentage; } }
    }
}
