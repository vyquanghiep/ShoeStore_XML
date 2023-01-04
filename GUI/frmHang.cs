using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuanLySieuThi.Class;

using System.Windows.Forms;
using System.Xml;


namespace QuanLySieuThi.GUI
{
    public partial class frmHang : Form
    {
        FileXml Fxml = new FileXml();
        Hang H = new Hang();
        NhaCungCap ncc = new NhaCungCap();
        public frmHang()
        {
            InitializeComponent();
        }
        public void hienthiHang()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("Hang.xml");
            dgvHang.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (H.kiemtraMaHang(txtMaHang.Text) == true)
            {
                MessageBox.Show("Mã hàng đã tồn tại");
            }
            else
            {
                H.themH(txtMaHang.Text, txtTenHang.Text, txtDonViTinh.Text,txtDonGia.Text,txtSoLuong.Text, cbbMaNCC.SelectedValue.ToString());
                MessageBox.Show("Thêm thành công");
                hienthiHang();
            }
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            cbbMaNCC.DataSource = ncc.LoadMaNCC();
            cbbMaNCC.DisplayMember = "TenNCC";
            cbbMaNCC.ValueMember = "MaNCC";
            hienthiHang();
        }
        void LoadTable()
        {
            DataTable dt = new DataTable();
            dt = ncc.LoadTable();
            dgvHang.DataSource = dt;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            H.suaH(txtMaHang.Text, txtTenHang.Text, txtDonViTinh.Text, txtDonGia.Text, txtSoLuong.Text, cbbMaNCC.SelectedValue.ToString());
            MessageBox.Show("Ok");
            hienthiHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            H.xoaH(txtMaHang.Text);
            MessageBox.Show("Ok");
            hienthiHang();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            hienthiHang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            XmlTextReader reader = new XmlTextReader("Hang.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaHang";
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
                dt.Columns.Add("Mã hàng");
                dt.Columns.Add("Tên hàng");
                dt.Columns.Add("Đơn vị tính");
                dt.Columns.Add("Đơn giá");
                dt.Columns.Add("Sô lượng");
                dt.Columns.Add("Mã NCC");
                

                object[] list = { dv[index]["MaHang"], dv[index]["TenHang"],dv[index]["DonViTinh"], dv[index]["DonGia"], dv[index]["SoLuong"], dv[index]["MaNCC"]};
                dt.Rows.Add(list);
                dgvHang.DataSource = dt;
                txtTimKiem.Text = "";
            }
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvHang.CurrentRow.Index;
            txtMaHang.Text = dgvHang.Rows[d].Cells[0].Value.ToString();
            txtTenHang.Text = dgvHang.Rows[d].Cells[1].Value.ToString();
            txtDonViTinh.Text = dgvHang.Rows[d].Cells[2].Value.ToString();
            txtDonGia.Text = dgvHang.Rows[d].Cells[3].Value.ToString();
            txtSoLuong.Text = dgvHang.Rows[d].Cells[4].Value.ToString();
            cbbMaNCC.SelectedValue = dgvHang.Rows[d].Cells[5].Value.ToString();
        
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Hang.xml";
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
