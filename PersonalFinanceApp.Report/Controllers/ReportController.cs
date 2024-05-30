using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Report.CrossCutting.Dtos;
using PersonalFinanceApp.Report.Services;

namespace PersonalFinanceApp.Report.Controllers
{
    [Route("/report")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("Reports")]
        public async Task<IEnumerable<ReportDto>> Read() => await _reportService.Get();

        [HttpGet("Reports/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var reportDto = await _reportService.GetById(id);

            if (reportDto == null)
            {
                return NotFound();
            }

            return Ok(reportDto);

        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserReports(Guid userId)
        {
            var reports = await _reportService.GetReportByUserId(userId);
            return Ok(reports);
        }

        [HttpPost("Reports")]
        public async Task<IActionResult> Create([FromBody] ReportDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _reportService.Create(dto);
            return Ok(operationResult.Result);
        }
    }
}
