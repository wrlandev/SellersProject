using Microsoft.EntityFrameworkCore;
using SellersProject.Data;
using SellersProject.Models;

namespace SellersProject.Services
{
    public class DepartmentService
    {
        private readonly SellersProjectContext _context;
        public DepartmentService(SellersProjectContext context)
        {
            _context = context;
        }
        public async Task<List<DepartmentModel>> FindAllAsync()
        {
            return await _context.DepartmentModel.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
