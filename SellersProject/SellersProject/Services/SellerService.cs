using Microsoft.EntityFrameworkCore;
using SellersProject.Data;
using SellersProject.Models;

namespace SellersProject.Services
{
    public class SellerService
    {
        private readonly SellersProjectContext _context;
        public SellerService(SellersProjectContext context)
        {
            _context = context;
        }

        public async Task<List<SellerModel>> FindAllAsync()
        {
            return await _context.SellerModel.ToListAsync();
        }

        public async Task InsertAsync(SellerModel seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<SellerModel> FindByIdAsync(int id)
        {
            return await _context.SellerModel.Include(seller => seller.Department).FirstOrDefaultAsync(seller => seller.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var seller = await _context.SellerModel.FindAsync(id);
            _context.SellerModel.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SellerModel seller)
        {
            _context.Update(seller);
            await _context.SaveChangesAsync();
        }
    }
}
