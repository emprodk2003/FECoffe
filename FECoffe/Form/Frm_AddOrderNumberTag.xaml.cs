using FECoffe.DTO.OrderNumbertag;
using FECoffe.Request.Table;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddOrderNumberTag.xaml
    /// </summary>
    public partial class Frm_AddOrderNumberTag : Window
    {
        public Frm_AddOrderNumberTag()
        {
            InitializeComponent();
        }

        private void themban_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else
            {
                var table = new CrudTable()
                {
                    TableName = txtTableName.Text,
                    Status = Enum.TableStatus.Available
                };
                if (TableRequest.createTable(table) == true)
                {
                    MessageBox.Show("Thêm số thẻ order mới thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm số thẻ order mới thất bại.");
                    this.Close();
                }
            }
        }
    }
}
