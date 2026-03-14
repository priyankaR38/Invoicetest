using display_an_invoice3.Data;
using Microsoft.EntityFrameworkCore;
using display_an_invoice3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InvoiceDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=invoice.db"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");

app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();
    db.Database.EnsureCreated();
    if (!db.Invoices.Any())
    {
        var invoice = new Invoice { InvoiceID = 1, CustomerName = "John Doe" };
        db.Invoices.Add(invoice);
        db.Items.Add(new Item { ItemID = 1, InvoiceID = 1, Name = "Widget A", Price = 19.99m });
        db.SaveChanges();
    }
}

app.Run();
