using System;
using Microsoft.EntityFrameworkCore;

public class TransactionContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }

    public TransactionContext(DbContextOptions<TransactionContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=db; Port=5432; Database=mydb; Username=user; Password=password;");
    }
}

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string HolderName { get; set; }
    public string SecurityCode { get; set; }

    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Status { get; set; }

}
