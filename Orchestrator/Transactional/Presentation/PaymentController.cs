using Microsoft.AspNetCore.Mvc;
using Application.Domain;

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
        public IActionResult PostCreditCard([FromBody] Payment payment)
        {
            var transactionId = Guid.NewGuid();
            try
            {
               var transaction = new Transaction
                {
                    Id = transactionId,
                    CorrelationId = payment.CorrelationId,
                    CardNumber = payment.CardNumber,  
                    ExpirationDate = payment.ExpirationDate, 
                    HolderName = payment.HolderName,
                    SecurityCode = payment.SecurityCode,
                    Amount = payment.Amount,
                    Currency = payment.Currency,
                    TransactionDate = DateTime.UtcNow,
                    Status = TransactionEvents.AwaitingPaymentProcessor.ToString(),
                    Next = "toNotify"
                };

                 transactionId = AddNewItem(transaction);

                Console.WriteLine($"Transaction: {transactionId} added to the database");

                var publisher = new RabbitMQPublisher();
                publisher.Publish(transaction,"toAutorize");
                publisher.Publish(transaction,"toAudit");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return Ok(new { message = $"Credit card processed successfully! transaction:{transactionId}", payment });

        }

        public Guid AddNewItem(Transaction newItem)
        {
            _context.Transactions.Add(newItem);
            _context.SaveChanges();
            return newItem.CorrelationId;
        }
    }
}