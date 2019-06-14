using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmMain : Form
    {
        SVIENBLL bllSvien;

        public frmMain()
        {
            InitializeComponent();
            bllSvien = new SVIENBLL();

            #region Form
            pnlSelect.Height = btnSV.Height;
            pnlSelect.Top = btnSV.Top;
            lblTime.Text = DateTime.Now.Hour.ToString();
            timer1.Start();
            #endregion

        }

        public void ShowAllSV()
        {
            DataTable dt = bllSvien.getAllSVien();
            dataGridView1.DataSource = dt;
            

        }

        #region Button Sinh Vien, About
        private void btnSV_Click(object sender, EventArgs e)
        {
            pnlSelect.Height = btnSV.Height;
            pnlSelect.Top = btnSV.Top;
           
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            pnlSelect.Height = btnAbout.Height;
            pnlSelect.Top = btnAbout.Top;


        }

        private void btnQLLop_Click(object sender, EventArgs e)
        {
            pnlSelect.Height = btnQLLop.Height;
            pnlSelect.Top = btnQLLop.Top;

            frmLop frmLop = new frmLop();
            frmLop.Show();
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

            ShowAllSV();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        #region CheckData
        public bool KiemTraData() {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Mã SV", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSV.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGioiTinh.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Giới Tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioiTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLop.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Lớp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Điểm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Địa Chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraData())
            {
                tblSVIEN sv = new tblSVIEN();
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.GioiTinh = txtGioiTinh.Text;
                sv.Lop = txtLop.Text;
                sv.Diem = decimal.Parse(txtDiem.Text);
                sv.DiaChi = txtDiaChi.Text;
                sv.NgaySinh = txtNgaySinh.Text;
                if (bllSvien.ThemSV(sv))
                    ShowAllSV();
                else
                    MessageBox.Show("Đã Có Lỗi Xảy Ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraData())
            {
                tblSVIEN sv = new tblSVIEN();
                sv.MaSV = MaSVIEN;
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.GioiTinh = txtGioiTinh.Text;
                sv.Lop = txtLop.Text;
                sv.Diem = decimal.Parse(txtDiem.Text);
                sv.DiaChi = txtDiaChi.Text;
                sv.NgaySinh = txtNgaySinh.Text;

                if (bllSvien.CapNhatSV(sv))
                    ShowAllSV();
                else
                    MessageBox.Show("Đã Có Lỗi Xảy Ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
        }
        string MaSVIEN;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                MaSVIEN = dataGridView1.Rows[index].Cells["MaSV"].Value.ToString();
                txtMaSV.Text = dataGridView1.Rows[index].Cells["MaSV"].Value.ToString();
                txtTenSV.Text = dataGridView1.Rows[index].Cells["TenSV"].Value.ToString();
                txtGioiTinh.Text = dataGridView1.Rows[index].Cells["GioiTinh"].Value.ToString();
                txtLop.Text = dataGridView1.Rows[index].Cells["Lop"].Value.ToString();
                txtDiem.Text = dataGridView1.Rows[index].Cells["Diem"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[index].Cells["DiaChi"].Value.ToString();
                txtNgaySinh.Text = dataGridView1.Rows[index].Cells["NgaySinh"].Value.ToString();
   
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Không", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSVIEN sv = new tblSVIEN();
                sv.MaSV = MaSVIEN;

                if (bllSvien.XoaSV(sv))
                    ShowAllSV();
                else
                    MessageBox.Show("Đã Có Lỗi Xảy Ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string value = txtTim.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSvien.TimKiemSV(value);
                dataGridView1.DataSource = dt;
            }
            else
            {
                ShowAllSV();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRPDanhSachSV frmDS = new frmRPDanhSachSV();
            frmDS.Show();
        }

      
    }
}
