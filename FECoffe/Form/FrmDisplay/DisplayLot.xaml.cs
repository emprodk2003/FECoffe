using FECoffe.DTO.Material;
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
    /// Interaction logic for DisplayLot.xaml
    /// </summary>
    public partial class DisplayLot : Window
    {
        private CrudMaterial _material;
        public DisplayLot(CrudMaterial crud)
        {
            InitializeComponent();
            _material = crud;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lots= LotsRequest.GetLotByMaterialID(_material.MaterialID);
            if (lots != null)
            {
                dgLot.ItemsSource = lots;
            }
            else
                MessageBox.Show("show khong thanh cong");
        }
    }
}
