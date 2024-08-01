using Microsoft.AspNetCore.Mvc;
using Application.Domain;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class ChargeController : ControllerBase
    {
        private readonly TransactionContext _context;

        public ChargeController(TransactionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Charge([FromBody] Charge charge)
        {
            var correlationId = Guid.NewGuid();

            try
            {
               var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    CorrelationId = correlationId,
                    Amount = charge.Amount,
                    Currency = charge.Currency,
                    TransactionDate = DateTime.UtcNow,
                    Status = TransactionEvents.Generated.ToString(),
                    Next = "toNotify"
                };

                correlationId = AddNewItem(transaction);

                Console.WriteLine($"Transaction: {correlationId} added to the database");

                var publisher = new RabbitMQPublisher();

                publisher.Publish(transaction);
                publisher.Publish(transaction,"toAudit");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return Ok(new { message = $"Credit card processed successfully!", correlationId, charge });

        }

        public Guid AddNewItem(Transaction newItem)
        {
            _context.Transactions.Add(newItem);
            _context.SaveChanges();
            return newItem.CorrelationId;
        }
    }
}