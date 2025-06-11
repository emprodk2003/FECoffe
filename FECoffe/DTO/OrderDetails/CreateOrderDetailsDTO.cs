using FECoffe.DTO.OrderToppingDetails;

namespace FECoffe.DTO.OrderDetails
{
    public class CreateOrderDetailsDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public List<CreateOrderToppingDetail> OrderToppingDetails { get; set; }
    }
}
