using System;
using Microsoft.EntityFrameworkCore;
using Application.Domain;

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

