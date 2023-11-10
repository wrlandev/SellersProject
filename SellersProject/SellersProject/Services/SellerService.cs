using Microsoft.EntityFrameworkCore;
using SellersProject.Data;
using SellersProject.Models;
using System.Data;

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

        public DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Seller Details";

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Birth Date", typeof(DateTime));
            dataTable.Columns.Add("Base Salary", typeof(double));
            dataTable.Columns.Add("Department", typeof(int));

            var dados = _context.SellerModel.ToList();

            if (dados.Count > 0)
            {
                dados.ForEach(item =>
                {
                    dataTable.Rows.Add(item.Name, item.Email, item.BirthDate, item.BaseSalary, item.Department);
                });
            }

            return dataTable;
        }
    }
}
