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
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class KhachHang : Window
    {
        QLyTiemSachEntities db = new QLyTiemSachEntities();
        private KHACHHANG khDangChon;
        private void loadData()
        {
            DG_BangDuLieuKH.ItemsSource = db.KHACHHANGs.ToList();
        }

        private void XoaTrang()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            cbxLuaChon.SelectedIndex = -1;
            txtKeyword.Clear();
            khDangChon = null;
        }

        public KhachHang()
        {
            InitializeComponent();
            loadData();
        }

        private void DG_BangDuLieuKH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            khDangChon = DG_BangDuLieuKH.SelectedItem as KHACHHANG;
            if (khDangChon != null)
            {
                txtMaKH.Text = khDangChon.MaKH;
                txtTenKH.Text = khDangChon.TenKH;
                txtDiaChi.Text = khDangChon.DiaChi;
                txtSDT.Text = khDangChon.SDT;
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            KHACHHANG kh = new KHACHHANG
            {
                MaKH = txtMaKH.Text.Trim(),
                TenKH = txtTenKH.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SDT = txtSDT.Text.Trim()
            };
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (db.KHACHHANGs.Any(x => x.MaKH == maKH))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại!", "Thông báo",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            MessageBox.Show("Đã thêm khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            loadData();
            XoaTrang();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (khDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.Find(khDangChon.MaKH);
                if (kh.MaKH != txtMaKH.Text.Trim())
                {
                    MessageBox.Show("Không thể sửa mã khách hàng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    kh.TenKH = txtTenKH.Text.Trim();
                    kh.DiaChi = txtDiaChi.Text.Trim();
                    kh.SDT = txtSDT.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("Đã sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                loadData();
                XoaTrang();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (khDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                db.KHACHHANGs.Remove(khDangChon);
                db.SaveChanges();
                MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                loadData();
                XoaTrang();
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Load lại dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            loadData();
            XoaTrang();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtKeyword.Text.Trim().ToLower();
            List<KHACHHANG> ketqua = new List<KHACHHANG>();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string luaChon = (cbxLuaChon.SelectedItem as ComboBoxItem).Content.ToString();

            foreach (KHACHHANG kh in db.KHACHHANGs)
            {
                if (luaChon == "Mã khách hàng" && kh.MaKH != null && kh.MaKH.ToLower().Contains(keyword))
                    ketqua.Add(kh);
                else if (luaChon == "Tên khách hàng" && kh.TenKH != null && kh.TenKH.ToLower().Contains(keyword))
                    ketqua.Add(kh);
                else if (luaChon == "Địa chỉ" && kh.DiaChi != null && kh.DiaChi.ToLower().Contains(keyword))
                    ketqua.Add(kh);
                else if (luaChon == "Số điện thoại" && kh.SDT != null && kh.SDT.ToLower().Contains(keyword))
                    ketqua.Add(kh);
            }

            if (ketqua.Count > 0)
            {
                DG_BangDuLieuKH.ItemsSource = ketqua;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
