using Lab12_PH00000.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab12_PH00000.Controllers
{
    public class HameController : Controller
    {
        private readonly ILogger<HameController> _logger;

        public HameController(ILogger<HameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}