using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmLop : Form
    {
        LOPBLL bllLop;
        public frmLop()
        {
            InitializeComponent();
            bllLop = new LOPBLL();
        }

        public void ShowAllLop()
        {
            DataTable dtlop = bllLop.getAllLop();
            dataGridViewLop.DataSource = dtlop;
        }
        private void frmLop_Load(object sender, EventArgs e)
        {
            ShowAllLop();
            this.MaximizeBox = false;
        }

        public bool KiemTraDataLop()
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Lớp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLop.Focus();
                return false;
            }
            return true;
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            if (KiemTraDataLop())
            {
                tblLop lop = new tblLop();
                lop.MaLop = txtMaLop.Text;
                lop.TenLop = txtTenLop.Text;
                lop.Khoa = comboBoxKhoa.SelectedItem.ToString();
                if (bllLop.ThemLop(lop))
                    ShowAllLop();
                else
                    MessageBox.Show("Đã Có Lỗi Xảy Ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
        }

        string MaLp;
        private void dataGridViewLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                MaLp = dataGridViewLop.Rows[index].Cells["MaLop"].Value.ToString();
                txtMaLop.Text = dataGridViewLop.Rows[index].Cells["MaLop"].Value.ToString();
                txtTenLop.Text = dataGridViewLop.Rows[index].Cells["TenLop"].Value.ToString();
                comboBoxKhoa.Text = dataGridViewLop.Rows[index].Cells["Khoa"].Value.ToString();
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (KiemTraDataLop())
            {
                tblLop lop = new tblLop();
                lop.MaLop = MaLp;
                lop.MaLop = txtMaLop.Text;
                lop.TenLop = txtTenLop.Text;
                lop.Khoa = comboBoxKhoa.SelectedItem.ToString();

                if (bllLop.CapNhatLop(lop))
                    ShowAllLop();
                else
                    MessageBox.Show("Đã Có Lỗi Xảy Ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Không", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblLop lop = new tblLop();
                lop.MaLop = MaLp;

                if (bllLop.XoaLop(lop))
                    ShowAllLop();
                else
                    MessageBox.Show("Đã Có Lỗi Xảy Ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimLop.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllLop.TimKiemLop(value);
                dataGridViewLop.DataSource = dt;
            }
            else
            {
                ShowAllLop();
            }
        }
        







    }
}
