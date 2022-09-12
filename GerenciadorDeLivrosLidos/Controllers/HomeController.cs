using GerenciadorDeLivrosLidos.Data;
using GerenciadorDeLivrosLidos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GerenciadorDeLivrosLidos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SeedingService seedService)
        {
            _logger = logger;
            seedService.Seed();
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