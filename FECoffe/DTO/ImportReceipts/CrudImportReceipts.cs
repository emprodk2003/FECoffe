namespace FECoffe.DTO.ImportReceipts
{
    public class CrudImportReceipts
    {
        public int ImportID { get; set; }
        public int SupplierID { get; set; }
        public DateTime? ImportDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserID { get; set; }
    }
}
