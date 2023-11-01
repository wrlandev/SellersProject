﻿using System;
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
    public class DepartmentsController : Controller
    {
        private readonly SellersProjectContext _context;

        public DepartmentsController(SellersProjectContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
              return _context.DepartmentModel != null ? 
                          View(await _context.DepartmentModel.ToListAsync()) :
                          Problem("Entity set 'SellersProjectContext.DepartmentModel'  is null.");
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentModel == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentModel);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentModel == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            return View(departmentModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DepartmentModel departmentModel)
        {
            if (id != departmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentModelExists(departmentModel.Id))
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
            return View(departmentModel);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentModel == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentModel == null)
            {
                return Problem("Entity set 'SellersProjectContext.DepartmentModel'  is null.");
            }
            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            if (departmentModel != null)
            {
                _context.DepartmentModel.Remove(departmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(int id)
        {
          return (_context.DepartmentModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
