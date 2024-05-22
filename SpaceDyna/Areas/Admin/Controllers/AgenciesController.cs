using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpaceDyna.DAL;
using SpaceDyna.Models;

namespace SpaceDyna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgenciesController : Controller
    {
        private readonly SpaceDynaContext _context;

        public AgenciesController(SpaceDynaContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agencies.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = await _context.Agencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

       
        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        
        public async Task<IActionResult> Create( Agency agency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = await _context.Agencies.FindAsync(id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

       
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id, Agency agency)
        {
            if (id != agency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgencyExists(agency.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

   
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = await _context.Agencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        
        [HttpPost, ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agency = await _context.Agencies.FindAsync(id);
            if (agency != null)
            {
                _context.Agencies.Remove(agency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyExists(int id)
        {
            return _context.Agencies.Any(e => e.Id == id);
        }
    }
}
