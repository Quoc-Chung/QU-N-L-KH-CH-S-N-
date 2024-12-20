--CREATE DATABASE QUANLI_KHACHSAN_BTL
--USE QUANLI_KHACHSAN_BTL
/* - THỨ TỰ CHÈN CÁC BẢNG VÀO CƠ SỞ DỮ LIỆU 
TAI_KHOAN (MATAIKHOAN, MATKHAU, HOTEN, NGAYSINH, GIOITINH, DIACHI, SODIENTHOAI, NGAYVAOLAM, ANH)

LOAIPHONG (MALOAIPHONG, LOAIPHONG, GIATIEN)

DANHMUCPHONG (MAPHONG, MALOAIPHONG, TANG, TINHTRANG, ANHPHONG)

KHACHHANG (MAKHACHHANG, HOTEN, GIOITINH, DIACHI, CMND, DIENTHOAI)

THUEPHONG (SHDTHUEPHONG, MATAIKHOAN, MAPHONG, NGAYTHUE, NGAYTRA)

CHITIETTHUEPHONG (SHDTHUEPHONG, MAKHACHHANG)

HDTHANHTOANPHONG (SHDTHANHTOAN,SHDTHUEPHONG, MATAIKHOAN, NGAYTHANHTOAN)

THIETBI_DICHVU (MATHIETBI, TENTHIETBI, GIATIEN)

SUDUNGDICHVU (SHDTHUEPHONG, MATHIETBI, NGAYSUDUNG, SOLUONG)

THIETBI_PHONG (MALOAIPHONG, MATHIETBI, SOLUONG)

LICHSUDATPHONG(MALICHSU, SHDTHUEPHONG,MAPHONG,MANHANVIEN, MAKHACHHANG,NGAYTHUE,NGAYTRA,TONGTIENPHONG, TONGTIENDICHVU,TONGTIEN)



MATAIKHOAN-*/ 

/*--------------TẠO BẢNG USER ---------------*/
CREATE TABLE TAI_KHOAN(
    MATAIKHOAN NVARCHAR(20) NOT NULL PRIMARY KEY,
    MATKHAU VARCHAR(20) NOT NULL,
    HOTEN NVARCHAR(100) NOT NULL,
    NGAYSINH DATE NOT NULL,
    GIOITINH BIT NOT NULL,
    DIACHI NVARCHAR(100) NOT NULL,
    SODIENTHOAI VARCHAR(20),
    NGAYVAOLAM DATE NULL,
	QUYEN NVARCHAR(10) NOT NULL, 
    ANH NVARCHAR(100)
);

INSERT INTO TAI_KHOAN (MATAIKHOAN, MATKHAU, HOTEN, NGAYSINH, GIOITINH, DIACHI, SODIENTHOAI, NGAYVAOLAM,QUYEN,ANH)  
VALUES  
    ('NV001', '123', N'Từ Quốc Chung', '2004-03-01', 1, N'Quận Đống Đa-Hà Nội', '0973287666', '2024-09-11',N'NV','mot.jpg'),
    ('NV002', '123', N'Võ Hoàng Hưng', '2004-01-01', 1, N'Quận Thanh Trì-Hà Nội', '0972873536', '2024-11-11',N'NV','hai.jpg'),
    ('NV003', '123', N'Võ Hồng Thịnh', '2004-10-05', 1, N'Quận Hoàn Kiếm-Hà Nội', '0273347611', '2024-01-11',N'NV','ba.jpg'),
    ('NV004', '123', N'Phạm Nguyễn Hồng Phong', '2004-02-03', 1, N'Quận Nam Từ Liêm- Hà Nội', '0273287666', '2024-02-11',N'NV','bon.jpg'),
    ('NV005', '123', N'Nguyễn Hồng Đăng', '2001-02-01', 1, N'Quận Cầu Giấy- Hà Nội', '0973287999', '2023-12-11',N'NV','nam.jpg'),
	('AD001', '123', N'Bui Hong Thai', '1977-03-01', 1, N'Quận Đống Đa-Hà Nội', '0973287666',NULL,N'ADMIN','sau.jpg'),
	('AD002', '123', N'Duong Thi Kim', '1997-03-01', 1, N'Quận Ba Đình -Hà Nội', '09732876888',NULL,N'ADMIN','bay.jpg')

/*--------------TẠO BẢNG LOAIPHONG---------------*/
CREATE TABLE LOAIPHONG(
MALOAIPHONG NVARCHAR(20) NOT NULL PRIMARY KEY,
LOAIPHONG NVARCHAR(50) NOT NULL,
GIATIEN MONEY NOT NULL,
);
INSERT INTO LOAIPHONG
VALUES 
('MLP01',N'Phòng vip',1000000),
('MLP02',N'Phòng tầm trung',500000),
('MLP03',N'Phòng thường',300000);

/*--------------TẠO BẢNG DANHMUCPHONG---------------*/
CREATE TABLE DANHMUCPHONG
(
MAPHONG NVARCHAR(20) NOT NULL PRIMARY KEY,
MALOAIPHONG NVARCHAR(20) NOT NULL,
TANG INT NOT NULL,
TINHTRANG BIT NOT NULL,
ANHPHONG NVARCHAR(50),
CONSTRAINT KN_DMPHONG FOREIGN KEY (MALOAIPHONG) REFERENCES LOAIPHONG(MALOAIPHONG),
);
/* - 1 thì đã có người thuê , 0 thì chưa có người thuê - */ 
INSERT INTO DANHMUCPHONG (MAPHONG, MALOAIPHONG, TANG, TINHTRANG, ANHPHONG)
VALUES
('MP01', 'MLP01', 1, 1, 'mot.jpg'),
('MP02', 'MLP01', 2, 1, 'hai.jpg'),
('MP03', 'MLP01', 3, 1, 'ba.jpg'),
('MP04', 'MLP01', 4, 1, 'bon.jpg'),
('MP05', 'MLP01', 5, 1, 'nam.jpg'),
('MP06', 'MLP02', 6, 1, 'sau.jpg'),
('MP07', 'MLP02', 7, 1, 'bay.jpg'),
('MP08', 'MLP02', 8, 1, 'tam.jpg'),
('MP09', 'MLP02', 9, 1, 'chin.jpg'),
('MP10', 'MLP02', 10,1, 'muoi.jpg'),
('MP11', 'MLP03', 1, 1, 'muoimot.jpg'),
('MP12', 'MLP03', 2, 1, 'muoihai.jpg'),
('MP13', 'MLP03', 3, 1, 'muoiba.jpg'),
('MP14', 'MLP03', 4, 1, 'muoibon.jpg'),
('MP15', 'MLP03', 5, 0, 'muoinam.jpg'),
('MP16', 'MLP03', 5, 0, 'muoisau.jpg'),
('MP17', 'MLP03', 6, 0, 'muoibay.jpg'),
('MP18', 'MLP03', 7, 0, 'muoitam.jpg'),
('MP19', 'MLP03', 8, 0, 'muoichin.jpg')
/*--------------TẠO BẢNG KHACHHANG---------------*/
CREATE TABLE KHACHHANG(
MAKHACHHANG NVARCHAR(20) NOT NULL PRIMARY KEY,
HOTEN NVARCHAR(100) NOT NULL,
GIOITINH BIT,
DIACHI NVARCHAR(255),
CMND NVARCHAR(20),
DIENTHOAI VARCHAR(15),
);
INSERT INTO KHACHHANG
VALUES
('KH01',N'Lê Đức Sơn',1,N'Đà Nẵng','030301009999','0987654678'),
('KH02',N'Nguyễn Thị Hoa ',0,N'Đà Lạt','0303010000','0987654999'),
('KH03',N'Trần Vũ Anh ',1,N'Hà Nội','030301066666','09876543677'),
('KH04',N'Trần Thanh Hoa ',0,N'Hồ Chí Minh','03030999992','09876543365'),
('KH05',N'Hoàng Thị Thúy ',0,N'Hải Phòng','030309999999','0987654666'),
('KH06',N'Vũ Trọng Kiên',1,N'Hải Phòng','0303010122344','0987654323'),
('KH07',N'Lê Văn Đô ',1,N'Hà Nội','003987654333','0987654777'),
('KH08',N'Nguyễn Hồng',0,N'Hà Nam','0303023231221','0987654314'),
('KH09',N'Hoàng Sơn ',1,N'Đà Nẵng','03030323115657','0987654133'),
('KH10',N'Trần Thanh Nhàn ',0,N'Đà Nẵng','030301023254643','0987654333'),
('KH11',N'Hoàng Sơn Tùng ',1,N'Đà Nẵng','03030323115657','0987654133'),
('KH12',N'Hoàng Thùy Linh ',1,N'Đà Lạt','03030233115222','0987654133'),
('KH13',N'Vũ Tiến Đạt ',1,N'Đà Nẵng','03030323115657','0987654111'),
('KH14',N'Hoàng Sơn Đạt ',1,N'Hà Nội','0303032311527','0987654100'),
('KH15', N'Nguyễn Văn Hùng', 1, N'Hà Nội', '030301045678', '0987654001'),
('KH16', N'Trần Thị Lan', 0, N'Quảng Ninh', '030301234567', '0987654002'),
('KH17', N'Phạm Minh Tuấn', 1, N'Bình Dương', '030301876543', '0987654003'),
('KH18', N'Võ Thị Xuân', 0, N'Nha Trang', '030301556677', '0987654004'),
('KH19', N'Lê Hoài Nam', 1, N'Hà Nội', '030301998877', '0987654005'),
('KH20', N'Nguyễn Phúc Thịnh', 1, N'Hải Dương', '030301332211', '0987654006'),
('KH21', N'Tran Anh Quoc', 1, N'Saigon', '030301009876', '0987654007'),
('KH22', N'Phạm Văn Hùng', 1, N'Hải Dương', '030301123456', '0987654001'),
('KH23', N'Nguyễn Thị Mai', 0, N'Quảng Ninh', '030301789012', '0987654002'),
('KH24', N'Lê Thị Hương', 0, N'Bình Dương', '030301345678', '0987654003'),
('KH25', N'Trần Quang Khải', 1, N'Hà Tĩnh', '030301890123', '0987654004'),
('KH26', N'Hoàng Văn Minh', 1, N'Nam Định', '030301567890', '0987654005'),
('KH27', N'Đinh Thị Lan', 0, N'Nghệ An', '030301234567', '0987654006'),
('KH28', N'Phan Thị Hà', 0, N'Thái Bình', '030301678901', '0987654007'),
('KH29', N'Ngô Văn Long', 1, N'Bắc Ninh', '030301012345', '0987654008'),
('KH30', N'Nguyễn Văn Nam', 1, N'Tây Ninh', '030301456789', '0987654009'),
('KH31', N'Bùi Thị Ngọc', 0, N'Lào Cai', '030301678910', '0987654010'),
('KH32', N'Lương Quang Huy', 1, N'Quảng Bình', '030301345678', '0987654011'),
('KH33', N'Trần Thị Kim', 0, N'Bắc Giang', '030301890123', '0987654012'),
('KH34', N'Vũ Văn Đạt', 1, N'Lâm Đồng', '030301567890', '0987654013'),
('KH35', N'Lê Thị Ánh', 0, N'Kiên Giang', '030301234567', '0987654014'),
('KH36', N'Phạm Văn Bình', 1, N'Hậu Giang', '030301789012', '0987654015');


/*--------------TẠO BẢNG THUEPHONG---------------*/
CREATE TABLE THUEPHONG (
    SHDTHUEPHONG NVARCHAR(20) PRIMARY KEY,
    MATAIKHOAN NVARCHAR(20) NOT NULL,
    MAPHONG NVARCHAR(20) NOT NULL,
    NGAYTHUE DATETIME NOT NULL,
    NGAYTRA DATETIME NOT NULL,
    CONSTRAINT KN_THUEPHONG_MATAIKHOAN FOREIGN KEY (MATAIKHOAN) REFERENCES TAI_KHOAN(MATAIKHOAN),
    CONSTRAINT KN_THUEPHONG_MAPHONG FOREIGN KEY (MAPHONG) REFERENCES DANHMUCPHONG(MAPHONG)
);

INSERT INTO THUEPHONG(SHDTHUEPHONG, MATAIKHOAN, MAPHONG, NGAYTHUE, NGAYTRA)
VALUES
    ('THP001', 'NV001', 'MP01', '2024-12-10 14:00:00', '2025-01-01 10:00:00'),   
    ('THP002', 'NV002', 'MP02', '2024-11-24 15:30:00', '2025-01-09 09:45:00'),
    ('THP003', 'NV003', 'MP03', '2024-11-24 12:00:00', '2025-11-01 08:30:00'),
    ('THP004', 'NV004', 'MP04', '2024-11-25 16:15:00', '2025-01-02 11:00:00'),
    ('THP005', 'NV003', 'MP05', '2024-11-26 13:00:00', '2024-12-26 10:00:00'),
    ('THP006', 'NV002', 'MP06', '2024-12-22 14:30:00', '2025-01-01 09:30:00'),
    ('THP007', 'NV001', 'MP07', '2024-12-23 18:00:00', '2025-01-23 11:45:00'),
    ('THP008', 'NV001', 'MP08', '2024-12-23 20:00:00', '2025-01-23 12:30:00'),
    ('THP009', 'NV004', 'MP09', '2024-12-23 13:45:00', '2025-01-23 08:15:00'),
    ('THP010', 'NV001', 'MP10', '2024-12-24 17:00:00', '2025-01-24 13:30:00'),
    ('THP011', 'NV002', 'MP11', '2024-12-24 15:00:00', '2025-01-24 09:00:00'),
    ('THP012', 'NV003', 'MP12', '2024-12-25 10:00:00', '2025-01-25 11:00:00'),
    ('THP013', 'NV004', 'MP13', '2024-12-25 14:15:00', '2025-01-25 10:45:00'),
    ('THP014', 'NV005', 'MP14', '2024-12-26 09:30:00', '2025-01-26 10:00:00')

-- Tạo bảng CHITIETTHUEPHONG và thêm dữ liệu
CREATE TABLE CHITIETTHUEPHONG (
    SHDTHUEPHONG NVARCHAR(20) NOT NULL,
    MAKHACHHANG NVARCHAR(20) NOT NULL,
    CONSTRAINT PK_CHITIETTHUEPHONG PRIMARY KEY (SHDTHUEPHONG, MAKHACHHANG),
    CONSTRAINT FK_CHITIETTHUEPHONG_SHDTHUEPHONG FOREIGN KEY (SHDTHUEPHONG) REFERENCES THUEPHONG(SHDTHUEPHONG),
    CONSTRAINT FK_CHITIETTHUEPHONG_MAKHACHHANG FOREIGN KEY (MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG)
);

-- Chèn dữ liệu vào bảng CHITIETTHUEPHONG
INSERT INTO CHITIETTHUEPHONG (SHDTHUEPHONG, MAKHACHHANG)
VALUES
    ('THP001', 'KH02'),
    ('THP002', 'KH03'),
    ('THP002', 'KH04'),
    ('THP003', 'KH05'),
    ('THP003', 'KH06'),
    ('THP004', 'KH07'),
    ('THP004', 'KH08'),
    ('THP005', 'KH09'),
    ('THP005', 'KH10'),
    ('THP006', 'KH11'),
    ('THP006', 'KH12'),
    ('THP007', 'KH13'),
    ('THP007', 'KH14'),
    ('THP008', 'KH15'),
    ('THP009', 'KH16'),
    ('THP010', 'KH17'),
    ('THP011', 'KH18'),
    ('THP012', 'KH19'),
    ('THP013', 'KH20'),
	('THP014', 'KH21')
-- Tạo bảng HDTHANHTOANPHONG và thêm dữ liệu
CREATE TABLE HDTHANHTOANPHONG (
    SHDTHANHTOAN NVARCHAR(20) PRIMARY KEY,
    SHDTHUEPHONG NVARCHAR(20) NOT NULL,
    MATAIKHOAN NVARCHAR(20) NOT NULL,
    NGAYTHANHTOAN DATETIME NOT NULL,
    CONSTRAINT FK_HDTHANHTOANPHONG_SHDTHUEPHONG FOREIGN KEY (SHDTHUEPHONG) REFERENCES THUEPHONG(SHDTHUEPHONG),
    CONSTRAINT FK_HDTHANHTOANPHONG_MATAIKHOAN FOREIGN KEY (MATAIKHOAN) REFERENCES TAI_KHOAN(MATAIKHOAN)
);
INSERT INTO HDTHANHTOANPHONG (SHDTHANHTOAN, SHDTHUEPHONG, MATAIKHOAN, NGAYTHANHTOAN)
VALUES
    ('HDTP001', 'THP001', 'NV001', '2025-01-01 11:00:00'),
    ('HDTP002', 'THP002', 'NV002', '2025-01-09 10:00:00'),
    ('HDTP003', 'THP003', 'NV003', '2025-11-01 09:00:00'),
    ('HDTP004', 'THP004', 'NV004', '2025-01-02 12:00:00'),
    ('HDTP005', 'THP006', 'NV001', '2025-01-01 10:30:00'),
    ('HDTP006', 'THP007', 'NV001', '2025-01-23 12:00:00'),
    ('HDTP007', 'THP008', 'NV002', '2025-01-23 13:00:00'),
    ('HDTP008', 'THP009', 'NV003', '2025-01-23 09:00:00'),
    ('HDTP009', 'THP010', 'NV004', '2025-01-24 14:00:00'),
    ('HDTP010', 'THP011', 'NV001', '2025-01-24 10:30:00');

/*--------------TẠO BẢNG THIETBI_DICHVU---------------*/
CREATE TABLE THIETBI_DICHVU
(
MATHIETBI NVARCHAR(20) NOT NULL PRIMARY KEY,
TENTHIETBI NVARCHAR(50) NOT NULL,
GIATIEN MONEY NOT NULL,
);
INSERT INTO THIETBI_DICHVU (MATHIETBI, TENTHIETBI, GIATIEN)
VALUES
('MTB01', N'Điều hòa', 400000),
('MTB02', N'Tivi', 300000),
('MTB03', N'Giường', 100000),
('MTB04', N'Máy chơi game', 10000),
('MTB05', N'Bình nóng lạnh', 500000),
('MTB06', N'Đèn điện', 10000),
('MTB07', N'Bàn', 20000),
('MTB08', N'Ghế', 10000),
('MTB09', N'Tủ lạnh', 600000),
('MTB10', N'Lò vi sóng', 150000),
('MTB11', N'Bếp điện', 200000),
('MTB12', N'Máy hút bụi', 100000),
('MTB13', N'Máy sấy tóc', 30000),
('MTB14', N'Máy lọc không khí', 250000),
('MTB15', N'Máy pha cà phê', 120000),
('MTB16', N'Máy giặt', 700000),
('MTB17', N'Máy rửa chén', 800000),
('MTB18', N'Bình nước nóng', 180000);

/*--------------TẠO BẢNG SUDUNGDICHVU---------------*/
CREATE TABLE SUDUNGDICHVU
(
    SHDTHUEPHONG NVARCHAR(20) NOT NULL,
    MATHIETBI NVARCHAR(20) NOT NULL,
    NGAYSUDUNG DATE,
    SOLUONG INT,
    CONSTRAINT KC_SUDUNGDV PRIMARY KEY (SHDTHUEPHONG, MATHIETBI, NGAYSUDUNG),
    CONSTRAINT KN_SUDUNGDV_SHDTHUEPHONG FOREIGN KEY (SHDTHUEPHONG) REFERENCES THUEPHONG(SHDTHUEPHONG),
    CONSTRAINT KN_SUDUNGDV_MATHIETBI FOREIGN KEY (MATHIETBI) REFERENCES THIETBI_DICHVU(MATHIETBI)
);
INSERT INTO SUDUNGDICHVU (SHDTHUEPHONG, MATHIETBI, NGAYSUDUNG, SOLUONG)
VALUES 
    ('THP001', 'MTB04', '2025-11-11', 1),
    ('THP002', 'MTB01', '2025-11-11', 1),
    ('THP001', 'MTB04', '2025-12-11', 1),
    ('THP003', 'MTB04', '2024-12-12', 1),
    ('THP004', 'MTB03', '2024-12-12', 1),
    ('THP005', 'MTB04', '2025-11-29', 1),
    ('THP006', 'MTB06', '2025-11-12', 1),
    ('THP001', 'MTB05', '2025-11-12', 1);

--TẠO BẢNG THIETBI_PHONG
CREATE TABLE THIETBI_PHONG
(
    MALOAIPHONG NVARCHAR(20) NOT NULL,
    MATHIETBI NVARCHAR(20) NOT NULL,
    SOLUONG INT NOT NULL,
    CONSTRAINT KC_THIETBI_PHONG PRIMARY KEY (MALOAIPHONG, MATHIETBI),
    CONSTRAINT KN_THIETBI_PHONG_MALOAIPHONG FOREIGN KEY (MALOAIPHONG) REFERENCES LOAIPHONG(MALOAIPHONG),
    CONSTRAINT KN_THIETBI_PHONG_MATHIETBI FOREIGN KEY (MATHIETBI) REFERENCES THIETBI_DICHVU(MATHIETBI)
);

-- CHÈN DỮ LIỆU VÀO BẢNG THIETBI_PHONG
INSERT INTO THIETBI_PHONG (MALOAIPHONG, MATHIETBI, SOLUONG)
VALUES
    ('MLP01', 'MTB01', 2),
    ('MLP01', 'MTB02', 1),
    ('MLP01', 'MTB03', 1),
    ('MLP01', 'MTB04', 1),
	('MLP01', 'MTB05', 1),
	('MLP01', 'MTB06', 1),
	('MLP01', 'MTB07', 1),
	('MLP01', 'MTB08', 1),
    ('MLP02', 'MTB01', 2),
    ('MLP02', 'MTB02', 1),
    ('MLP02', 'MTB03', 1),
    ('MLP02', 'MTB04', 1),
	('MLP02', 'MTB05', 1),
	('MLP02', 'MTB06', 1),
	('MLP02', 'MTB07', 1),
	('MLP02', 'MTB08', 1),
    ('MLP03', 'MTB01', 2),
    ('MLP03', 'MTB02', 1),
    ('MLP03', 'MTB03', 1),
    ('MLP03', 'MTB04', 1),
	('MLP03', 'MTB05', 1),
	('MLP03', 'MTB06', 1),
	('MLP03', 'MTB07', 1),
	('MLP03', 'MTB08', 1)



CREATE TABLE LICHSUDATPHONG (
    MALICHSU INT IDENTITY(1,1) PRIMARY KEY,
    SHDTHUEPHONG NVARCHAR(20) NOT NULL,
    MAPHONG NVARCHAR(20) NOT NULL,
    TENNHANVIEN NVARCHAR(100) NOT NULL,
    MAKHACHHANG NVARCHAR(20) NOT NULL,
    NGAYTHUE DATE NOT NULL,
    NGAYTRA DATE NOT NULL,
    SONGAYTHUE INT NOT NULL,
    TONGTIENPHONG DECIMAL(18, 2) NOT NULL,
    TONGTIENDICHVU DECIMAL(18, 2) NOT NULL,
    TONGTIEN AS (ISNULL(TONGTIENPHONG, 0) + ISNULL(TONGTIENDICHVU, 0)),
);

INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP001', N'MP01', N'Từ Quốc Chung', N'KH02', CAST(N'2024-12-10' AS Date), CAST(N'2025-01-01' AS Date), 21, CAST(21000000.00 AS Decimal(18, 2)), CAST(520000.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP002', N'MP02', N'Võ Hoàng Hưng', N'KH03', CAST(N'2024-11-24' AS Date), CAST(N'2025-01-09' AS Date), 45, CAST(45000000.00 AS Decimal(18, 2)), CAST(400000.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP003', N'MP03', N'Võ Hồng Thịnh', N'KH05', CAST(N'2024-11-24' AS Date), CAST(N'2025-11-01' AS Date), 341, CAST(341000000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP009', N'MP09', N'Phạm Nguyễn Hồng Phong', N'KH16', CAST(N'2024-12-23' AS Date), CAST(N'2025-01-23' AS Date), 30, CAST(15000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP010', N'MP10', N'Từ Quốc Chung', N'KH17', CAST(N'2024-12-24' AS Date), CAST(N'2025-01-24' AS Date), 30, CAST(15000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES (N'THP007', N'MP07', N'Từ Quốc Chung', N'KH13', CAST(N'2024-12-23' AS Date), CAST(N'2025-01-23' AS Date), 30, CAST(15000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP006', N'MP06', N'Võ Hoàng Hưng', N'KH11', CAST(N'2024-12-22' AS Date), CAST(N'2025-01-01' AS Date), 9, CAST(4500000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP005', N'MP05', N'Võ Hồng Thịnh', N'KH09', CAST(N'2024-11-26' AS Date), CAST(N'2024-12-26' AS Date), 29, CAST(29000000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP014', N'MP14', N'Nguyễn Hồng Đăng', N'KH21', CAST(N'2024-12-26' AS Date), CAST(N'2025-01-26' AS Date), 31, CAST(9300000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP012', N'MP12', N'Võ Hồng Thịnh', N'KH19', CAST(N'2024-12-25' AS Date), CAST(N'2025-01-25' AS Date), 31, CAST(9300000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP011', N'MP11', N'Võ Hoàng Hưng', N'KH18', CAST(N'2024-12-24' AS Date), CAST(N'2025-01-24' AS Date), 30, CAST(9000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP004', N'MP04', N'Phạm Nguyễn Hồng Phong', N'KH07', CAST(N'2024-11-25' AS Date), CAST(N'2025-01-02' AS Date), 37, CAST(37000000.00 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP013', N'MP13', N'Phạm Nguyễn Hồng Phong', N'KH20', CAST(N'2024-12-25' AS Date), CAST(N'2025-01-25' AS Date), 30, CAST(9000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LICHSUDATPHONG] ([SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES ( N'THP008', N'MP08', N'Từ Quốc Chung', N'KH15', CAST(N'2024-12-23' AS Date), CAST(N'2025-01-23' AS Date), 30, CAST(15000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))






INSERT [dbo].[LICHSUDATPHONG] ( [SHDTHUEPHONG], [MAPHONG], [TENNHANVIEN], [MAKHACHHANG], [NGAYTHUE], [NGAYTRA], [SONGAYTHUE], [TONGTIENPHONG], [TONGTIENDICHVU]) VALUES 
( N'THP015', N'MP15', N'Võ Hồng Thịnh', N'KH22', CAST(N'2024-01-15' AS Date), CAST(N'2024-01-20' AS Date), 5, CAST(5000000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2))),
( N'THP016', N'MP16', N'Võ Hoàng Hưng', N'KH23', CAST(N'2024-02-10' AS Date), CAST(N'2024-02-15' AS Date), 5, CAST(7500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2))),
( N'THP017', N'MP17', N'Võ Hồng Thịnh', N'KH24', CAST(N'2024-03-20' AS Date), CAST(N'2024-03-25' AS Date), 5, CAST(5000000.00 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2))),
( N'THP018', N'MP18', N'Võ Hoàng Hưng', N'KH25', CAST(N'2024-04-05' AS Date), CAST(N'2024-04-10' AS Date), 5, CAST(6000000.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2))),
( N'THP019', N'MP19', N'Võ Hồng Thịnh', N'KH26', CAST(N'2024-05-25' AS Date), CAST(N'2024-06-01' AS Date), 7, CAST(7000000.00 AS Decimal(18, 2)), CAST(400000.00 AS Decimal(18, 2))),
( N'THP020', N'MP20', N'Võ Hoàng Hưng', N'KH27', CAST(N'2024-06-12' AS Date), CAST(N'2024-06-20' AS Date), 8, CAST(8000000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2))),
( N'THP021', N'MP21', N'Võ Hồng Thịnh', N'KH28', CAST(N'2024-07-01' AS Date), CAST(N'2024-07-10' AS Date), 9, CAST(9000000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2))),
( N'THP022', N'MP22', N'Nguyễn Hồng Đăng', N'KH29', CAST(N'2024-08-15' AS Date), CAST(N'2024-08-25' AS Date), 10, CAST(10000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2))),
( N'THP023', N'MP23', N'Võ Hồng Thịnh', N'KH30', CAST(N'2024-09-10' AS Date), CAST(N'2024-09-20' AS Date), 10, CAST(12000000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2))),
( N'THP024', N'MP24', N'Võ Hoàng Hưng', N'KH31', CAST(N'2024-10-01' AS Date), CAST(N'2024-10-05' AS Date), 4, CAST(4000000.00 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2))),
( N'THP025', N'MP25', N'Võ Hồng Thịnh', N'KH32', CAST(N'2024-11-05' AS Date), CAST(N'2024-11-15' AS Date), 10, CAST(10000000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2))),
( N'THP026', N'MP26', N'Nguyễn Hồng Đăng', N'KH33', CAST(N'2024-12-01' AS Date), CAST(N'2024-12-10' AS Date), 9, CAST(9000000.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2))),
( N'THP027', N'MP27', N'Nguyễn Hồng Đăng', N'KH34', CAST(N'2024-02-15' AS Date), CAST(N'2024-02-28' AS Date), 13, CAST(13000000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2))),
( N'THP028', N'MP28', N'Võ Hồng Thịnh', N'KH35', CAST(N'2024-03-01' AS Date), CAST(N'2024-03-15' AS Date), 14, CAST(14000000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2))),
( N'THP029', N'MP29',N'Nguyễn Hồng Đăng', N'KH36', CAST(N'2024-04-10' AS Date), CAST(N'2024-04-20' AS Date), 10, CAST(11000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)));
