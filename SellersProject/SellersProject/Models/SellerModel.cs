using System.ComponentModel.DataAnnotations;

namespace SellersProject.Models
{
    public class SellerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        public DepartmentModel Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public ICollection<SalesRecordModel> Sales { get; set; } = new List<SalesRecordModel>();

        public SellerModel()
        {
        }

        public SellerModel(int id, string name, string email, DateTime birthDate, double baseSalary, DepartmentModel department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecordModel sales)
        {
            Sales.Add(sales);
        }

        public void RemoveSales(SalesRecordModel sales)
        {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime inital, DateTime final)
        {
            return Sales.Where(sales => sales.Date >= inital && sales.Date <= final).Sum(sales => sales.Amount);
        }
    }
}
