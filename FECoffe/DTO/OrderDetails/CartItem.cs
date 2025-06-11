using FECoffe.DTO.OrderToppingDetails;

namespace FECoffe.DTO.OrderDetails
{
    public class CartItem
    {
        public string Name { get; set; }          
        public string Topping { get; set; }      
        public int Quantity { get; set; }         
        public decimal Price { get; set; }        
        public decimal Total { get; set; }

        public int ProductID { get; set; }
        public int ProductSizeID { get; set; }
        public List<CreateOrderToppingDetail> Toppings { get; set; }
    }
}
