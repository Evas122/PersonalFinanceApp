using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Currency.CrossCutting.Dtos;
using PersonalFinanceApp.Currency.Services;

namespace PersonalFinanceApp.Currency.Controllers
{
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("currencies")]
        public async Task<IEnumerable<CurrencyDto>> Read() => await _currencyService.Get();

        [HttpGet("currencies/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var currencyDto = await _currencyService.GetById(id);

            if (currencyDto == null)
            {
                return NotFound();
            }

            return Ok(currencyDto);

        }

        [HttpPost("currencies")]
        public async Task<IActionResult> Create([FromBody] CurrencyDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _currencyService.Create(dto);
            return Ok(operationResult.Result);
        }
    }
}
