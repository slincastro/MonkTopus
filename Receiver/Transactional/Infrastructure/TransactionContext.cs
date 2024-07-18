using System;
using Microsoft.EntityFrameworkCore;

public class TransactionContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public TransactionContext(DbContextOptions<TransactionContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace with your connection string
        optionsBuilder.UseNpgsql("Host=db; Port=5432; Database=mydb; Username=user; Password=password;");
    }
}

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid(); 

    public string CardNumber { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public string HolderName { get; set; }
    public string SecurityCode { get; set; }
}
