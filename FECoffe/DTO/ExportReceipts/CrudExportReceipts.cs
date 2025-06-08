namespace FECoffe.DTO.ExportReceipts
{
    public class CrudExportReceipts
    {
        public int ExportID { get; set; }
        public DateTime ExportDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserID { get; set; }
    }
}
