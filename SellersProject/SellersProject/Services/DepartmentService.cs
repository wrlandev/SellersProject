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
        public async Task InsertAsync(DepartmentModel department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<DepartmentModel> FindByIdAsync(int id)
        {
            return await _context.DepartmentModel.Include(department => department.Sellers).FirstOrDefaultAsync(department => department.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var department = await _context.DepartmentModel.FindAsync(id);
            _context.DepartmentModel.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DepartmentModel department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
