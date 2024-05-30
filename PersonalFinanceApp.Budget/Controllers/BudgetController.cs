using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using PersonalFinanceApp.Budget.Services;

namespace PersonalFinanceApp.Budget.Controllers
{
    [Route("/budget")]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetService _budgetService;

        public BudgetController(BudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("budgets")]
        public async Task<IEnumerable<BudgetDto>> Read() => await _budgetService.Get();

        [HttpGet("budgets/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var budgetDto = await _budgetService.GetById(id);

            if(budgetDto == null)
            {
                return NotFound();
            }

            return Ok(budgetDto);

        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBudgets(Guid userId)
        {
            var budgets = await _budgetService.GetBudgetByUserId(userId);
            return Ok(budgets);
        }


        [HttpPost("budgets")]
        public async Task<IActionResult> Create([FromBody] BudgetDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _budgetService.Create(dto);
            return Ok(operationResult.Result);
        }
    }


}
