using AgriStream_loT.Data;
using AgriStream_loT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgriStream_IoT.Controllers
{
    public class FarmersController : Controller
    {
        private readonly AgriStream_loTContext _context;

        public FarmersController(AgriStream_loTContext context) => _context = context;

        // GET: /Farmers
        public async Task<IActionResult> Index()
    => View(await _context.Farmers.ToListAsync());   

        // GET: /Farmers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null) return NotFound();
            return View(farmer);
        }

        // GET: /Farmers/Create
        public IActionResult Create() => View();

        // POST: /Farmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(farmer farmer)
        {
            if (!ModelState.IsValid) return View(farmer);

            farmer.CreatedAt = DateTime.UtcNow;
            _context.Add(farmer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Farmers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null) return NotFound();
            return View(farmer);
        }

        // POST: /Farmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, farmer farmer)
        {
            if (id != farmer.Id) return NotFound();
            if (!ModelState.IsValid) return View(farmer);

            try
            {
                farmer.UpdatedAt = DateTime.UtcNow;
                _context.Update(farmer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Farmers.AnyAsync(f => f.Id == id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Farmers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null) return NotFound();
            return View(farmer);
        }

        // POST: /Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}