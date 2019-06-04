using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSV
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtUser.Text = "User Name";
           // txtPass.Text = "Password";
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtUser.ForeColor = Color.White;

        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtPass.ForeColor = Color.White;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        DataConnection dc;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dc = new DataConnection();
                SqlConnection conn = dc.getConnect();
                string tk = txtUser.Text;
                string mk = txtPass.Text;
                string sql = "SELECT * FROM tblTaiKhoan WHERE id = '" + tk + "' AND pass = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(); //<-Dung CHo SELECT //Cau lenh INSERT, ... cmd.ExecuteNonQuery();
                if (dr.Read() == true)
                {
                     MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     frmMain fMain = new frmMain();
                     this.Hide();
                     fMain.ShowDialog();
                     this.Close();
                }
                else
                {
                    MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu");
                    txtUser.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối !");
            }
          

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                dc = new DataConnection();
                SqlConnection conn = dc.getConnect();
                conn.Open();
                cmd = new SqlCommand("INSERT INTO tblTaiKhoan(id, pass) VALUES(@id, @pass)", conn);
                cmd.Parameters.Add("@id", txtUser.Text);
                cmd.Parameters.Add("@pass", txtPass.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng Ký Thành Công","Thông Báo");
            }
            else
            {
                MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Không Được Để Trống !", "Thông Báo");
            }
        }
    }
}
