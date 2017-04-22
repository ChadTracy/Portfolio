using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Chad Tracy
//Due 1/22/2016
//CIS 200-01
//Program Description: Uses the Invoice class in order to display an array of Invoice objects. 
//Uses LINQ dto produce the desired results
namespace Lab1
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            // initialize array of invoices
            Invoice[] invoices = { 
                new Invoice( 83, "Electric sander", 7, 57.98M ), 
                new Invoice( 24, "Power saw", 18, 99.99M ), 
                new Invoice( 7, "Sledge hammer", 11, 21.5M ), 
                new Invoice( 77, "Hammer", 76, 11.99M ), 
                new Invoice( 39, "Lawn mower", 3, 79.5M ), 
                new Invoice( 68, "Screwdriver", 106, 6.99M ), 
                new Invoice( 56, "Jig saw", 21, 11M ), 
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            // A.) Sort Invoice objects by PartDescription (PD)
            //Uses PartDescription method from the Invoice class
            //Use of orderby function to sort by the value returned by PartDescription
            var PDsorted =
                from PartDescription in invoices
                orderby PartDescription
                select PartDescription;
            // B.) Sort Invoice objects by Price
            //Uses Price from the Invoice class
            //Sorts by the Price value
            var PriceSorted =
                from Price in invoices
                orderby Price
                select Price;

            //C.) Select PartDescription and Quantity and sort by Quantity
            //Creates variable that selects both the PartDescription and Quantity
            //Sorts by quantity
            var DescQSorted =
                from i in invoices
                orderby i.PartDescription, i.Quantity
                select i;

            //D.) Select each Invoice's PartDescription and value. Name the column InvoiceTotal. Order results by Invoice value
            //creates InvoiceTotal variable for selecting PartDescription and total 
            //selected results are ordered by 'total'
            var InvoiceTotal =
                from i in invoices
                let total = i.Quantity * i.Price //use of let function to set total to the value of quantity and price
                select new { i.PartDescription, total};
            // creates var for sorting the invoice total
            //orders by total and selects that return value
            var InvTotalSort =
                from total in invoices
                orderby total
                select total;

            //E.) Select InvoiceTotals between $200 and $500
            //further sorts so only invoice totals between 200 and 500 dollars are selected
            var btwn200and500 =
                from i in invoices
                where (i.Price*i.Quantity) >= 200 && (i.Price*i.Quantity) <= 500 //used the price * quantity equation instead of total
                select i;

        }
    }
}
