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
    }
}
