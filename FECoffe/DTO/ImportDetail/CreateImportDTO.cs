using FECoffe.DTO.ImportReceipts;

namespace FECoffe.DTO.ImportDetail
{
    public class CreateImportDTO
    {
        public CrudImportReceipts Receipt { get; set; }
        public List<CrudImportDetail> Details { get; set; }
    }
}
