<<<<<<< Updated upstream
# Nhom2_CS_464_S
Bài thực hành môn cs464
=======
# Nhom2_CS_464_S — Ứng dụng Quản lý Tiệm Sách (WPF + Entity Framework)

## ✅ Giới thiệu
Đây là đồ án nhóm (Nhóm 2) môn Lập trình Ứng dụng .NET — ứng dụng quản lý tiệm sách với tính năng CRUD cho sách, khách hàng, hóa đơn.  
Ứng dụng xây dựng trên **WPF (.NET Framework)** và sử dụng **Entity Framework Database First** để tương tác với SQL Server / LocalDB.

---

## 📁 Cấu trúc thư mục

```
Nhom2_CS_464_S/
│  README.md
│  .gitignore
│  QLyTiemSach/
│   ├─ QLyTiemSach.csproj
│   ├─ MainWindow.xaml, MainWindow.xaml.cs
│   ├─ Sach.xaml, Sach.xaml.cs
│   ├─ KhachHang.xaml, KhachHang.xaml.cs
│   ├─ SearchSach.xaml, SearchSach.xaml.cs
│   ├─ Model
│   │   └─ QLyTiemSachModel.edmx
│   ├─ App.config
│   └─ (các thư mục Resources, obj, bin, …)
└─ .vs/ (.gitignore)
```


---

## ⚙ Yêu cầu hệ thống

- Visual Studio 2017  
- .NET Framework 4.x  
- SQL Server (hoặc LocalDB)  
- Entity Framework  

---

## 🚀 Hướng dẫn cài đặt & chạy

1. Clone repo:
   ```bash
   git clone https://github.com/MieIlie/Nhom2_CS_464_S.git
   ```

2. Mở solution `QLyTiemSach.sln` bằng Visual Studio 2017.

3. Cấu hình **connection string** trong `App.config` nếu cần:
   - Nếu dùng file `.mdf`, dùng `AttachDbFilename`.
   - Nếu dùng SQL Server Express, chỉnh `Data Source` cho đúng.

4. Nếu chưa có database, import hoặc chạy script Query SQL `QlyTiemSachDBQuery` (tạo bảng `SACH`, `KHACHHANG`, `HOADON`, `CHITIETHOADON`).

5. Build → Run → giao diện quản lý sẽ hiển thị.

---

## 🧩 Tính năng chính

- Quản lý **Sách** (CRUD + tìm kiếm)  
- Quản lý **Khách hàng**  
- Quản lý **Hóa đơn & chi tiết hóa đơn**  
- Tìm kiếm sách theo tiêu chí (mã, tên, thể loại…)  
- Giao diện WPF đẹp mắt, dễ sử dụng  

---

## 🛠 Quy trình Git & merge

- Mỗi thành viên làm trên **branch riêng**  
- Dùng Pull Request để merge vào `main`  
- Trước khi merge phải resolve conflict nếu có  
- Cần bỏ các file binary như `.mdf`, `.vs/` khỏi git bằng `.gitignore`

---

## ⚠ Lưu ý & gợi ý

- File database `.mdf` / `.ldf` **không nên commit lên repo**, dễ gây conflict  
- Dùng `git stash` hoặc `git commit` trước khi chuyển branch nếu có thay đổi chưa commit  
- Tránh để các file `obj/` hoặc file build bị track vào git  
>>>>>>> Stashed changes
