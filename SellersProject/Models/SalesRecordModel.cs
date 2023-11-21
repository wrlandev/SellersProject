using SellersProject.Models.Enums;

namespace SellersProject.Models
{
    public class SalesRecordModel
    {
        public  int Id { get; set; }
        public DateTime Date { get; set; }
        public  double Amount { get; set; }
        public SalesStatus Status { get; set; }
        public SellerModel Seller { get; set; }

        public SalesRecordModel()
        {
        }

        public SalesRecordModel(int id, DateTime date, double amount, SalesStatus status, SellerModel seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
