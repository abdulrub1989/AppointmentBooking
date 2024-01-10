using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SussBookingAppointment.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/Error")]
        public IActionResult Index()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError($"{exception.Error.Message} : {exception.Error.InnerException} \n {exception.Error.StackTrace}");
            return View(exception);
        }

        [HttpGet("/Error/NotFound/{statusCode}")]
        public IActionResult NotFound(int statusCode)
        {
            //var exception = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            //_logger.LogError($"PAGE NOT FOUND: {exception.OriginalPath}");
            //return View("NotFound", exception.OriginalPath);
            return View();
        }
    }
}
