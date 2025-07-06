using FECoffe.DTO.Topping;
using FECoffe.Request.Topping;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Sửa thông tin cho topping thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa thông tin cho topping!");
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
