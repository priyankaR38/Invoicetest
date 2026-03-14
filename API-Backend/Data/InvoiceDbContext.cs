using Microsoft.EntityFrameworkCore;
using display_an_invoice3.Models;

namespace display_an_invoice3.Data
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}



