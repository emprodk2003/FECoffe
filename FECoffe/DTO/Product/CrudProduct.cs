using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Product
{
    public class CrudProduct
    {
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string UrlImg { get; set; }
    }
}
