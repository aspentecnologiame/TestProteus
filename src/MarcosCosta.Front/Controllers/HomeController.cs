using MarcosCosta.Domain.Options;
using MarcosCosta.Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace MarcosCosta.Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _appSettings;
        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> options)
        {
            _logger = logger;
            _appSettings = options.Value;
        }

        public IActionResult Index()
        {
            ViewBag.BearerToken = _appSettings.BearerToken;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}