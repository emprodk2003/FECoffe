using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.ProductSize
{
    public class ProductSizeViewModel
    {
        public int ProductSizeID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string SizeName { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}
