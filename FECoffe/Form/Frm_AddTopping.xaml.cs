using FECoffe.DTO.Topping;
using FECoffe.Request.Topping;
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
    /// Interaction logic for Frm_AddTopping.xaml
    /// </summary>
    public partial class Frm_AddTopping : Window
    {
        public Frm_AddTopping()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtToppingName.Text) || string.IsNullOrWhiteSpace(txtToppingPrice.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else if (!decimal.TryParse(txtToppingPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá không hợp lệ!");
            }
            else
            {
                var top = new CrudTopping()
                {
                    ToppingName = txtToppingName.Text,
                    Price = decimal.Parse(txtToppingPrice.Text),
                    IsAvailable = chkIsAvailable.IsChecked.Value
                };
                if (ToppingRequest.createTopping(top) == true)
                {
                    MessageBox.Show("Them topping moi thanh cong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them topping moi that bai!");
                    this.Close();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
