using FECoffe.DTO.Banks;
using FECoffe.DTO.Orders;
using FECoffe.Enum;
using FECoffe.Request.Banks;
using FECoffe.Request.Orders;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
        public Frm_CreateQR(CreateOrderDTO orderDTO ,decimal thanhtien)
        {
            InitializeComponent();
            CreateOrderDTO = orderDTO;
            totalAmount=thanhtien;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load();
            txtContent.Text = CreateOrderDTO.CodeOrder;
            txtAmount.Text = totalAmount.ToString();
        }
        public async Task load()
        {

            cbBank.ItemsSource = new List<string> { "Đang tải danh sách..." };
            var banks = await BankRequest.GetAllBanksCachedAsync();
            if (banks != null)
            {
                cbBank.ItemsSource = banks?.data;
            }
            else
            {
                MessageBox.Show("Khong co du lieu");
            }
        }

        private void createQR_Click(object sender, RoutedEventArgs e)
        {
            if (cbBank.SelectedItem is Datum selectedBank)
            {
                txtContent.Text = CreateOrderDTO.CodeOrder;
                txtAmount.Text = totalAmount.ToString("0"); //format lai tu 25000.00 =>25000
                var result = new ApiRequest()
                {
                    accountNo = txtNumberAccountBank.Text,
                    accountName = txtAccountBank.Text,
                    acqId = int.Parse(selectedBank.bin),
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
                MessageBox.Show("Cap nhat trang thai hoan thanh don hang");
                this.Close();
            }
            else
                MessageBox.Show("Cap nhat trang thai that bai don hang");
            
        }

        private void cash_Click(object sender, RoutedEventArgs e)
        {
            var order = OrderRequest.GetOrderByCodeOrder(CreateOrderDTO.CodeOrder);
            if (order != null)
            {
                order.PaymentStatus = (TransactionStatus)1;
                var updateorder = OrderRequest.BankTransferToCash(order.OrderID, order.PaymentStatus, true);
                MessageBox.Show("Cap nhat doi phuong thuc thanh toan va trang thai hoan thanh don hang thanh cong");
                this.Close();
            }
            else
                MessageBox.Show("Cap nhat doi phuong thuc thanh toan va trang thai hoan thanh don hang that bai");
        }
    }
}
