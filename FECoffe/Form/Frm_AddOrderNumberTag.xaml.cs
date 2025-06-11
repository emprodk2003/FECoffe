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
                MessageBox.Show("Vui long dien thong tin!");
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
                    MessageBox.Show("Them so the order moi thanh cong.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them so the order moi that bai.");
                    this.Close();
                }
            }
        }
    }
}
