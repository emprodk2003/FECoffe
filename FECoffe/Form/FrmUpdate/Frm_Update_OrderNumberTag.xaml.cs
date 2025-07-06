using FECoffe.DTO.OrderNumbertag;
using FECoffe.Request.Table;
using System.Windows;
using System.Windows.Controls;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Suaử thông tin số thẻ thành công.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin số thẻ thất bại!");
                    this.Close();
                }
            }
        }
    }
}
