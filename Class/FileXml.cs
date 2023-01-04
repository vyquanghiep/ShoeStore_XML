using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Diagnostics;   // Dùng cho Pricess.Start()

namespace QuanLySieuThi.Class
{
    class FileXml
    {
        string Conn = @"Data Source=DUCLUU; Initial Catalog = test1; Integrated Security=true";
        public DataTable HienThi(string duongDan)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + "\\" + duongDan;
            if (File.Exists(FilePath))
            {
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + duongDan + "' không tồn tại");
            }

            return dt;
        }
        public void TaoXML(string bang)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            string sql = "Select* from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("'" + bang + "'");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\" + bang + ".xml", XmlWriteMode.WriteSchema);
        }
        public void taoxmltaikhoan()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select * from taikhoan", conn);
            DataTable dt = new DataTable("taikhoan");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\taikhoan.xml", XmlWriteMode.WriteSchema);

        }
        public void TaoXMLNhanVien()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from NhanVien", conn);
            DataTable dt = new DataTable("NhanVien");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\NhanVien.xml", XmlWriteMode.WriteSchema);

        }
        public void TaoXMLHang()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Hang", conn);
            DataTable dt = new DataTable("Hang");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\Hang.xml", XmlWriteMode.WriteSchema);

        }
        public void TaoXMLPhieuNhap()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from PhieuNhap", conn);
            DataTable dt = new DataTable("PhieuNhap");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\PhieuNhap.xml", XmlWriteMode.WriteSchema);

        }
        public void TaoXMLChamCong()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from ChamCong", conn);
            DataTable dt = new DataTable("ChamCong");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\ChamCong.xml", XmlWriteMode.WriteSchema);

        }
        public void TaoXMLHoaDon()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from HoaDon", conn);
            DataTable dt = new DataTable("HoaDon");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\HoaDon.xml", XmlWriteMode.WriteSchema);

        }
        public void TaoXMLChiTietHoaDon()
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from ChiTietHoaDon", conn);
            DataTable dt = new DataTable("ChiTietHoaDon");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\ChiTietHoaDon.xml", XmlWriteMode.WriteSchema);

        }
        public void Them(string duongDan, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode currNode;
            XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
            docFrag.InnerXml = noiDung;
            currNode = doc.DocumentElement;
            currNode.InsertAfter(docFrag, currNode.LastChild);
            doc.Save(duongDan);
        }
        public void Xoa(string duongDan, string tenFileXML, string xoaTheoTruong, string giaTriTruong)
        {
            string fileName = Application.StartupPath + "\\" + duongDan;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode nodeCu = doc.SelectSingleNode("NewDataSet/" + tenFileXML + "[" + xoaTheoTruong + "='" + giaTriTruong + "']");
            doc.DocumentElement.RemoveChild(nodeCu);
            doc.Save(fileName);
        }

        public void Sua(string duongDan, string tenFile, string suaTheoTruong, string giaTriTruong, string noiDung)
        {

            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldHang;
            XmlElement root = doc.DocumentElement;
            oldHang = root.SelectSingleNode("/NewDataSet/" + tenFile + "[" + suaTheoTruong + "='" + giaTriTruong + "']");
            XmlElement newhang = doc.CreateElement(tenFile);
            newhang.InnerXml = noiDung;
            root.ReplaceChild(newhang, oldHang);
            doc.Save(duongDan);
        }
        public string LayGiaTri(string duongDan, string truongA, string giaTriA, string truongB)
        {
            string giatriB = "";
            DataTable dt = new DataTable();
            dt = HienThi(duongDan);
            int soDongNhanVien = dt.Rows.Count;
            for (int i = 0; i < soDongNhanVien; i++)
            {
                if (dt.Rows[i][truongA].ToString().Trim().Equals(giaTriA))
                {
                    giatriB = dt.Rows[i][truongB].ToString();
                    return giatriB;
                }
            }
            return giatriB;
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
        public void TimKiemXSLT(string data, string tenFileXML, string tenfileXSLT)
        {

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("\\" + tenfileXSLT + ".xslt");
            // Create the XsltArgumentList.
            XsltArgumentList argList = new XsltArgumentList();
            // Calculate the discount date.
            argList.AddParam("Data", "", data);
            // Create an XmlWriter to write the output.             
            XmlWriter writer = XmlWriter.Create("\\" + tenFileXML + ".html");
            // Transform the file.
            xslt.Transform(new XPathDocument("\\" + tenFileXML + ".xml"), argList, writer);
            writer.Close();
            System.Diagnostics.Process.Start("\\" + tenFileXML + ".html");

        }
        public void InsertOrUpDateSQL(string sql)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
