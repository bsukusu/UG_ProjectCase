using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UGCase.Models;
using UGCase.Models.Context;

namespace UGCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(int id)
        {
            var customer = _context.musteris
                                    .Include(c => c.MusteriFaturalar)
                                    .FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                return RedirectToAction("Invoice", "Employee", new { id = id });
            }

            TempData["ErrorMessage"] = "M��teri bulunamad�. L�tfen ge�erli bir m��teri ID girin.";
            return RedirectToAction("Index");
        }


    }
}
