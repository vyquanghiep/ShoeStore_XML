using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLySieuThi.Class
{
    class HoaDon
    {
        FileXml Fxml = new FileXml();
        public void themHD(string SoHoaDon, string MaNhanVien, string NgayLap, string TongTien)
        {
            string noiDung = "<_x0027_HoaDon_x0027_>" +
                    "<SoHoaDon>" + SoHoaDon + "</SoHoaDon>" +
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<NgayLap>" + NgayLap + "</NgayLap>" +
                    "<TongTien>" + TongTien + "</TongTien>" +
                    "</_x0027_HoaDon_x0027_>";
            Fxml.Them("HoaDon.xml", noiDung);
        }
        public void xoaHD(string SoHoaDon)
        {
            Fxml.Xoa("HoaDon.xml", "_x0027_HoaDon_x0027_", "SoHoaDon", SoHoaDon);
        }
    }
}
