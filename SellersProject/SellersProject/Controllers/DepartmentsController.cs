using Microsoft.AspNetCore.Mvc;
using SellersProject.Models;
using SellersProject.Services;

namespace SellersProject.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _departmentService;
        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _departmentService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentModel department)
        {
            await _departmentService.InsertAsync(department);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.FindByIdAsync(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.FindByIdAsync(id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentModel department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            await _departmentService.UpdateAsync(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
