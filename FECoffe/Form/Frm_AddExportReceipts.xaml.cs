using FECoffe.DTO.ExportDetail;
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
       // public ObservableCollection<Material> AllMaterials { get; set; }
        public ObservableCollection<ExportDetail> ExportDetails { get; set; } = new();
        public Frm_AddExportReceipts()
        {
            InitializeComponent();
        //    AllMaterials = new ObservableCollection<Material>
        //{
        //    new Material { MaterialID = 1, MaterialName = "Cà phê hạt" },
        //    new Material { MaterialID = 2, MaterialName = "Sữa đặc" },
        //    new Material { MaterialID = 3, MaterialName = "Đường trắng" },
        //    new Material { MaterialID = 4, MaterialName = "Nước lọc" }
        //};

            ExportDetails.Add(new ExportDetail()); // Dòng trống ban đầu

            DataContext = this;
        }
        private void ComboBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string text = comboBox.Text?.ToLower() ?? "";

                //var filtered = AllMaterials
                //    .Where(m => m.MaterialName.ToLower().Contains(text))
                //    .ToList();

                //comboBox.ItemsSource = filtered;
                comboBox.IsDropDownOpen = true;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Thực hiện lưu ExportReceipt và ExportDetails vào DB
            MessageBox.Show("Đã lưu phiếu xuất thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
