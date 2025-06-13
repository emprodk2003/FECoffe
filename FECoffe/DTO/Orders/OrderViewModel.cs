using FECoffe.Enum;

namespace FECoffe.DTO.Orders
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
        public int TableNumberID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public bool OrderStatus { get; set; }
        public TransactionStatus PaymentStatus { get; set; }
    }
}
