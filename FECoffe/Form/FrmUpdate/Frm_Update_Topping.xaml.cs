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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_Topping.xaml
    /// </summary>
    public partial class Frm_Update_Topping : Window
    {
        private ToppingViewModel _topping;
        public Frm_Update_Topping(ToppingViewModel topping )
        {
            InitializeComponent();
            _topping = topping;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtToppingName.Text) || string.IsNullOrWhiteSpace(txtToppingPrice.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else if (!decimal.TryParse(txtToppingPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá không hợp lệ!");
            }
            else
            {
                var top = new ToppingViewModel()
                {
                    ToppingID = _topping.ToppingID,
                    ToppingName = txtToppingName.Text,
                    Price = decimal.Parse(txtToppingPrice.Text),
                    IsAvailable = chkIsAvailable.IsChecked.Value
                };
                if (ToppingRequest.updateTopping(top) == true)
                {
                    MessageBox.Show("Sua thong tin topping moi thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua thong tin topping moi that bai!");
                    this.Close();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_topping != null)
            {
                txtToppingName.Text = _topping.ToppingName;
                txtToppingPrice.Text = _topping.Price.ToString();
                chkIsAvailable.IsChecked = _topping.IsAvailable;
            }
        }
    }
}
