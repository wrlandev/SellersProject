using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SellersProject.Data;
using SellersProject.Models;

namespace SellersProject.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersProjectContext _context;

        public SellersController(SellersProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.SellerModel != null ? 
                          View(await _context.SellerModel.ToListAsync()) :
                          Problem("Entity set 'SellersProjectContext.SellerModel'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellerModel == null)
            {
                return NotFound();
            }

            var sellerModel = await _context.SellerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellerModel == null)
            {
                return NotFound();
            }

            return View(sellerModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,BirthDate,BaseSalary")] SellerModel sellerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellerModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellerModel == null)
            {
                return NotFound();
            }

            var sellerModel = await _context.SellerModel.FindAsync(id);
            if (sellerModel == null)
            {
                return NotFound();
            }
            return View(sellerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,BirthDate,BaseSalary")] SellerModel sellerModel)
        {
            if (id != sellerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerModelExists(sellerModel.Id))
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
            return View(sellerModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellerModel == null)
            {
                return NotFound();
            }

            var sellerModel = await _context.SellerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellerModel == null)
            {
                return NotFound();
            }

            return View(sellerModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellerModel == null)
            {
                return Problem("Entity set 'SellersProjectContext.SellerModel'  is null.");
            }
            var sellerModel = await _context.SellerModel.FindAsync(id);
            if (sellerModel != null)
            {
                _context.SellerModel.Remove(sellerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerModelExists(int id)
        {
          return (_context.SellerModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
