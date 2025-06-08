using FECoffe.Dashboards;
using FECoffe.DTO.OrderNumbertag;
using FECoffe.Request.Table;
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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_OrderNumberTag.xaml
    /// </summary>
    public partial class Frm_Update_OrderNumberTag : Window
    {
        private TableViewModel _table;
        public Frm_Update_OrderNumberTag(TableViewModel table)
        {
            InitializeComponent();
            _table = table;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_table != null)
            {
                txtTableName.Text = _table.TableName;
                int status = (int)_table.Status;
                foreach (ComboBoxItem item in cbStatus.Items)
                {
                    if (item.Tag != null && item.Tag.ToString().ToLower() == status.ToString().ToLower())
                    {
                        cbStatus.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text) || cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var selectedItem = cbStatus.SelectedItem as ComboBoxItem;
                int status = 0;              
                if (selectedItem != null && selectedItem.Tag != null)
                {
                    status = int.Parse(selectedItem.Tag.ToString());
                }
                Enum.TableStatus table1 = (Enum.TableStatus)status;
                var table = new TableViewModel()
                {
                    TableName = txtTableName.Text,
                    TableID = _table.TableID,
                    Status = table1,
                };
                if (TableRequest.updateTable(table) == true)
                {
                    MessageBox.Show("Sua thong tin so the ban thanh cong.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua thong tin so the ban that bai!");
                    this.Close();
                }
            }
        }
    }
}
