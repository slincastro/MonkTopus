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
            var transactionId = Guid.NewGuid();

            try
            {
               var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    TransactionId = transactionId,
                    Amount = charge.Amount,
                    Currency = charge.Currency,
                    TransactionDate = DateTime.UtcNow,
                    Status = TransactionEvents.Generated.ToString(),
                    Next = "toNotify"
                };

                transactionId = AddNewItem(transaction);

                Console.WriteLine($"Transaction: {transactionId} added to the database");

                new RabbitMQPublisher().Publish(transaction);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return Ok(new { message = $"Credit card processed successfully! transaction:{transactionId}", charge });

        }

        public Guid AddNewItem(Transaction newItem)
        {
            _context.Transactions.Add(newItem);
            _context.SaveChanges();
            return newItem.Id;
        }
    }
}