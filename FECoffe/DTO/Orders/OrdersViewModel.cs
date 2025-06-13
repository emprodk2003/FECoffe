using FECoffe.Enum;
using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Orders
{
    public class OrdersViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
        public int TableNumberID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public TransactionStatus PaymentStatus { get; set; }
        public string payment
        {
            get
            {
                if (PaymentStatus == TransactionStatus.Offline) return "Tiền mặt";
                else if (PaymentStatus == TransactionStatus.Online) return "Chuyển khoản";
                else return string.Empty;
            }
        }
    }
}
