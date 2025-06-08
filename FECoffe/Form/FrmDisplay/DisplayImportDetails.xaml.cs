using FECoffe.DTO.ImportReceipts;
using FECoffe.Request.ImportReceipts;
using FECoffe.Request.Lots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FECoffe.Form.FrmDisplay
{
    /// <summary>
    /// Interaction logic for DisplayImportDetails.xaml
    /// </summary>
    public partial class DisplayImportDetails : Window
    {
        public CrudImportReceipts ImportReceipts { get; set; }
        public DisplayImportDetails(CrudImportReceipts crud)
        {
            InitializeComponent();
            ImportReceipts = crud;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lots = ImportReceiptsRequest.GetImportDetailByReceipID(ImportReceipts.ImportID);
            if (lots != null)
            {
                dgImportDetail.ItemsSource = lots;
            }
            else
                MessageBox.Show("show khong thanh cong");
        }
    }
}
