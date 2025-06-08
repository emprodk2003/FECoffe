using FECoffe.Enum;

namespace FECoffe.DTO.OrderNumbertag
{
    public class TableViewModel
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public TableStatus Status { get; set; }
        public string trangthai
        {
            get
            {
                
                if (Status == TableStatus.Available) return "Trong";
                else if (Status == TableStatus.Occupied) return "Dang su dung";
                else if (Status == TableStatus.OutOfService) return "Ngung su dung";
                else return string.Empty;
            }
        }
    }
}
