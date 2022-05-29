using contracts;
using Microsoft.AspNetCore.Mvc;


namespace ULTIMATE_API.Controllers
{

    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public HomeController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogDebug("debug");
            _logger.LogError("error");
            _logger.LogInfo("info");
            _logger.LogWarn("info");
            return Ok();
        }
    }
}
