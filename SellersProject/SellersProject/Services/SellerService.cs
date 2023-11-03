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

        public List<SellerModel> FindAll()
        {
            return _context.SellerModel.ToList();
        }

        public void Insert(SellerModel seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public SellerModel FindById(int id)
        {
            return _context.SellerModel.Include(seller => seller.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var seller = _context.SellerModel.Find(id);
            _context.SellerModel.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(SellerModel seller)
        {
            _context.Update(seller);
            _context.SaveChanges();
        }
    }
}
