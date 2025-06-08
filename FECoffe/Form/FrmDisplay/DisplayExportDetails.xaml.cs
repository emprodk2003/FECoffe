using FECoffe.DTO.ExportReceipts;
using FECoffe.Request.ExportReceipts;
using FECoffe.Request.ImportReceipts;
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
    /// Interaction logic for DisplayExportDetails.xaml
    /// </summary>
    public partial class DisplayExportDetails : Window
    {
        public CrudExportReceipts ExportReceipts { get; set; }
        public DisplayExportDetails(CrudExportReceipts crud)
        {
            InitializeComponent( );
            ExportReceipts = crud;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lots = ExportReceiptsRequest.GetExportDetailByReceipID(ExportReceipts.ExportID);
            if (lots != null)
            {
                dgExportDetail.ItemsSource = lots;
            }
            else
                MessageBox.Show("show khong thanh cong");
        }
    }
}
