using FECoffe.DTO.OrderDetails;

namespace FECoffe.DTO.Orders
{
    public class CreateOrderDTO
    {
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
        public int TableNumberID { get; set; }
        public decimal Discount { get; set; }
        public int PaymentStatus { get; set; }

        public List<CreateOrderDetailsDTO> orderDetails { get; set; }
    }
}
