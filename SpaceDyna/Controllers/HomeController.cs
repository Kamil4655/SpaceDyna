using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceDyna.DAL;

namespace SpaceDyna.Controllers
{
   
    public class HomeController(SpaceDynaContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await _context.Agencies.ToListAsync();
            return View(data);
        }
    }
}
