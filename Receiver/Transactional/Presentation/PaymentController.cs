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
            _context = context;  // Dependency injection provides the context
        }

        [HttpPost]
        public IActionResult PostCreditCard([FromBody] CreditCard creditCard)
        {
            try
            {
            AddNewItem(new Item
             {
                CardNumber=creditCard.CardNumber, 
                ExpirationMonth= creditCard.ExpirationMonth, 
                ExpirationYear=creditCard.ExpirationYear, 
                HolderName=creditCard.CardNumber
                }
            );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return Ok(new { message = "Credit card processed successfully!", creditCard });

        }

        public void AddNewItem(Item newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
        }
    }
}