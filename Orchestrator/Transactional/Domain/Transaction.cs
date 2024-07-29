
namespace Application.Domain;

using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    public Guid Id { get; set; } 
    public Guid TransactionId { get; set; }
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string HolderName { get; set; }
    public string SecurityCode { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Status { get; set; }

    [NotMapped]
    public string Next {get; set;}

}