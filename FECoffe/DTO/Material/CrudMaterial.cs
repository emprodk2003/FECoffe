using FECoffe.DTO.User;
using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Material
{
    public class CrudMaterial
    {
        [Required]
        public int MaterialID { get; set; }
        [Required]
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int MinStock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public float Quantity { get; set; }
        public int TotalMaterial { get; set; }
        public decimal PurchasePrice { get; set; }
        public Guid UserID { get; set; }
        public GetUser User { get; set; }
        public DateTime ExpirationDate { get; set; }
        //public Categories_Material Categories_Material { get; set; }
        //public List<ExportDetails> ExportDetails { get; set; }
        //public List<ImportDetails> ImportDetails { get; set; }
        //public List<InventoryLogs> InventoryLogs { get; set; }
        //public List<Recipes> Recipes { get; set; }
    }
}
