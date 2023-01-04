using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuanLySieuThi.Class
{
    
    class ChamCong
    {
        FileXml Fxml = new FileXml();
        int n = 7;
        public void themCC(string MaNhanVien, int Ngay, int Thang, int Nam)
        {
            string noiDung = "<_x0027_ChamCong_x0027_>" +
                    "<Id>" + n + "</Id>" +
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<Ngay>" + Ngay + "</Ngay>" +
                    "<Thang>" + Thang + "</Thang>" +
                    "<Nam>" + Nam + "</Nam>" +
                    "</_x0027_ChamCong_x0027_>";
            Fxml.Them("ChamCong.xml", noiDung);
            n++;
        }
    }
}
