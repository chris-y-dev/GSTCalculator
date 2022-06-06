namespace Xero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instances of invoices
            Invoice invoiceNZ = new Invoice(3000, "NZ");
            Invoice invoiceAU = new Invoice(3000, "AU");
            Invoice invoiceCA = new Invoice(3000, "CA");
            Invoice invoiceUK = new Invoice(3000, "UK");
            Invoice invoiceSG = new Invoice(3000, "SG");
            Invoice invoiceHK = new Invoice(3000, "HK");

            //List of invoices (orders)
            List<Invoice> orders = new List<Invoice>();
            orders.Add(invoiceNZ);
            orders.Add(invoiceAU);
            orders.Add(invoiceCA);
            orders.Add(invoiceUK);
            orders.Add(invoiceSG);
            orders.Add(invoiceHK);

            //Initialise calculator
            var calculator = new TaxCalculator();
            var result = calculator.CalculateGST(orders);
 

            //Print result dictionary as String
            //Console.WriteLine(string.Join(Environment.NewLine, result));

            Console.ReadLine();
        }
    }
}