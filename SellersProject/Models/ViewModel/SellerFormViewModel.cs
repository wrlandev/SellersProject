namespace SellersProject.Models.ViewModel
{
    public class SellerFormViewModel
    {
        public SellerModel Seller { get; set; }
        public ICollection<DepartmentModel> Departments { get; set; }
    }
}
