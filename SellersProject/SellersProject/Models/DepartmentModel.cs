using System.Collections;

namespace SellersProject.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SellerModel> Sellers { get; set; } = new List<SellerModel>();

        public DepartmentModel()
        {
        }

        public DepartmentModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(SellerModel seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
