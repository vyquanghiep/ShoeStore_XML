using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLySieuThi.Class;

namespace QuanLySieuThi.GUI
{
    public partial class frmHoaDon : Form
    {
        FileXml Fxml = new FileXml();
        HoaDon H = new HoaDon();
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void hienthiHoaDon()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("HoaDon.xml");
            dtgHoaDon.DataSource = dt;
        }

        private void txtMaHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDonGia.Text = Fxml.LayGiaTri("Hang.xml", "MaHang", txtMaHang.Text, "DonGia");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSoLuong.Text == " ")
            {
                txtSoLuong.Text = "";
            }
            else
            {
                try
                {
                    int a = int.Parse(txtSoLuong.Text);
                    long t = int.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);
                    txtTongTien.Text = t.ToString();
                }
                catch
                {
                    txtSoLuong.Text = "";
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không có máy in");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dateTimePicker1.Text);
            H.themHD(textBox1.Text,txtMaNhanVien.Text,dt.ToString(),txtTongTien.Text);
            MessageBox.Show("Thêm thành công");
            hienthiHoaDon();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            hienthiHoaDon();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            H.xoaHD(textBox1.Text);
            MessageBox.Show("Xóa thành công");
            hienthiHoaDon();
        }

        private void dtgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dtgHoaDon.CurrentRow.Index;
            textBox1.Text = dtgHoaDon.Rows[d].Cells[0].Value.ToString();
            txtMaNhanVien.Text = dtgHoaDon.Rows[d].Cells[1].Value.ToString();
            dateTimePicker1.Text = dtgHoaDon.Rows[d].Cells[2].Value.ToString();
            txtTongTien.Text = dtgHoaDon.Rows[d].Cells[3].Value.ToString();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
