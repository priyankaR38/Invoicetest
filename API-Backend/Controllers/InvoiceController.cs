
using Microsoft.AspNetCore.Mvc;
using display_an_invoice3.Data;
using display_an_invoice3.Models;
using Microsoft.EntityFrameworkCore;

namespace display_an_invoice3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceDbContext _context;

        public InvoiceController(InvoiceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetInvoice()
        {
            var invoice = _context.Invoices.Include(i => i.Items).FirstOrDefault();
            if (invoice == null)
            {
                return NotFound("No invoice found");
            }
            return Ok(new { items = invoice.Items.Select(i => new { name = i.Name, price = i.Price }) });
        }
    }
}
