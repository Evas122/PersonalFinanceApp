using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Transaction.CrossCutting.Dtos;
using PersonalFinanceApp.Transaction.Services;

namespace PersonalFinanceApp.Transaction.Controllers
{
    [Route("/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("transactions")]
        public async Task<IEnumerable<TransactionDto>> Read() => await _transactionService.Get();

        [HttpGet("transactions/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var transactionDto = await _transactionService.GetById(id);

            if (transactionDto == null)
            {
                return NotFound();
            }

            return Ok(transactionDto);

        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTransactions(Guid userId)
        {
            var transactions = await _transactionService.GetTransactionByUserId(userId);
            return Ok(transactions);
        }

        [HttpPost("transactions")]
        public async Task<IActionResult> Create([FromBody] TransactionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _transactionService.Create(dto);
            return Ok(operationResult.Result);
        }
    }
}
