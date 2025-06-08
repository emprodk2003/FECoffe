using FECoffe.DTO.ExportDetail;
using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.Lots;
using FECoffe.DTO.Material;
using FECoffe.Request.Lots;
using FECoffe.Request.Material;
using System.Windows;


namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for ExportReciptsDetail.xaml
    /// </summary>
    public partial class ExportReciptsDetail : Window
    {
        public ExportDetail crudExportDetail;
        public ExportReciptsDetail(ExportDetail detail)
        {
            InitializeComponent();
            crudExportDetail= detail;
            var lot = LotsRequest.GetLotById(crudExportDetail.LotID);
            this.DataContext = crudExportDetail;
        }

        private void EditMaterialToDetailCommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng đã chọn nguyên vật liệu từ ComboBox
                if (cbLot.SelectedItem is CrudLot selectedLot)
                {
                    // Kiểm tra nếu người dùng nhập đúng định dạng số cho số lượng và đơn giá
                    if (int.TryParse(txtQuantity.Text, out int quantity))
                    {
                        // Tạo một đối tượng CrudImportDetail mới để lưu trữ dữ liệu đã chỉnh sửa
                        crudExportDetail.LotID = selectedLot.LotID;
                        crudExportDetail.Quantity = quantity;
                        // Đóng form ImportReciptsDetail sau khi cập nhật
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số cho số lượng và đơn giá.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nguyên vật liệu.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lots = LotsRequest.GetLots();
            if (lots != null)
            {
                cbLot.ItemsSource = lots;
                var selectedMaterial = lots.FirstOrDefault(m => m.LotID == crudExportDetail.LotID);
                cbLot.SelectedItem = selectedMaterial;
            }
            txtQuantity.Text = crudExportDetail.Quantity.ToString();

        }
    }
}
