
using Microsoft.AspNetCore.Mvc;
using TransactionWebAPI.Services;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionWebAPI.Controllers
{


    // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));

        }

        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <return> return the list of Transactions </return>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_transactionService.GetTransactions());
        }
        // <summary>
        /// Get Transaction by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return the Transaction with the passed ID </returns>
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            return _transactionService.GetTransaction(id) != null ? Ok(_transactionService.GetTransaction(id)) : NoContent();
        }

        /// <summary>
        /// Add Transactions
        /// </summary>
        /// <param name="Transaction"></param>
        /// <returns>Return the added Transaction</returns>
        [HttpPost]

        public IActionResult Post([FromBody] Models.Transaction Transaction)
        {
            return Ok(_transactionService.AddTransaction(Transaction));
        }

        /// <summary>
        /// update the Transaction
        /// </summary>
        /// <param name="Transaction"=</param>
        /// <returns>Return the updated Transaction</returns>
        [HttpPut]

        public IActionResult Put([FromBody] Models.Transaction Transaction)
        {
            return Ok(_transactionService.UpdateTransaction(Transaction));
        }

        /// <summary>
        /// Delete the Transaction with the passed ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var result = _transactionService.DeleteTransaction(id);

            return result.HasValue & result == true ? Ok($"Transaction with ID:{id} got deleted successfully.")
               : BadRequest($"Unable to delete the Transaction with ID:{id}.");
        }



    }




}






