using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using PersonalFinanceApp.User.CrossCutting.Dtos;
using PersonalFinanceApp.User.Services;

namespace PersonalFinanceApp.User.Controllers
{
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserDto>> Read() => await _userService.Get();

        [HttpGet("users/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var userDto = await _userService.GetById(id);

            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);

        }

        [HttpPost("users")]
        public async Task<IActionResult> Create([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _userService.Create(dto);
            return Ok(operationResult.Result);
        }

        [HttpGet("{userId}/transactions")]
        public async Task<IActionResult> GetUserTransactions(Guid userId)
        {
            var transactions = await _userService.GetUserTransactionASync(userId);
            return Ok(transactions);
        }

        [HttpGet("{userId}/budgets")]
        public async Task<IActionResult> GetUserBudgets(Guid userId)
        {
            var budgets = await _userService.GetUserBudgetASync(userId);
            return Ok(budgets);
        }

        [HttpGet("{userId}/reports")]
        public async Task<IActionResult> GetUserReports(Guid userId)
        {
            var reports = await _userService.GetUserReportASync(userId);
            return Ok(reports);
        }
    }
}
