using FECoffe.DTO.ExportDetail;
using FECoffe.DTO.ExportReceipts;
using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.ImportReceipts;
using FECoffe.DTO.Lots;
using FECoffe.DTO.Material;
using FECoffe.DTO.Suppliers;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.ExportReceipts;
using FECoffe.Request.ImportReceipts;
using FECoffe.Request.Lots;
using FECoffe.Request.Material;
using FECoffe.Request.Supplier;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddExportReceipts.xaml
    /// </summary>
    public partial class Frm_AddExportReceipts : Window
    {
        string userID;
        public ObservableCollection<ExportDetail> ExportDetails = new ObservableCollection<ExportDetail>();
        public Frm_AddExportReceipts()
        {
            InitializeComponent();
            var app = (App)Application.Current;

            userID = app.IdUser;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (cbLot.SelectedItem is CrudLot selectedLot)
            {
                var importReceipts = new CrudExportReceipts()
                {
                    CreatedAt = DateTime.Now,
                    ExportDate = DateTime.Now,
                    Note = txtNote.Text,
                    UserID = Guid.Parse(userID),
                };
                var list = new List<ExportDetail>();
                list = ExportDetails.ToList();
                var create = new CreateExportDTO()
                {
                    Details = list,
                    Receipt = importReceipts
                };
                if (ExportReceiptsRequest.createExport(create) == true)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddMaterialToDetailCommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbLot.SelectedItem is CrudLot selectedLot)
                {
                    if (int.TryParse(txtinventoryquantity.Text, out int inventoryquantity )  &&
                            int.TryParse(txtQuantity.Text, out int quantity))
                    {
                        if (inventoryquantity >= quantity)
                        {
                            var detail = new ExportDetail
                            {
                                LotID = selectedLot.LotID,
                                Quantity = quantity,
                            };

                            ExportDetails.Add(detail);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số lượng dưới hoặc bằng số lượng tồn kho .");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số cho số lượng .");
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

        private void updateexportdetal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lots = LotsRequest.GetLots();
            if (lots != null)
            {
                cbLot.ItemsSource = lots;
            }
            dgExportDetails.ItemsSource = ExportDetails;
        }

        private void dgExportDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedDetail = dgExportDetails.SelectedItem as ExportDetail;
            if (selectedDetail != null)
            {
                // Truyền dữ liệu sang window mới

                var frm = new ExportReciptsDetail(selectedDetail);
                frm.ShowDialog();
                // dgExportDetails.Items.Refresh();
            }
        }

        private void cbLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLot.SelectedItem is CrudLot selectedLot)
            {
                txtinventoryquantity.Text = selectedLot.Quantity.ToString();
            }

        }
    }
}
