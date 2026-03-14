using System.Collections.Generic;

namespace display_an_invoice3.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}