using System.Diagnostics;
using LoggingWithElmah.Common.Exceptions;
using LoggingWithElmah.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoggingWithElmah.Controllers;

public class TestElmahController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public TestElmahController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GenerateExceptionError()
    {
        throw new Exception("Bu bir test (Exception) xətasıdır. Elmah ilə loglanacaq");
    }
        
    public IActionResult GenerateNotFoundError()
    {
        throw new NotFoundException("Başqa bir test (NotFound) xətasıdır. Elmah ilə loglanacaq");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
