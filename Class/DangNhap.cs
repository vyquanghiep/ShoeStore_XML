using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace QuanLySieuThi.Class
{
    class DangNhap
    {
        FileXml Fxml = new FileXml();
        public void layMaQuyen()
        {

            XmlTextReader reader = new XmlTextReader("TaiKhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode nodeMQ = doc.SelectSingleNode("NewDataSet/TaiKhoan/Quyen");


        }
        public bool kiemtraDangNhap(string MaNhanVien, string MatKhau)
        {
            XmlTextReader reader = new XmlTextReader("TaiKhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/TaiKhoan[MaNhanVien='" + MaNhanVien + "']");
            node = doc.SelectSingleNode("NewDataSet/TaiKhoan[MatKhau='" + MatKhau + "']");
            reader.Close();
            bool kq = true;
            if (node != null)
            {
                return kq = true;
            }
            else
            {
                return kq = false;

            }


        }
        public void dangkiTaiKhoan(string MaNhanVien, string MatKhau, int Quyen)
        {
            string noiDung = "<_x0027_TaiKhoan_x0027_>" +
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<MatKhau>" + MatKhau + "</MatKhau>" +
                    "<Quyen>" + Quyen + "</Quyen>"+
                    "</_x0027_TaiKhoan_x0027_>";
                    
            Fxml.Them("TaiKhoan.xml",noiDung);
        }
        public void xoaTK(string MaNhanVien)
        {
            Fxml.Xoa("TaiKhoan.xml", "_x0027_TaiKhoan_x0027_", "MaNhanVien", MaNhanVien);
         
        }
        public bool kiemtraTTTK(string MaNhanVien)
        {
            XmlTextReader reader = new XmlTextReader("TaiKhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/TaiKhoan[MaNhanVien='" + MaNhanVien + "']");
            reader.Close();
            bool kq = true;
            if (node != null)
            {
                return kq = true;
            }
            else
            {
                return kq = false;

            }
        }
        public void DoiMatKhau(string nguoiDung, string matKhau)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\TaiKhoan.xml");
            XmlNode node1 = doc1.SelectSingleNode("NewDataSet/TaiKhoan[MaNhanVien = '" + nguoiDung + "']");
            if (node1 != null)
            {
                node1.ChildNodes[1].InnerText = matKhau;
                doc1.Save(Application.StartupPath + "\\TaiKhoan.xml");
            }
        }
        public bool kiemtraTTDN(string duongdan,string MaNhanVien, string MatKhau)
        {        
            DataTable dt = new DataTable();
            dt = Fxml.HienThi(duongdan);
            dt.DefaultView.RowFilter =  "MaNhanVien ='"+MaNhanVien+"' AND MatKhau='"+MatKhau+"'";
            if (dt.DefaultView.Count > 0)
                return true;
            return false;    
        
        }
    }
}
