using FECoffe.DTO.ExportReceipts;

namespace FECoffe.DTO.ExportDetail
{
    public class CreateExportDTO
    {
        public CrudExportReceipts Receipt { get; set; }
        public List<ExportDetail> Details { get; set; }
    }
}
