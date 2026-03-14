namespace display_an_invoice3.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}