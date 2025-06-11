using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Topping;

namespace FECoffe.DTO.Orders
{
    public class ProductSizeAndToppingsDTO
    {
        public ProductSizeViewModel ProductSize { get; set; }
        public List<ToppingViewModel> Toppings { get; set; }
    }
}
