using System.Collections.ObjectModel;
using System.Windows;

namespace FECoffe.AppUsed
{
    /// <summary>
    /// Interaction logic for TheBagNumber.xaml
    /// </summary>
    public partial class TheBagNumber : Window
    {
        public ObservableCollection<Table> Tables { get; set; }
        public string DoanhThuHienThi => $"Doanh Thu Ngày Hôm Nay: {DoanhThu:N0} đ";

        public decimal DoanhThu { get; set; } = 1200000;

        public TheBagNumber()
        {
            InitializeComponent();
            DataContext = this;

            // Sample data
            Tables = new ObservableCollection<Table>
            {
                new Table { TableNumber = "B01", Capacity = 4, Status = TableStatus.Free },
                new Table { TableNumber = "B02", Capacity = 6, Status = TableStatus.Occupied },
                new Table { TableNumber = "B03", Capacity = 2, Status = TableStatus.Occupied },
                new Table { TableNumber = "B04", Capacity = 4, Status = TableStatus.Free },
                new Table { TableNumber = "B05", Capacity = 6, Status = TableStatus.Occupied },
                new Table { TableNumber = "B06", Capacity = 2, Status = TableStatus.Occupied },
                new Table { TableNumber = "B07", Capacity = 4, Status = TableStatus.Free },
                new Table { TableNumber = "B08", Capacity = 6, Status = TableStatus.Occupied },
                new Table { TableNumber = "B09", Capacity = 2, Status = TableStatus.Free },
                // Thêm các bàn khác...
            };

            TablesItemsControl.ItemsSource = Tables;
        }
        public enum TableStatus { Free, Occupied }

        public class Table
        {
            public string TableNumber { get; set; }
            public int Capacity { get; set; }
            public TableStatus Status { get; set; }

            public string StatusDisplay => Status switch
            {
                TableStatus.Free => "Trống",
                TableStatus.Occupied => "Đang chuẩn bị món",
                _ => "Unknown"
            };
        }
    }
}
