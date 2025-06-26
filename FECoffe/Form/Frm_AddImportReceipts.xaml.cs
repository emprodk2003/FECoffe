using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.ImportReceipts;
using FECoffe.DTO.Material;
using FECoffe.DTO.Suppliers;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.ImportReceipts;
using FECoffe.Request.Material;
using FECoffe.Request.Supplier;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddImportReceipts.xaml
    /// </summary>
    public partial class Frm_AddImportReceipts : Window
    {

        public ObservableCollection<CrudImportDetail> ExportDetails { get; set; }
        public int SupplierID { get; set; }
        public ObservableCollection<CrudImportDetail> ImportDetail = new ObservableCollection<CrudImportDetail>();
        string userID;
        public Frm_AddImportReceipts()
        {
            InitializeComponent();
            var app = (App)Application.Current;

            userID = app.IdUser;

            ExportDetails = new ObservableCollection<CrudImportDetail>();

            // Bind ObservableCollection to DataGrid
            dgImportDetails.ItemsSource = ExportDetails;
        }
        public void UpdateDetail(CrudImportDetail updatedDetail)
        {
            // Tìm item cần cập nhật trong ExportDetails
            var detail = ExportDetails.FirstOrDefault(d => d.MaterialID == updatedDetail.MaterialID);
            if (detail != null)
            {
                // Cập nhật thông tin
                detail.Quantity = updatedDetail.Quantity;
                detail.Price = updatedDetail.Price;
                detail.TotalPrice = updatedDetail.TotalPrice;
                detail.ExpirationDate = updatedDetail.ExpirationDate;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var supplier = SupplierRequest.GetSupplier();
            if (supplier != null)
            {
                cbSupplier.ItemsSource = supplier;
            }
            dgImportDetails.ItemsSource = ImportDetail;
        }

        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSupplier.SelectedValue != null)
            {
                int selectedSupplierId = (int)cbSupplier.SelectedValue;

                var materials = MaterialRequest.GetMaterialBySuppliersID(selectedSupplierId);
                if (materials != null)
                {
                    cbMaterial.ItemsSource = materials;
                }
                else
                {
                    cbMaterial.ItemsSource = null;
                }
            }
        }

        private void AddMaterialToDetailCommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbMaterial.SelectedItem is CrudMaterial selectedMaterial)
                {
                    // Gán giá trị với kiểm tra đúng
                    bool isQuantityValid = int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0;
                    bool isPriceValid = decimal.TryParse(txtPrice.Text, out decimal price) && price > 0;

                    if (isQuantityValid && isPriceValid)
                    {
                        var detail = new CrudImportDetail
                        {
                            MaterialID = selectedMaterial.MaterialID,
                            Quantity = quantity,
                            Price = price,
                            TotalPrice = quantity * price,
                            ExpirationDate = dpExpiration.SelectedDate.HasValue
                                ? DateOnly.FromDateTime(dpExpiration.SelectedDate.Value)
                                : null
                        };

                        ImportDetail.Add(detail);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng và giá trị > 0 cho số lượng và đơn giá.");
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

        private void luu_Click(object sender, RoutedEventArgs e)
        {

            if (cbSupplier.SelectedItem is CrudSuppliers selectedSuppliers)
            {

                var importReceipts = new CrudImportReceipts()
                {
                    CreatedAt = DateTime.Now,
                    ImportDate = ExportDatePicker.SelectedDate,
                    Note = txtNote.Text,
                    SupplierID = selectedSuppliers.SupplierID,
                    UserID = Guid.Parse(userID),
                };
                var list = new List<CrudImportDetail>();
                list = ImportDetail.ToList();
                var create = new CreateImportDTO()
                {
                    Details = list,
                    Receipt = importReceipts
                };
                if (ImportReceiptsRequest.createImport(create) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
            else MessageBox.Show("Chưa nhà cung cấp");
        }

        private void dgImportDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updateimpordetal_Click(object sender, RoutedEventArgs e)
        {
            //var selectedDetail = dgImportDetails.SelectedItem as Frm_AddImportReceipts;
            var selectedDetail = dgImportDetails.SelectedItem as CrudImportDetail;
            if (selectedDetail != null)
            {
                // Truyền dữ liệu sang window mới

                var frm = new ImportReciptsDetail(selectedDetail);
                frm.ShowDialog();
                dgImportDetails.Items.Refresh();
            }

        }
    }
}
