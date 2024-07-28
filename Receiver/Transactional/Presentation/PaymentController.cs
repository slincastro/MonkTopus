using Microsoft.AspNetCore.Mvc;
using Application.Domain;
using System.Transactions;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly TransactionContext _context;

        public PaymentController(TransactionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostCreditCard([FromBody] CreditCard creditCard)
        {
            var transactionId = Guid.NewGuid();
            try
            {
               transactionId = AddNewItem(new Transaction
                        {
                            CardNumber=creditCard.CardNumber,  
                            ExpirationDate=creditCard.ExpirationDate, 
                            HolderName=creditCard.HolderName,
                            SecurityCode=creditCard.SecurityCode,
                            Amount=creditCard.Amount,
                            Currency=creditCard.Currency,
                            TransactionDate=DateTime.UtcNow,
                            Status="Pending",
                        }
                    );

                Console.WriteLine($"Transaction: {transactionId} added to the database");

                new RabbitMQPublisher().Publish();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return Ok(new { message = $"Credit card processed successfully! transaction:{transactionId}", creditCard });

        }

        public Guid AddNewItem(Transaction newItem)
        {
            _context.Transactions.Add(newItem);
            _context.SaveChanges();
            return newItem.Id;
        }
    }
}