using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QuanLySieuThi.Class
{
    class NhanVien
    {
        FileXml Fxml = new FileXml();
        public bool kiemtra(string MaNhanVien)
        {
            XmlTextReader reader = new XmlTextReader("TaiKhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode nodeList = doc.SelectSingleNode("/TaiKhoan[MaNhanVien='" + MaNhanVien + "']");
            reader.Close();
            bool kq = true;
            if (nodeList == null)
            {
                kq = false;
            }
            return kq;
        }
        public void themNV(string MaNhanVien, string TenNhanVien, string NgaySinh, string DiaChi, string SDT, string Email)
        {
            string noiDung = "<_x0027_NhanVien_x0027_>" +
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<TenNhanVien>" + TenNhanVien + "</TenNhanVien>" +
                    "<NgaySinh>" + NgaySinh + "</NgaySinh>" +
                    "<DiaChi>" + DiaChi + "</DiaChi>" +
                    "<SDT>" + SDT + "</SDT>" +
                    "<Email>" + Email + "</Email>" +
                    "</_x0027_NhanVien_x0027_>";
            Fxml.Them("NhanVien.xml", noiDung);
        }
        public void suaNV(string MaNhanVien, string TenNhanVien, string NgaySinh, string DiaChi, string SDT, string Email)
        {

            string noiDung = "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<TenNhanVien>" + TenNhanVien + "</TenNhanVien>" +
                    "<NgaySinh>" + NgaySinh + "</NgaySinh>" +
                    "<DiaChi>" + DiaChi + "</DiaChi>" +
                    "<SDT>" + SDT + "</SDT>" +
                    "<Email>" + Email + "</Email>";

            Fxml.Sua("NhanVien.xml", "_x0027_NhanVien_x0027_", "MaNhanVien", MaNhanVien, noiDung);


        }
        public void xoaNV(string MaNhanVien)
        {
            Fxml.Xoa("NhanVien.xml", "_x0027_NhanVien_x0027_", "MaNhanVien", MaNhanVien);
        }
        public void XacNhanDiLam(string MaNhanVien, int Ngay, int Thang, int Nam)
        {
            XmlTextReader textread = new XmlTextReader("ChamCong.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(textread);
            textread.Close();
            XmlNode currNode;
            XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
            docFrag.InnerXml = "<ChamCong>" +
            "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
            "<Ngay>" + Ngay + "</Ngay>" +
            "<Thang>" + Thang + "</Thang>" +
            "<Nam>" + Nam + "</Nam>" +
            "</ChamCong>";
            currNode = doc.DocumentElement;
            currNode.InsertAfter(docFrag, currNode.LastChild);
            doc.Save("ChamCong.xml");
        }
        public bool kiemtraNgayThang(string MaNhanVien, int Ngay, int Thang, int Nam)
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("ChamCong.xml");
            dt.DefaultView.RowFilter = "MaNhanVien ='" + MaNhanVien + "' AND Ngay='" + Ngay + "' AND Thang='" + Thang + "' AND Nam='" + Nam + "'";
            if (dt.DefaultView.Count > 0)

                return true;

            return false;
        }
       
    }
}
