using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Positions;
using FECoffe.DTO.Product;
using FECoffe.Request.Positions;
using FECoffe.Request.Table;
using System.Collections.ObjectModel;
using System.Windows;

namespace FECoffe.AppUsed
{
    /// <summary>
    /// Interaction logic for TheBagNumber.xaml
    /// </summary>
    public partial class TheBagNumber : Window
    {
      
        public string DoanhThuHienThi => $"Doanh Thu Ngày Hôm Nay: {DoanhThu:N0} đ";

        public decimal DoanhThu { get; set; } = 1200000;

        public TheBagNumber()
        {
            InitializeComponent();
            //DataContext = this;

            //// Sample data
            //Tables = new ObservableCollection<Table>
            //{
            //    new Table { TableNumber = "B01", Capacity = 4, Status = TableStatus.Free },
            //    new Table { TableNumber = "B02", Capacity = 6, Status = TableStatus.Occupied },
            //    new Table { TableNumber = "B03", Capacity = 2, Status = TableStatus.Occupied },
            //    new Table { TableNumber = "B04", Capacity = 4, Status = TableStatus.Free },
            //    new Table { TableNumber = "B05", Capacity = 6, Status = TableStatus.Occupied },
            //    new Table { TableNumber = "B06", Capacity = 2, Status = TableStatus.Occupied },
            //    new Table { TableNumber = "B07", Capacity = 4, Status = TableStatus.Free },
            //    new Table { TableNumber = "B08", Capacity = 6, Status = TableStatus.Occupied },
            //    new Table { TableNumber = "B09", Capacity = 2, Status = TableStatus.Free },
            //    // Thêm các bàn khác...
            //};

            //TablesItemsControl.ItemsSource = Tables;
        }
        public enum TableStatus { Free, Occupied }


        public void loaddTagNumber()
        {
            var listtag = TableRequest.GetAllTable();
            if(listtag != null )
            {
                TablesItemsControl.ItemsSource = listtag;
            }
            else
            {
                TablesItemsControl = null;
                MessageBox.Show("Khong tim thay danh sach tagnumber");
            }
            
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaddTagNumber();
        }



        private void numbertag_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as FrameworkElement;
            var selectedTag = item.DataContext as TableViewModel;
            if(selectedTag.Status == Enum.TableStatus.Available)
            {
                Order order = new Order(selectedTag);
                order.Show();
                this.Close();
                loaddTagNumber();
            }
            else if(selectedTag.Status == Enum.TableStatus.Occupied)
            {
                var result = MessageBox.Show(
                    "Xác nhận đã hoàn thành thực đơn?",
                    "Xác nhận hoàn thành",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.Yes)
                {
                    var tagnumber = new TableViewModel()
                    {
                        TableID = selectedTag.TableID,
                        TableName = selectedTag.TableName,
                        Status = Enum.TableStatus.Available,
                    };
                    if (TableRequest.updateTable(tagnumber) == true)
                    {
                        MessageBox.Show("Đã hoàn thành.");
                        loaddTagNumber();
                    }
                    else MessageBox.Show("Loi khi xác nhận!");
                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void numbertag_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void numbertag_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = sender as FrameworkElement;
            var selectedTag = item.DataContext as TableViewModel;
            var updatetable = TableRequest.updateTableByStatus(selectedTag.TableID, 0);
            MessageBox.Show("Da cap nhat trang thai the");
            loaddTagNumber();
        }
    }
}
