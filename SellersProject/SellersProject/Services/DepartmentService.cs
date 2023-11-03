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
        public List<DepartmentModel> FindAll()
        {
            return _context.DepartmentModel.OrderBy(x => x.Name).ToList();
        }
    }
}
