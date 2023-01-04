using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLySieuThi.Class;
using System.Xml;

namespace QuanLySieuThi.GUI
{
    public partial class frmXemChamCong : Form
    {
        FileXml Fxml = new FileXml();
        public frmXemChamCong()
        {
            InitializeComponent();
        }
        public void hienthiChamCong()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("ChamCong.xml");
            dtgxem.DataSource = dt;

        }

        private void frmXemChamCong_Load(object sender, EventArgs e)
        {
            hienthiChamCong();
        }
    }
}
