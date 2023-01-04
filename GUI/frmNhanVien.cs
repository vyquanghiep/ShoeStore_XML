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
    public partial class frmNhanVien : Form
    {
        NhanVien nv = new NhanVien();
        FileXml Fxml = new FileXml();
        string MaNhanVien, TenNhanVien, NgaySinh, DiaChi, SDT, Email;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void hienthiNhanVien()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NhanVien.xml");
            dgvNhanVien.DataSource = dt;

        }
        public void LoadDuLieu()
        {
            MaNhanVien = txtMaNhanVien.Text;
            TenNhanVien = txtTenNhanVien.Text;
            
            DiaChi = txtDiaChi.Text;
            SDT = txtSDT.Text;
            Email = txtEmail.Text;


        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            hienthiNhanVien();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvNhanVien.CurrentRow.Index;
            txtMaNhanVien.Text = dgvNhanVien.Rows[d].Cells[0].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[d].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[d].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[d].Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[d].Cells[4].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[d].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            if (nv.kiemtra(MaNhanVien) == true)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
            }
            else
            {
                DateTime dt = DateTime.Parse(dtpNgaySinh.Text);
                nv.themNV(MaNhanVien, TenNhanVien, dt.ToString(), DiaChi, SDT, Email);
                MessageBox.Show("Ok");
                hienthiNhanVien();
                txtMaNhanVien.Focus();
            }
        }

        private void tbnSua_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            DateTime dt = DateTime.Parse(dtpNgaySinh.Text);
            nv.suaNV(MaNhanVien, TenNhanVien, dt.ToString(), DiaChi, SDT, Email);
            MessageBox.Show("Ok");
            hienthiNhanVien();

            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            nv.xoaNV(MaNhanVien);
            MessageBox.Show("Ok");
            hienthiNhanVien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("NhanVien.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNhanVien";
            reader.Close();
            int index = dv.Find(txtTimKiem.Text);
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                txtTimKiem.Text = "";
                txtTimKiem.Focus();

            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã nhân viên");
                dt.Columns.Add("Họ và tên");
                dt.Columns.Add("Ngày sinh");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("Email");
                

                object[] list = { dv[index]["MaNhanVien"], dv[index]["TenNhanVien"],dv[index]["NgaySinh"], dv[index]["DiaChi"], dv[index]["SDT"], dv[index]["Email"]};
                dt.Rows.Add(list);
                dgvNhanVien.DataSource = dt;
                txtTimKiem.Text = "";
            }
        }

        private void tbnHienThi_Click(object sender, EventArgs e)
        {
            hienthiNhanVien();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\NhanVien.xml";
            try
            {
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Chưa có file cần mở trong bin/debug", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
