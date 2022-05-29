namespace Xero
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //Initialise calculator
          var calculator = new TaxCalculator();

            //initialise invoices
            Invoice invoiceNZ = new Invoice(2500, "NZ");
            Invoice invoiceAU = new Invoice(2500, "AU");
            Invoice invoiceCA = new Invoice(2500, "CA");
            Invoice invoiceNZ2 = new Invoice(3000, "NZ");

            //order list (of invoices)
            List<Invoice> orders = new List<Invoice>();
            orders.Add(invoiceNZ);
            orders.Add(invoiceAU);
            orders.Add(invoiceCA);
            orders.Add(invoiceNZ2);

            Dictionary<TaxRate, decimal> result = calculator.CalculateGST(orders);
            
            /*foreach (KeyValuePair<TaxRate, decimal> item in result)
            {
                Console.WriteLine(item.Key.countryCode + " rate: " + item.Key.taxRate*100 + "%, "+ "Taxed Amount: " + item.Value);
            }*/
            

        }
    }
}