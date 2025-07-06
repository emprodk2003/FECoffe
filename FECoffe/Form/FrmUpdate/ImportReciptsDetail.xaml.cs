using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.Material;
using FECoffe.Request.Material;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for ImportReciptsDetail.xaml
    /// </summary>
    public partial class ImportReciptsDetail : Window
    {
        public CrudImportDetail crudImportDetail;
        public int SupplierID { get; set; }
        public ImportReciptsDetail(CrudImportDetail detail)
        {
            InitializeComponent();
            crudImportDetail = detail;

            var mate = MaterialRequest.GetMaterialByID(crudImportDetail.MaterialID);

            SupplierID = mate.SupplierID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var Material = MaterialRequest.GetMaterialBySuppliersID(SupplierID);
            if (Material != null)
            {
                cbMaterial.ItemsSource = Material;
                var selectedMaterial = Material.FirstOrDefault(m => m.MaterialID == crudImportDetail.MaterialID);
                cbMaterial.SelectedItem = selectedMaterial;
            }
            txtQuantity.Text = crudImportDetail.Quantity.ToString();
            txtPrice.Text = crudImportDetail.Price.ToString();
            dpExpiration.SelectedDate = crudImportDetail.ExpirationDate.HasValue
                ? crudImportDetail.ExpirationDate.Value.ToDateTime(TimeOnly.MinValue)
                : (DateTime?)null;
        }

        private void EditMaterialToDetailCommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng đã chọn nguyên vật liệu từ ComboBox
                if (cbMaterial.SelectedItem is CrudMaterial selectedMaterial)
                {
                    // Kiểm tra nếu người dùng nhập đúng định dạng số cho số lượng và đơn giá
                    if (int.TryParse(txtQuantity.Text, out int quantity) &&
                        decimal.TryParse(txtPrice.Text, out decimal price))
                    {
                        // Tạo một đối tượng CrudImportDetail mới để lưu trữ dữ liệu đã chỉnh sửa
                        crudImportDetail.MaterialID = selectedMaterial.MaterialID;
                        crudImportDetail.Quantity = quantity;
                        crudImportDetail.Price = price;
                        crudImportDetail.TotalPrice = quantity * price;
                        crudImportDetail.ExpirationDate = dpExpiration.SelectedDate.HasValue
                            ? DateOnly.FromDateTime(dpExpiration.SelectedDate.Value)
                            : null;
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
    }
}
