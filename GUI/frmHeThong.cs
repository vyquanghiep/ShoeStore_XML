using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLySieuThi.GUI;
using QuanLySieuThi.Class;

namespace QuanLySieuThi
{
    public partial class frmMain : Form
    {
        FileXml Fxml = new FileXml();
        Main M = new Main();
        HeThong HT = new HeThong();
        public frmMain()
        {
            InitializeComponent();
        }
        public static string tenDNMain = "";
        public static string maNVMain = "";
        void ThongTinDangNhap()
        {

            lblHoTen.Text = M.HoTen(tenDNMain);
            lblTen.Text = M.HoTen(tenDNMain);
            

        }
        private bool CheckForm(string nameForm)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
                if (frm.Name == nameForm)
                {
                    check = true;
                    break;
                }
            return check;

        }
        private void ActivateForm(string nameForm)
        {
            foreach (Form frm in this.MdiChildren)
                if (frm.Name == nameForm)
                {
                    frm.Activate();
                    break;
                }
        }
        
       
        public void QuyenDangNhap(bool e)
        {
            mnuHeThong.Enabled = e;
            mnuKinhDoanh.Enabled = e;
            mnuQLNhanSu.Enabled = e;
            đổiMậtKhẩuToolStripMenuItem.Enabled = e;
            mnuChamCong.Enabled = e;
            lblQuyen.Visible = e;
            lblHoTen.Visible = e;
            chuyểnĐổiDữLiệuToolStripMenuItem.Enabled = e;
            đăngNhậpToolStripMenuItem.Enabled = !e;
            
            
            if (tenDNMain.Equals("admin"))
            {
                mnuQLNhanSu.Enabled = e;
                lblQuyen.Visible = e;
                lblHoTen.Visible = e;
                
                đổiMậtKhẩuToolStripMenuItem.Enabled = e;
                lblQuyen.Text = "Administrutor";
            }
            else
            {
                mnuQLNhanSu.Enabled = false;
                mnuHeThong.Enabled = true;
                lblQuyen.Text = "Nhân Viên";
                
            }
            if (e) ThongTinDangNhap();
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForm("frmDangNhap"))
            {
                Form frm = new frmDangNhap();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                ActivateForm("frmDangNhap");
            }
            //đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
        }

        private void từSQLXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HT.TaoXML();
                MessageBox.Show("Tạo XML thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
                      
         }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            QuyenDangNhap(false);
            if (!CheckForm("frmDangNhap"))
            {
                Form frm = new frmDangNhap();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                ActivateForm("frmDangNhap");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuyenDangNhap(false);
            tenDNMain = "";
            maNVMain = "";
            mnuHeThong.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = false;
            lblHoTen.Text = "";
            lblQuyen.Text = "";
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void quảnLýTàiKhoảnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoanNV frm = new frmTaiKhoanNV();
            frm.ShowDialog();
        }

        private void quảnLýHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHang frm = new frmHang();
            frm.ShowDialog();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.ShowDialog();
        }

        private void xácNhậnĐiLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXacNhanDiLam frm = new frmXacNhanDiLam();
            frm.ShowDialog();
        }

        private void quảnLýNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhapHang frm = new frmPhieuNhapHang();
            frm.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void từXMLSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HT.CapNhapSQL();
                MessageBox.Show("Cập nhập SQL server thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.ShowDialog();
        }

        private void xemChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemChamCong frm = new frmXemChamCong();
            frm.ShowDialog();
        }
    }
}
