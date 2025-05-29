using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Suppliers
{
    public class CrudSuppliers
    {
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        // public List<ImportReceipts> ImportReceipts { get; set; }
        public string CreatedAtFormatted => CreatedAt.ToString("dd/MM/yyyy");
        public string UpdatedAtFormatted => UpdatedAt.ToString("dd/MM/yyyy");
    }
}
