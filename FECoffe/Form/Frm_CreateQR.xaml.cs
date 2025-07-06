using FECoffe.DTO.Banks;
using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Orders;
using FECoffe.Enum;
using FECoffe.Request.Orders;
using FECoffe.Request.Table;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_CreateQR.xaml
    /// </summary>
    public partial class Frm_CreateQR : Window
    {
        public CreateOrderDTO CreateOrderDTO { get; set; }
        private decimal totalAmount;
        public TableViewModel ViewModel { get; set; }
        public Frm_CreateQR(CreateOrderDTO orderDTO ,decimal thanhtien,TableViewModel tableViewModel)
        {
            InitializeComponent();
            CreateOrderDTO = orderDTO;
            totalAmount=thanhtien;
            ViewModel = tableViewModel;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load();
            txtContent.Text = CreateOrderDTO.CodeOrder;
            txtAmount.Text = totalAmount.ToString();
            txtNumberAccountBank.Text = "0393259262";
            txtAccountBank.Text = "NGUYEN HUYNH DUC DUY";
            txtNumberBank.Text = "Ngân Hàng MB Bank";
            createQR();
        }
        public async Task load()
        {

            //cbBank.ItemsSource = new List<string> { "Đang tải danh sách..." };
            //var banks = await BankRequest.GetAllBanksCachedAsync();
            //if (banks != null)
            //{
            //    cbBank.ItemsSource = banks?.data;
            //}
            //else
            //{
            //    MessageBox.Show("Khong co du lieu");
            //}
        }
        public void createQR()
        {
            txtContent.Text = CreateOrderDTO.CodeOrder;
            txtAmount.Text = totalAmount.ToString("0"); //format lai tu 25000.00 =>25000
            txtNumberAccountBank.Text = "0393259262";

            var result = new ApiRequest()
            {
                accountNo = txtNumberAccountBank.Text,
                accountName = txtAccountBank.Text,
                acqId = 970422,
                amount = int.Parse(txtAmount.Text),
                addInfo = txtContent.Text,
                format = "text",
                template = "qr_only"
            };
            var jsonRequest = JsonConvert.SerializeObject(result);
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiRespond>(content);

            anhQR.Source = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
        }

        public ImageSource Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(imageBytes))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                bitmap.Freeze(); // Tùy chọn: để dùng được trên nhiều thread

                //var image = new System.Windows.Controls.Image();
                //image.Source = bitmap;
                return bitmap;
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            var order = OrderRequest.GetOrderByCodeOrder(CreateOrderDTO.CodeOrder);
            if (order != null)
            {
                var updateorder = OrderRequest.UpdateOrderByOrderStatus(order.OrderID, true);
                MessageBox.Show("Cập nhật trạng thái hoàn thành đơn hàng");
                var table = TableRequest.GetTableById(ViewModel.TableID);
                var updatetable = TableRequest.updateTableByStatus(table.TableID, 1);
                this.Close();
            }
            else
                MessageBox.Show("Cập nhật trang thái đơn hàng thất bại");
            
        }

        private void cash_Click(object sender, RoutedEventArgs e)
        {
            var order = OrderRequest.GetOrderByCodeOrder(CreateOrderDTO.CodeOrder);
            if (order != null)
            {
                order.PaymentStatus = (TransactionStatus)1;
                var updateorder = OrderRequest.BankTransferToCash(order.OrderID, order.PaymentStatus, true);
                MessageBox.Show("Cập nhật đổi phương thức thanh toán và trạng thái hoàn thành đơn hàng thành công");
                var table = TableRequest.GetTableById(ViewModel.TableID);
                var updatetable = TableRequest.updateTableByStatus(table.TableID, 1);
                this.Close();
            }
            else
                MessageBox.Show("Cập nhật đổi phương thức thanh toán và trạng thái hoàn thành đơn hàng thất bại");
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            var order = OrderRequest.GetOrderByCodeOrder(CreateOrderDTO.CodeOrder);

            if (order != null)
            {
                // Truyền dữ liệu sang window mới
                if (OrderRequest.deleteOrder(order.OrderID) == true)
                {
                    MessageBox.Show("Xóa Thành Công đơn hàng ");
                    this.Close();
                }
                else MessageBox.Show("Xóa Thất Bại đơn hàng ");

            }
        }
    }
}
