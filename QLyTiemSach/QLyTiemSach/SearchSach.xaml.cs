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

namespace QLyTiemSach
{
    /// <summary>
    /// Interaction logic for SearchSach.xaml
    /// </summary>
    public partial class SearchSach : Window
    {
        public string TieuChi { get; private set; }
        public string TuKhoa { get; private set; }

        public SearchSach()
        {
            InitializeComponent();
        }

        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            TieuChi = (cbTieuChi.SelectedItem as ComboBoxItem).Content.ToString();
            TuKhoa = txtTuKhoa.Text;
            this.DialogResult = true; // báo cho window cha biết có dữ liệu
            this.Close();
        }
    }
}
