using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CarOwnersController : Controller
    {
        private readonly WebApp1Context _context;

        public CarOwnersController(WebApp1Context context)
        {
            _context = context;
        }

        // GET: CarOwners
        public async Task<IActionResult> Index()
        {
              return _context.CarOwner != null ? 
                          View(await _context.CarOwner.ToListAsync()) :
                          Problem("Entity set 'WebApp1Context.CarOwner'  is null.");
        }

        // GET: CarOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarOwner == null)
            {
                return NotFound();
            }

            var carOwner = await _context.CarOwner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carOwner == null)
            {
                return NotFound();
            }

            return View(carOwner);
        }

        // GET: CarOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Car,Model")] CarOwner carOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carOwner);
        }

        // GET: CarOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarOwner == null)
            {
                return NotFound();
            }

            var carOwner = await _context.CarOwner.FindAsync(id);
            if (carOwner == null)
            {
                return NotFound();
            }
            return View(carOwner);
        }

        // POST: CarOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Car,Model")] CarOwner carOwner)
        {
            if (id != carOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarOwnerExists(carOwner.Id))
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
            return View(carOwner);
        }

        // GET: CarOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarOwner == null)
            {
                return NotFound();
            }

            var carOwner = await _context.CarOwner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carOwner == null)
            {
                return NotFound();
            }

            return View(carOwner);
        }

        // POST: CarOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarOwner == null)
            {
                return Problem("Entity set 'WebApp1Context.CarOwner'  is null.");
            }
            var carOwner = await _context.CarOwner.FindAsync(id);
            if (carOwner != null)
            {
                _context.CarOwner.Remove(carOwner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarOwnerExists(int id)
        {
          return (_context.CarOwner?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
