using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_CommerceSite.Models;
using RelationShip_Many_Many.Data;

namespace RelationShip_Many_Many.Controllers
{
    public class BuyersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buyers
        public async Task<IActionResult> Index()
        {
              return _context.buyers != null ? 
                          View(await _context.buyers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.buyers'  is null.");
        }

        // GET: Buyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.buyers == null)
            {
                return NotFound();
            }

            var buyer = await _context.buyers
                .FirstOrDefaultAsync(m => m.BuyerId == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // GET: Buyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuyerId,Name")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyer);
        }

        // GET: Buyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.buyers == null)
            {
                return NotFound();
            }

            var buyer = await _context.buyers.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return View(buyer);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuyerId,Name")] Buyer buyer)
        {
            if (id != buyer.BuyerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.BuyerId))
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
            return View(buyer);
        }

        // GET: Buyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.buyers == null)
            {
                return NotFound();
            }

            var buyer = await _context.buyers
                .FirstOrDefaultAsync(m => m.BuyerId == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.buyers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.buyers'  is null.");
            }
            var buyer = await _context.buyers.FindAsync(id);
            if (buyer != null)
            {
                _context.buyers.Remove(buyer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerExists(int id)
        {
          return (_context.buyers?.Any(e => e.BuyerId == id)).GetValueOrDefault();
        }
    }
}
