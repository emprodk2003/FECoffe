using FECoffe.DTO.Topping;
using FECoffe.Request.Topping;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Thêm topping mới thành công!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm topping mới thất bại!");
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
