USE [demo]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[Id] [int] NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[Ngay] [int] NULL,
	[Thang] [int] NULL,
	[Nam] [int] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[Id] [int] NOT NULL,
	[MaHang] [nchar](10) NOT NULL,
	[SoHoaDon] [int] NOT NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[MaHang] ASC,
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hang]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hang](
	[MaHang] [nchar](10) NOT NULL,
	[TenHang] [nvarchar](50) NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,
	[MaNCC] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Hang_1] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[SoHoaDon] [int] NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[NgayLap] [nvarchar](25) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[SoHoaDon] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [nchar](10) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[NgaySinh] [nvarchar](25) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieu] [int] NOT NULL,
	[MaHang] [nchar](10) NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[SoLuongNhap] [int] NULL,
	[NgayLapPhieu] [nvarchar](25) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC,
	[MaHang] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/5/2022 2:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaNhanVien] [nchar](10) NOT NULL,
	[MatKhau] [nchar](10) NULL,
	[Quyen] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([Id], [MaNhanVien], [Ngay], [Thang], [Nam]) VALUES (9, N'NV001     ', 6, 9, 2013)
INSERT [dbo].[ChamCong] ([Id], [MaNhanVien], [Ngay], [Thang], [Nam]) VALUES (10, N'NV002     ', 6, 9, 2013)
INSERT [dbo].[ChamCong] ([Id], [MaNhanVien], [Ngay], [Thang], [Nam]) VALUES (11, N'NV003     ', 6, 9, 2013)
INSERT [dbo].[ChamCong] ([Id], [MaNhanVien], [Ngay], [Thang], [Nam]) VALUES (12, N'NV001     ', 7, 9, 2013)
INSERT [dbo].[ChamCong] ([Id], [MaNhanVien], [Ngay], [Thang], [Nam]) VALUES (13, N'NV002     ', 8, 9, 2013)
INSERT [dbo].[ChamCong] ([Id], [MaNhanVien], [Ngay], [Thang], [Nam]) VALUES (14, N'NV001     ', 8, 9, 2013)
GO
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonViTinh], [DonGia], [SoLuong], [MaNCC]) VALUES (N'DT001     ', N'HTC One', N'chiếc', 12000000, 10, N'NC001     ')
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonViTinh], [DonGia], [SoLuong], [MaNCC]) VALUES (N'DT002     ', N'Lumina 920', N'chiếc', 11000000, 15, N'NC001     ')
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonViTinh], [DonGia], [SoLuong], [MaNCC]) VALUES (N'TL001     ', N'Tủ Lạnh Sanyo', N'chiếc', 4500000, 20, N'NC002     ')
INSERT [dbo].[Hang] ([MaHang], [TenHang], [DonViTinh], [DonGia], [SoLuong], [MaNCC]) VALUES (N'TL002     ', N'Tủ Lạnh Toshiba', N'chiếc', 5000000, 15, N'NC004     ')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email], [MoTa]) VALUES (N'NC001     ', N'Thế giới di động', N'Cầu giấy, Hà Nội', 987654321, N'thegioididong@gmail.com', N'Điện thoại')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email], [MoTa]) VALUES (N'NC002     ', N'Trần Anh', N'Láng, Cầu giấy, HN', 98524284, N'trananh@gmail.com', N'Máy tính')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email], [MoTa]) VALUES (N'NC003     ', N'PiCo', N'Cầu giấy, HN', 987654678, N'pico@gmail.com', N'Tivi')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email], [MoTa]) VALUES (N'NC004     ', N'HC', N'Giải phóng, HN', 982347891, N'HC@gmail.com', N'Lò vi sóng')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'NV001     ', N'Đỗ Thị Hương', N'1992-08-10 12:00:00 AM', N'Thanh Hoá', 1639787456, N'HuongDo@gmail.com')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'NV002     ', N'Đỗ Thị Hà', N'1986-06-01 12:00:00 AM', N'Thanh Hoá', 987020353, N'HKTM@gmail.com')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'NV003     ', N'Nguyễn Vân Anh', N'1991-08-10 12:00:00 AM', N'Hưng Yên', 1639787247, N'Vananh@gmail.com')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'NV004     ', N'Phùng Văn Phong', N'1991-08-10 12:00:00 AM', N'Hà nội', 1639787291, N'PhungPhong@gmail.com')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'NV005     ', N'Lê The', N'7/3/2020 12:00:00 AM', N'05 Núi Thành', 905123567, N'le@gmail.com')
GO
INSERT [dbo].[PhieuNhap] ([MaPhieu], [MaHang], [MaNhanVien], [SoLuongNhap], [NgayLapPhieu]) VALUES (1, N'DT001     ', N'NV001     ', 20, N'2013-09-05 12:00:00 AM')
INSERT [dbo].[PhieuNhap] ([MaPhieu], [MaHang], [MaNhanVien], [SoLuongNhap], [NgayLapPhieu]) VALUES (2, N'DT002     ', N'NV001     ', 100, N'2013-09-05 12:00:00 AM')
INSERT [dbo].[PhieuNhap] ([MaPhieu], [MaHang], [MaNhanVien], [SoLuongNhap], [NgayLapPhieu]) VALUES (3, N'DT005     ', N'NV002     ', 30, N'2013-09-05 12:00:00 AM')
GO
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [MatKhau], [Quyen]) VALUES (N'admin     ', N'admin     ', 1)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [MatKhau], [Quyen]) VALUES (N'NV001     ', N'123       ', 2)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [MatKhau], [Quyen]) VALUES (N'NV002     ', N'123       ', 2)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [MatKhau], [Quyen]) VALUES (N'NV003     ', N'1         ', 2)
GO
