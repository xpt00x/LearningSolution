using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.Core.Interfaces;
using Practice.Core.Services;

namespace Practice.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService service)
        {
            _calculatorService = service;
            _logger = logger;
        }

        [HttpGet(Name = "Calculate")]
        public IActionResult Calculate(int a, int b, string operation)
        {
            try
            {
                var result = _calculatorService.Calculate(a, b, operation);
                _logger.LogInformation($"Success: {a}, {b}, {operation}");
                return Ok(result);
            }
            catch
            {
                _logger.LogError($"Invalid operation. {a}, {b}, {operation}");
                return BadRequest("Invalid operation!");
            }
        }
    }
}