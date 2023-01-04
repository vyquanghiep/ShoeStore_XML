using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using QuanLySieuThi.Class;
namespace QuanLySieuThi.GUI
{
    public partial class frmDoiMatKhau : Form
    {
        DangNhap dn = new DangNhap();
        DoiMatKhau dmk = new DoiMatKhau();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        
        bool LoadDuLieu()
        {

            if (!dmk.KiemTraMK(txtMatKhauCu.Text))
            {
                MessageBox.Show("Sai mật khẩu cũ");
                return false;
            }
            if (!txtMatKhauMoi.Text.Equals(txtNhapLai.Text))
            {
                MessageBox.Show("Mật khẩu mới sai");
                return false;
            }
            return true;
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
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (LoadDuLieu())
            {
                if (MessageBox.Show("Bạn có chắc muốn đổi mật khẩu không?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dmk.Doi(txtMatKhauMoi.Text);
                    MessageBox.Show("Đổi mật khẩu thành công");
                    Close();
                }
            }

            }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLai.Text = "";
        }

       
        }
    }

