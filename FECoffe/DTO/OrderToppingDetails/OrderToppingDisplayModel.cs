namespace FECoffe.DTO.OrderToppingDetails
{
    public class OrderToppingDisplayModel
    {
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }  
        public decimal UnitPrice { get; set; }   
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
