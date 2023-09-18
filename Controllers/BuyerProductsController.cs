using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelationShip_Many_Many.Data;
using RelationShip_Many_Many.Models;

namespace RelationShip_Many_Many.Controllers
{
    public class BuyerProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyerProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BuyerProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BuyerProduct.Include(b => b.Buyer).Include(b => b.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BuyerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuyerProduct == null)
            {
                return NotFound();
            }

            var buyerProducts = await _context.BuyerProduct
                .Include(b => b.Buyer)
                .Include(b => b.Products)
                .FirstOrDefaultAsync(m => m.BuyerProductId == id);
            if (buyerProducts == null)
            {
                return NotFound();
            }

            return View(buyerProducts);
        }

        // GET: BuyerProducts/Create
        public IActionResult Create()
        {
            ViewData["BuyerId"] = new SelectList(_context.buyers, "BuyerId", "Name");
            ViewData["ProductP_ID"] = new SelectList(_context.Products, "P_ID", "P_Name");
            return View();
        }

        // POST: BuyerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuyerProductId,BuyerId,ProductP_ID")] BuyerProducts buyerProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyerProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerId"] = new SelectList(_context.buyers, "BuyerId", "Name", buyerProducts.BuyerId);
            ViewData["ProductP_ID"] = new SelectList(_context.Products, "P_ID", "P_Name", buyerProducts.ProductP_ID);
            return View(buyerProducts);
        }

        // GET: BuyerProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuyerProduct == null)
            {
                return NotFound();
            }

            var buyerProducts = await _context.BuyerProduct.FindAsync(id);
            if (buyerProducts == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.buyers, "BuyerId", "Name", buyerProducts.BuyerId);
            ViewData["ProductP_ID"] = new SelectList(_context.Products, "P_ID", "P_Name", buyerProducts.ProductP_ID);
            return View(buyerProducts);
        }

        // POST: BuyerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuyerProductId,BuyerId,ProductP_ID")] BuyerProducts buyerProducts)
        {
            if (id != buyerProducts.BuyerProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyerProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerProductsExists(buyerProducts.BuyerProductId))
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
            ViewData["BuyerId"] = new SelectList(_context.buyers, "BuyerId", "Name", buyerProducts.BuyerId);
            ViewData["ProductP_ID"] = new SelectList(_context.Products, "P_ID", "P_Name", buyerProducts.ProductP_ID);
            return View(buyerProducts);
        }

        // GET: BuyerProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuyerProduct == null)
            {
                return NotFound();
            }

            var buyerProducts = await _context.BuyerProduct
                .Include(b => b.Buyer)
                .Include(b => b.Products)
                .FirstOrDefaultAsync(m => m.BuyerProductId == id);
            if (buyerProducts == null)
            {
                return NotFound();
            }

            return View(buyerProducts);
        }

        // POST: BuyerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuyerProduct == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BuyerProduct'  is null.");
            }
            var buyerProducts = await _context.BuyerProduct.FindAsync(id);
            if (buyerProducts != null)
            {
                _context.BuyerProduct.Remove(buyerProducts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerProductsExists(int id)
        {
          return (_context.BuyerProduct?.Any(e => e.BuyerProductId == id)).GetValueOrDefault();
        }
    }
}
