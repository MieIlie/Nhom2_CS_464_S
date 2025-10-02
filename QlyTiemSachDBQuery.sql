CREATE TABLE [dbo].[SACH]
(
    [MaSach] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenSach] NVARCHAR(100) NOT NULL,
    [TacGia] NVARCHAR(50) NULL,
    [TheLoai] NVARCHAR(50) NULL,
    [GiaBan] INT NOT NULL,
    [SoLuong] INT NOT NULL
);

CREATE TABLE [dbo].[KHACHHANG]
(
    [MaKH] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenKH] NVARCHAR(100) NOT NULL,
    [DiaChi] NVARCHAR(200) NULL,
    [SDT] NVARCHAR(15) NULL
);

CREATE TABLE [dbo].[HOADON]
(
    [MaHD] NVARCHAR(10) NOT NULL PRIMARY KEY,
    [NgayLap] DATE NOT NULL,
    [MaKH] NVARCHAR(10) NOT NULL,
    [TongTien] DECIMAL(18,2) NULL,

    CONSTRAINT [FK_HOADON_KH] FOREIGN KEY ([MaKH]) REFERENCES [dbo].[KHACHHANG]([MaKH])
);

CREATE TABLE [dbo].[CHITIETHOADON]
(
    [MaHD] NVARCHAR(10) NOT NULL,
    [MaSach] NVARCHAR(10) NOT NULL,
    [SoLuong] INT NOT NULL,
    [DonGia] INT NOT NULL,

    CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY ([MaHD], [MaSach]),
    CONSTRAINT [FK_CTHD_HD] FOREIGN KEY ([MaHD]) REFERENCES [dbo].[HOADON]([MaHD]),
    CONSTRAINT [FK_CTHD_SACH] FOREIGN KEY ([MaSach]) REFERENCES [dbo].[SACH]([MaSach])
);
GO
-- Chèn dữ liệu mẫu
INSERT INTO [dbo].[SACH] ([MaSach],[TenSach],[TacGia],[TheLoai],[GiaBan],[SoLuong]) VALUES
('S01', N'Lập Trình C#',      N'Nguyễn Văn A', N'CNTT', 120000, 10),
('S02', N'Cơ Sở Dữ Liệu',    N'Trần Thị B',   N'CNTT', 150000,  8),
('S03', N'Python cho người mới', N'Phạm Văn C', N'CNTT', 110000, 15);
GO

INSERT INTO [dbo].[KHACHHANG] ([MaKH],[TenKH],[DiaChi],[SDT]) VALUES
('KH01', N'Lê Minh Tuấn', N'Hà Nội', '0912345678'),
('KH02', N'Ngọc Anh',     N'TP.HCM', '0987654321');
GO

INSERT INTO [dbo].[HOADON] ([MaHD],[NgayLap],[MaKH],[TongTien]) VALUES
('HD01', '2025-09-30', 'KH01', 0);
GO

INSERT INTO [dbo].[CHITIETHOADON] ([MaHD],[MaSach],[SoLuong],[DonGia]) VALUES
('HD01','S01', 1, 120000),
('HD01','S02', 1, 150000);
GO

-- Cập nhật tổng tiền cho hoá đơn HD01
UPDATE dbo.HOADON
SET TongTien = (SELECT SUM(SoLuong * DonGia) FROM dbo.CHITIETHOADON WHERE MaHD = dbo.HOADON.MaHD)
WHERE MaHD = 'HD01';
GO

-- Kiểm tra dữ liệu
SELECT * FROM dbo.SACH;
SELECT * FROM dbo.KHACHHANG;
SELECT * FROM dbo.HOADON;
SELECT * FROM dbo.CHITIETHOADON;
GO