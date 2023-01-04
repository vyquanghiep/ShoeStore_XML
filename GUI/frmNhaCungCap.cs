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
    public partial class frmNhaCungCap : Form
    {
        FileXml Fxml = new FileXml();
        NhaCungCap ncc = new NhaCungCap();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        public void hienthiNCC()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NhaCungCap.xml");
            dgvNhaCungCap.DataSource = dt;
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            hienthiNCC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (ncc.kiemtraMaNCC(txtMaNCC.Text) == true)
            {
                MessageBox.Show("Nhà cung cấp này đã tồn tại");
            }
            else
            {
                ncc.themNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text,txtSDT.Text, txtEmail.Text, txtMoTa.Text);
                MessageBox.Show("Ok");
                hienthiNCC();
                txtMaNCC.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ncc.suaNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text,txtSDT.Text, txtEmail.Text, txtMoTa.Text);
            MessageBox.Show("Ok");
            hienthiNCC();
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ncc.xoaNCC(txtMaNCC.Text);
            MessageBox.Show("Ok");
            hienthiNCC();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            hienthiNCC();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            XmlTextReader reader = new XmlTextReader("NhaCungCap.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNCC";
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
                dt.Columns.Add("Mã NCC");
                dt.Columns.Add("Tên NCC");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("SDT");
                dt.Columns.Add("Email");
                dt.Columns.Add("Mô tả");


                object[] list = { dv[index]["MaNCC"], dv[index]["TenNCC"], dv[index]["DiaChi"], dv[index]["SDT"], dv[index]["Email"], dv[index]["MoTa"] };
                dt.Rows.Add(list);
                dgvNhaCungCap.DataSource = dt;
                txtTimKiem.Text = "";
            }
        }

        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvNhaCungCap.CurrentRow.Index;
            txtMaNCC.Text = dgvNhaCungCap.Rows[d].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.Rows[d].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap.Rows[d].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhaCungCap.Rows[d].Cells[3].Value.ToString();
            txtEmail.Text = dgvNhaCungCap.Rows[d].Cells[4].Value.ToString();
            txtMoTa.Text = dgvNhaCungCap.Rows[d].Cells[5].Value.ToString();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (ncc.kiemtraMaNCC(txtMaNCC.Text) == true)
            {
                MessageBox.Show("Nhà cung cấp này đã tồn tại");
            }
            else
            {
                ncc.themNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtMoTa.Text);
                MessageBox.Show("Thêm thành công");
                hienthiNCC();
                txtMaNCC.Focus();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            ncc.suaNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtMoTa.Text);
            MessageBox.Show("Sửa Thành công");
            hienthiNCC();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            ncc.xoaNCC(txtMaNCC.Text);
            MessageBox.Show("Ok");
            hienthiNCC();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("NhaCungCap.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNCC";
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
                dt.Columns.Add("Mã NCC");
                dt.Columns.Add("Tên NCC");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("SDT");
                dt.Columns.Add("Email");
                dt.Columns.Add("Mô tả");


                object[] list = { dv[index]["MaNCC"], dv[index]["TenNCC"], dv[index]["DiaChi"], dv[index]["SDT"], dv[index]["Email"], dv[index]["MoTa"] };
                dt.Rows.Add(list);
                dgvNhaCungCap.DataSource = dt;
                txtTimKiem.Text = "";
            }
        }

        private void btnHienThi_Click_1(object sender, EventArgs e)
        {
            hienthiNCC();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\NhaCungCap.xml";
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
