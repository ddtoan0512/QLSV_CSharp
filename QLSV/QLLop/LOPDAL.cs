using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class LOPDAL
    {
        DataConnection dc;
        SqlDataAdapter daLop;
        SqlCommand cmd;

        public LOPDAL()
        { 
            dc = new DataConnection();

        }
        public DataTable getAllLop()
        { 
            
            //B1  Tao Cau Lenh Sql de lay toan bo sinh vien
            string sql = "SELECT * FROM tblLop";
            // B2 Tao 1 Ket Noi Den SQL
            SqlConnection con = dc.getConnect();
            //B3 Khoi Tao  Doi Tuong Lop  SqlDataAdapter
            daLop = new SqlDataAdapter(sql, con);
            //B4 Mo Ket Noi
            con.Open();
            //B5 Đổ dữ liệu từ SqlDataAdapter và DataTable
            DataTable dtLop = new DataTable();
            daLop.Fill(dtLop);
            //B6 Dong Ket Noi
            con.Close();
            return dtLop;
        }

        public bool ThemLop(tblLop lop)
        {
            string sql = "INSERT INTO tblLop(MaLop, TenLop, Khoa) VALUES(@MaLop, @TenLop, @Khoa)";
            SqlConnection con = dc.getConnect();

            try
            { 
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = lop.MaLop ;
                cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar).Value = lop.TenLop;
                cmd.Parameters.Add("@Khoa", SqlDbType.NVarChar).Value = lop.Khoa;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception e)
            {
                return false;       
            }
                return true;
        }

        public bool CapNhatLop(tblLop lop)
        {
            string sql = "UPDATE tblLop SET TenLop = @TenLop Khoa = @Khoa WHERE MaLop = @MaLop";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = lop.MaLop;
                cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar).Value = lop.TenLop;
                cmd.Parameters.Add("@Khoa", SqlDbType.NVarChar).Value = lop.Khoa;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaLop(tblLop lop)
        {
            string sql = "DELETE tblLop  WHERE MaLop = @MaLop";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = lop.MaLop;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable TimKiemLop(string lop)
        {
            string sql = "SELECT * FROM tblLop WHERE MaLop like '%" + lop + "%' OR TenLop like N'%" + lop + "%' OR Khoa like '%" + lop + "%'";
            // B2 Tao 1 Ket Noi Den SQL
            SqlConnection con = dc.getConnect();
            //B3 Khoi Tao  Doi Tuong Lop  SqlDataAdapter
            daLop = new SqlDataAdapter(sql, con);
            //B4 Mo Ket Noi
            con.Open();
            //B5 Đổ dữ liệu từ SqlDataAdapter và DataTable
            DataTable dtLop = new DataTable();
             daLop.Fill(dtLop);
            //B6 Dong Ket Noi
            con.Close();
            return dtLop;
        }
    }
}
