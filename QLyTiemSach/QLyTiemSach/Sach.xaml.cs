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
    /// Interaction logic for Sach.xaml
    /// </summary>
    public partial class Sach : Window
    {
        QLyTiemSachEntities db = new QLyTiemSachEntities();

        public Sach()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgSach.ItemsSource = db.SACHes.ToList();
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SACH sach = new SACH
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = txtTenSach.Text.Trim(),
                    TacGia = txtTacGia.Text.Trim(),
                    TheLoai = txtTheLoai.Text.Trim(),
                    GiaBan = int.Parse(txtGiaBan.Text),
                    SoLuong = int.Parse(txtSoLuong.Text)
                };

                db.SACHes.Add(sach);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm thành công!");
                ClearForm();
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm sách, vui lòng kiểm tra lại dữ liệu đã nhập!");
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgSach.SelectedItems is SACH sach)
            {
                sach.TenSach = txtTenSach.Text;
                sach.TacGia = txtTacGia.Text;
                sach.TheLoai = txtTheLoai.Text;
                sach.GiaBan = int.Parse(txtGiaBan.Text);
                sach.SoLuong = int.Parse(txtSoLuong.Text);

                db.SaveChanges();
                LoadData();
                MessageBox.Show("Cập nhật sách thành công!");
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtTheLoai.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
        }

        private void dgSach_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgSach.SelectedItem is SACH sach)
            {
                txtMaSach.Text = sach.MaSach;
                txtTenSach.Text = sach.TenSach;
                txtTacGia.Text = sach.TacGia;
                txtTheLoai.Text = sach.TheLoai;
                txtGiaBan.Text = sach.GiaBan.ToString();
                txtSoLuong.Text = sach.SoLuong.ToString();
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgSach.SelectedItem is SACH sach)
            {
                if (MessageBox.Show("Bạn muốn xoá sách này?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.SACHes.Remove(sach);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xoá thành công!");
                    ClearForm();
                }
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            SearchSach searchWindow = new SearchSach();
            if (searchWindow.ShowDialog() == true)  // khi bấm Tìm kiếm ở window con
            {
                string tieuchi = searchWindow.TieuChi;
                string tukhoa = searchWindow.TuKhoa.ToLower();

                IEnumerable<SACH> ketQua = null;

                switch (tieuchi)
                {
                    case "Mã Sách":
                        ketQua = db.SACHes.Where(s => s.MaSach.ToLower().Contains(tukhoa));
                        break;
                    case "Tên Sách":
                        ketQua = db.SACHes.Where(s => s.TenSach.ToLower().Contains(tukhoa));
                        break;
                    case "Tác Giả":
                        ketQua = db.SACHes.Where(s => s.TacGia.ToLower().Contains(tukhoa));
                        break;
                    case "Thể Loại":
                        ketQua = db.SACHes.Where(s => s.TheLoai.ToLower().Contains(tukhoa));
                        break;
                }

                if (ketQua != null && ketQua.Any())
                {
                    dgSach.ItemsSource = ketQua.ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
