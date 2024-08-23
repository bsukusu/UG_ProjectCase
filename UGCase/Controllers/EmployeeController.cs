using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UGCase.Models;
using UGCase.Models.Context;
namespace UGCase.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Context _context;

        public EmployeeController(Context context)
        {

        _context = context; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.musterisFatura.ToList();
            return View(employees);
        }

        public IActionResult CustomerDetails(int id)
        {
            var CustomerDetails = _context.musteris
                                   .Include(c => c.MusteriFaturalar)
                                   .FirstOrDefault(c => c.Id == id);

            if (CustomerDetails == null)
            {
                return NotFound();
            }

            var maxDebt = CustomerDetails.MusteriFaturalar
                                  .OrderByDescending(f => f.faturaTutari)
                                  .FirstOrDefault();

            ViewData["MaxDebtDate"] = maxDebt?.faturaTarihi;
            ViewData["MaxDebtAmount"] = maxDebt?.faturaTutari;

            return View(CustomerDetails);
        }


        public IActionResult Invoice(int id)
        {
            var customer = _context.musteris
                                    .Include(c => c.MusteriFaturalar)
                                    .FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer); 
        }

    }
}
