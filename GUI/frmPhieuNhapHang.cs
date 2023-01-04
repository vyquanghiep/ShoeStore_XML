using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuanLySieuThi.Class;
using System.Windows.Forms;

namespace QuanLySieuThi.GUI
{
    public partial class frmPhieuNhapHang : Form
    {
        PhieuNhap pn = new PhieuNhap();
        FileXml Fxml = new FileXml();
        NhanVien nv = new NhanVien();
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }

        public void hienthiPhieuNhap()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("PhieuNhap.xml");
            dgvPhieuNhapHang.DataSource = dt;
        }

        private void dgvPhieuNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvPhieuNhapHang.CurrentRow.Index;
            txtMaPhieu.Text = dgvPhieuNhapHang.Rows[d].Cells[0].Value.ToString();
            txtMaHang.Text = dgvPhieuNhapHang.Rows[d].Cells[1].Value.ToString();
            txtMaNhanVien.Text = dgvPhieuNhapHang.Rows[d].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvPhieuNhapHang.Rows[d].Cells[3].Value.ToString();
            dptNgaylapPhieu.Text = dgvPhieuNhapHang.Rows[d].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (pn.kiemtraMaPhieu(txtMaPhieu.Text) == true)
            {
                MessageBox.Show("Mã phiếu đã tồn tại");
            }
            else
            {
                if (nv.kiemtra(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Ma Nhan Vien Khong");
                }
                else
                {
                    DateTime dt = DateTime.Parse(dptNgaylapPhieu.Text);
                    pn.themPN(txtMaPhieu.Text, txtMaHang.Text, txtMaNhanVien.Text, txtSoLuong.Text, dt.ToString());
                    MessageBox.Show("Ok");
                    hienthiPhieuNhap();
                    txtMaPhieu.Focus();
                }

            }
                
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ko tìm thấy máy in");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {

            hienthiPhieuNhap();
        }
    }
}
