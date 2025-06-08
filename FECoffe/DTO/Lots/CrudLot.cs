using FECoffe.DTO.Material;
using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Lots
{
    public class CrudLot
    {
        public int LotID { get; set; }
        [Required]
        public string LotName { get; set; }
        public float Quantity { get; set; }
        public int MaterialID { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public CrudMaterial Materials { get; set; }
    }
}
