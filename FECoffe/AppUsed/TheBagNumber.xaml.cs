using FECoffe.DTO.OrderDetails;
using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Orders;
using FECoffe.DTO.Positions;
using FECoffe.DTO.Product;
using FECoffe.Request.Orders;
using FECoffe.Request.Positions;
using FECoffe.Request.Table;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FECoffe.AppUsed
{
    /// <summary>
    /// Interaction logic for TheBagNumber.xaml
    /// </summary>
    public partial class TheBagNumber : Window
    {
        public TheBagNumber()
        {
            InitializeComponent();
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
            //loaddTagNumber();
            //if (TablesItemsControl == null)
            //{
            //    MessageBox.Show("TablesItemsControl chưa được khởi tạo!");
            //    return;
            //}

            //cbTableFilter.SelectedIndex = 2; // Gọi sau khi UI đã load xong
            loaddTagNumber();
            loadOrderLog();
            UpdateTotalAmountFinal();
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

        private void numbertag_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = sender as FrameworkElement;
            var selectedTag = item.DataContext as TableViewModel;
            var updatetable = TableRequest.updateTableByStatus(selectedTag.TableID, 0);
            MessageBox.Show("Da cap nhat trang thai the");
            loaddTagNumber();
        }
        public void loadOrderLog()
        {
            var list = OrderRequest.GetOrderByDay();
            if (list != null)
            {
                dgOrderLogs.ItemsSource = list;
                UpdateTotalAmountFinal();
            }
            else
                MessageBox.Show("Không có dữ liệu ngày hôm nay");
        }

        private void UpdateTotalAmountFinal()
        {
            var items = dgOrderLogs.ItemsSource as IEnumerable<OrdersViewModel>;
            if (items != null)
            {
                decimal total = items.Sum(item => item.FinalAmount);
                txtAmountFinal.Text = $"{total:N0} đ";
            }
            else
            {
                txtAmountFinal.Text = "0 đ";
            }
        }

        private void cbTableFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TablesItemsControl == null)
                return;
            var selectedItem = cbTableFilter.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                var list=new List<TableViewModel>();
                int value = int.Parse(selectedItem.Tag.ToString());

                if(value==0)
                {
                    list=TableRequest.GetOrderNumberTagByStatus(value);
                    TablesItemsControl.ItemsSource = list;
                }
                if(value==1)
                {
                    list = TableRequest.GetOrderNumberTagByStatus(value);
                    TablesItemsControl.ItemsSource = list;
                }
                if (value == 2)
                {
                    loaddTagNumber();
                }

            }

        }
    }
}
